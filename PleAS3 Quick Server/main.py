# Socket server in python using select function
 
import socket, select

RECV_BUFFER = 4096      # Advisable to keep it as an exponent of 2
PORT = 5000             # The server port

CONNECTION_LIST = []    # list of socket clients
IN_QUEUE = []           # list of all the sockets in queue
MATCHES = {}            # dictionary linking sockets to each other
    
def ProcessSocketClosed(sock):
    _addr = sock.getpeername()
    
    print "Client (%s, %s) disconnected!"  % _addr
    sock.close()
    CONNECTION_LIST.remove(sock)

    if _addr in MATCHES:
        othersock = MATCHES[_addr]

        del MATCHES[_addr]
        del MATCHES[othersock.getpeername()]

        print "\tAlerting (%s, %s) that game ended abruptly!" % othersock.getpeername()
        ProcessSocketClosed(othersock)
    else:
        print "\tNot in match... thats good."
        
    

if __name__ == "__main__":
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) # this has no effect, why ?
    server_socket.bind(("0.0.0.0", PORT))
    server_socket.listen(10)
 
    # Add server socket to the list of readable connections
    CONNECTION_LIST.append(server_socket)
 
    print "Chat server started on port " + str(PORT)
 
    while 1:
        # Get the list sockets which are ready to be read through select
        read_sockets,write_sockets,error_sockets = select.select(CONNECTION_LIST,[],[])
 
        for sock in read_sockets:
            #New connection
            if sock == server_socket:
                # Handle the case in which there is a new connection recieved through server_socket
                sockfd, addr = server_socket.accept()
                CONNECTION_LIST.append(sockfd)
                print "Client (%s, %s) connected" % addr

                if len(IN_QUEUE) > 0:
                    match = IN_QUEUE.pop()
                    MATCHES[sockfd.getpeername()] = match
                    MATCHES[match.getpeername()] = sockfd
                    print "\tPaired", sockfd.getpeername(), "with", match.getpeername()
                else:
                    IN_QUEUE.append(sockfd)
                    print "\tNo one is waiting just yet..."
                 
            #Some incoming message from a client
            else:
                # Data recieved from client, process it
                try:
                    #In Windows, sometimes when a TCP program closes abruptly,
                    # a "Connection reset by peer" exception will be thrown
                    data = sock.recv(RECV_BUFFER)
                    # echo back the client message
                    if data:
                        if sock.getpeername() in MATCHES:
                            MATCHES[sock.getpeername()].send(data)
                        else:
                            print "Not sure, but", sock.getpeername(), "appears to be trying to send data to the server?"
                        ##sock.send('OK ... ' + data)
                    else:
                        #Throw exception so that the socket is cleaned up :)
                        raise Exception()
                
                # client disconnected, so remove from socket list
                except:
                    ProcessSocketClosed(sock)
                    continue
         
    server_socket.close()
