using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace EngineDebugger {
    public class GenericServer {
        const int SILENT_NETWORK_TICK_LENGTH_MS = 100; //100ms sleep for each client
        const int SILENT_NETWORK_TICKS_BEFORE_PING = 300; //30s
        const int SILENT_NETWORK_TICKS_EXPECTED_REPLY = 300; //30s

        private TcpListener tcpListener;

        private Object semaphore = new object();
        private Object semaphore_client = new object();
        private Object semaphore_counter = new object();

        private Thread listenThread;
        public int threadCounter;

        private static bool SHUTDOWN_REQUIRED = false;

        private NetworkStream _clientStream;
        private DebugForm form;
        public bool isConnected = false;

        public GenericServer(int portNumber, DebugForm _form) {
            this.form = _form;
            this.tcpListener = new TcpListener(IPAddress.Any, portNumber);

            if (tcpListener == null) {
                throw new Exception("BAD TCP Listener");
            }

            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Name = "GenericServer_ListenThread";
            this.listenThread.Start();
        }

        public void SendMessage(NetworkMessage message, NetworkStream _client = null, int failAttempts = 5) {
            if (_client == null && _clientStream == null) return;
            if (_client == null && _clientStream != null) _client = _clientStream;

            try {
                int totalAttempts = 0;
                while (true) {
                    if (_client == null) return;
                    totalAttempts++;

                    if (Monitor.TryEnter(semaphore_client, 500)) {
                        try {
                            if (_client.CanWrite) {
                                byte[] outBytes;
                                int length;
                                message.Encode(out outBytes, out length);

                                _client.Write(outBytes, 0, length);
                            }
                        } finally {
                            Monitor.Exit(semaphore_client);
                        }

                        break;
                    }

                    if (failAttempts > 0 && totalAttempts > failAttempts) {
                        break;
                    }
                }
            } catch (Exception ex) {
                Logger.Log(form, "SendMessageTo Except: " + ex.Message);
            } finally {
                message.Dispose();
            }
        }

        public void Shutdown() {
            lock (semaphore) {
                if (tcpListener != null) {
                    tcpListener.Stop();
                    tcpListener = null;
                }
            }

            SHUTDOWN_REQUIRED = true;

            while (true) {
                lock (semaphore_counter) {
                    if (threadCounter == 0)
                        break;

                    Thread.Sleep(SILENT_NETWORK_TICK_LENGTH_MS);
                }
            }

            listenThread.Join();
        }

        private void ListenForClients() {
            this.tcpListener.Start(50);

            while (this.tcpListener != null) {
                lock (semaphore) {
                    if (tcpListener != null && tcpListener.Pending()) {
                        //blocks until a client has connected to the server
                        TcpClient client = this.tcpListener.AcceptTcpClient();

                        //TODO: single thread that checks all the clients rather than 1 client per thread
                        //create a thread to handle communication with connected client
                        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                        clientThread.Name = "GenericServer_ClientThread";
                        clientThread.Start(client);

                        Logger.Log(form, "[DEBUGGER] A client connected");

                        lock (semaphore_counter) {
                            threadCounter++;
                        }
                    }
                }

                Thread.Sleep(SILENT_NETWORK_TICK_LENGTH_MS);
            }

            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
        }

        private void HandleClientComm(object client) {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream _client = tcpClient.GetStream();
            byte[] messageSize = new byte[4];

            int bytesRead;

            int errors = 0;
            int timeout_ticks = 0;

            byte[] polRequestHeader = new byte[] { 60, 112, 111, 108 };

            while (errors == 0) {
                if (SHUTDOWN_REQUIRED) {
                    break;
                }

                bytesRead = 0;

                bool hasReading;

                lock (semaphore_client) {
                    hasReading = _client.DataAvailable;
                }

                //Nothing to read, so just continue
                if (!hasReading) {
                    timeout_ticks++;

                    if (!tcpClient.Connected) {
                        Logger.Log(form, "A client has disconnected. Socket was closed unexpectedly.");
                        errors++;
                    } else if (timeout_ticks == SILENT_NETWORK_TICKS_BEFORE_PING) {
                        Logger.Log(form, "PING><");
                        SendMessage(new NetworkMessage(MSG.KEEP_ALIVE));
                    } else if (timeout_ticks == SILENT_NETWORK_TICKS_BEFORE_PING + SILENT_NETWORK_TICKS_EXPECTED_REPLY) {
                        Logger.Log(form, "A client has disconnected. Timeout has lapsed.");
                        errors++;
                    }

                    Thread.Sleep(SILENT_NETWORK_TICK_LENGTH_MS);
                    continue;
                }

                //Since there is data there, we can reset the timer. :)
                timeout_ticks = 0;

                lock (semaphore_client) {
                    while (_client.DataAvailable) {
                        try {
                            //blocks until a client sends a message
                            bytesRead = _client.Read(messageSize, 0, 4);

                            if (messageSize[0] == polRequestHeader[0] && messageSize[1] == polRequestHeader[1] && messageSize[2] == polRequestHeader[2] && messageSize[3] == polRequestHeader[3]) {
                                Byte[] encoded = Encoding.UTF8.GetBytes("<?xml version=\"1.0\"?>\n<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\"><cross-domain-policy><site-control permitted-cross-domain-policies=\"master-only\"/>\n<allow-access-from domain=\"lorgames.com\" to-ports=\"12685\" />\n</cross-domain-policy>");
                                _client.Write(encoded, 0, encoded.Length);
                                _client.Flush();
                                errors++;
                                break;
                                Logger.Log(form, "Policy requested. Reply sent.");
                            } else {
                                if (_clientStream == null && !isConnected) {
                                    Logger.Log(form, "A client connected.");
                                    _clientStream = _client;
                                    isConnected = true;
                                }
                            }
                        } catch {
                            //a socket error has occured
                            errors++;
                            break;
                        }

                        if (bytesRead == 0) {
                            //the client has disconnected from the server
                            errors++;
                            break;
                        }

                        int length = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(messageSize, 0));
                        byte[] thisMessage = new byte[length];

                        bytesRead = 0;

                        try {
                            while (bytesRead < length) {
                                bytesRead += _client.Read(thisMessage, bytesRead, length - bytesRead);
                            }
                        } catch {
                            //a socket error has occured
                            errors++;
                            break;
                        }

                        if (bytesRead == 0) {
                            errors++;
                            break;
                        }

                        NetworkMessage nm = new NetworkMessage(thisMessage);
                        nm.sockPTR = _client;

                        if (nm.Type == MSG.CLOSE) {
                            nm.Dispose();
                            Logger.Log(form, "A client has disconnected. Socket was closed via protocol.");
                            break;
                        } else if (nm.Type != MSG.KEEP_ALIVE) {
                            if(Monitor.TryEnter(semaphore_counter)) {
                                NetworkLogic.ProcessMessage(nm, form);
                                Monitor.Exit(semaphore_counter);
                            }
                        }
                    }
                }
            }

            _client.Close();
            tcpClient.Close();
            _client = null;
            isConnected = false;

            lock (semaphore_counter) {
                threadCounter--;
            }
        }
    }
}
