# LORgames PleAS3 Matchmaking Server
# Additionally has much of the code required for the game server for prototyping

import socket, select
import cStringIO
import struct
import datetime

RECV_BUFFER = 4096      # Advisable to keep it as an exponent of 2
MMAKE_PORT = 5000       # The matchmaking server port

CONNECTION_LIST = []    # list of socket clients ALREADY VERIFIED
IN_QUEUE = []           # list of all the sockets in queue
MATCHES = {}            # dictionary linking sockets to each other

MESSAGE_SET_PLAYER1 = cStringIO.StringIO()
MESSAGE_SET_PLAYER2 = cStringIO.StringIO()
MESSAGE_NFO_FNDGAME = cStringIO.StringIO()
MESSAGE_NFO_GETTIME = cStringIO.StringIO()

def ProcessSocketClosed(sock):
    _addr = sock.getpeername()
    
    print "[GAMING] Client (%s, %s) disconnected!"  % _addr
    sock.close()
    CONNECTION_LIST.remove(sock)

    if sock in IN_QUEUE:
        IN_QUEUE.remove(sock)

    if _addr in MATCHES:
        othersock = MATCHES[_addr]

        del MATCHES[_addr]
        del MATCHES[othersock.getpeername()]

        print "\tAlerting (%s, %s) that game ended abruptly!" % othersock.getpeername()
        ProcessSocketClosed(othersock)
        
def PrepareMessages():
    #set player 1 message
    MESSAGE_SET_PLAYER1.write(struct.pack('>H', 6)) #6 bytes for entire message
    MESSAGE_SET_PLAYER1.write(struct.pack('>H', 2)) #Type is '2'- CONTROL PACKET
    MESSAGE_SET_PLAYER1.write(struct.pack('>H', 0)) #Control Pack Type 0- Player ID
    MESSAGE_SET_PLAYER1.write(struct.pack('>H', 1)) #Player ID 1

    #set player 2 message
    MESSAGE_SET_PLAYER2.write(struct.pack('>H', 6)) #6 bytes for entire message
    MESSAGE_SET_PLAYER2.write(struct.pack('>H', 2)) #Type is '2'- CONTROL PACKET
    MESSAGE_SET_PLAYER2.write(struct.pack('>H', 0)) #Control Pack Type 0- Player ID
    MESSAGE_SET_PLAYER2.write(struct.pack('>H', 2)) #Player ID 2

    #found a game
    MESSAGE_NFO_FNDGAME.write(struct.pack('>H', 6)) #6 bytes for entire message
    MESSAGE_NFO_FNDGAME.write(struct.pack('>H', 2)) #Type is '2'- CONTROL PACKET
    MESSAGE_NFO_FNDGAME.write(struct.pack('>H', 1)) #Control Pack Type 1- MATCHMAKING
    MESSAGE_NFO_FNDGAME.write(struct.pack('>H', 1)) #Matchmaking complete

    #set start time
    MESSAGE_NFO_GETTIME.write(struct.pack('>H', 6)) #6 bytes for entire message
    MESSAGE_NFO_GETTIME.write(struct.pack('>H', 2)) #Type is '2'- CONTROL PACKET
    MESSAGE_NFO_GETTIME.write(struct.pack('>H', 2)) #Control Pack Type 2- MACHINE INFO
    MESSAGE_NFO_GETTIME.write(struct.pack('>H', 0)) #Current Time
    

def Pack(ioObj):
    ioObj.reset()
    return ioObj.read()
 
if __name__ == "__main__":
    print "Starting Server at", datetime.datetime.now()
    
    PrepareMessages()
    
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) # this has no effect, why ?
    server_socket.bind(("0.0.0.0", MMAKE_PORT))
    server_socket.listen(10)

    # Add server socket to the list of readable connections
    CONNECTION_LIST.append(server_socket)
 
    print "Matchmaking Server started on port " + str(MMAKE_PORT)
 
    while 1:
        # Get the list sockets which are ready to be read through select
        gaming_sockets,write_blank,write_blank = select.select(CONNECTION_LIST,[],[])
        
        for sock in gaming_sockets:
            #New connection
            if sock == server_socket:
                # Handle the case in which there is a new connection recieved through server_socket
                sockfd, addr = server_socket.accept()
                CONNECTION_LIST.append(sockfd)
                print "[GAMING] Client (%s, %s) connected (put them in joined)" % addr
                
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
                            if len(data) >= 22 and data[0:22] == "<policy-file-request/>":
                                print "[POLICY] Sent policy to (%s, %s)" % sock.getpeername()
                                sock.send("<cross-domain-policy><allow-access-from domain=\"*\" to-ports=\"5000\" /></cross-domain-policy>\x00");
                            elif len(data) >= 9 and data[0:9] == "PLEAS3_MM":
                                IN_QUEUE.append(sock)
                                print "[GAMING] Client (%s, %s) requested matchmaking queue." % sock.getpeername()
                            else:
                                print "Not sure, but", sock.getpeername(), "appears to be trying to send data to the server? Message=", data
                        ##sock.send('OK ... ' + data)
                    else:
                        ProcessSocketClosed(sock)
                
                # client disconnected, so remove from socket list
                except Exception, e:
                    print "[EXCEPT] "+str(e)
                    ProcessSocketClosed(sock)
                    continue
        
        while len(IN_QUEUE) > 1:
            match0 = IN_QUEUE.pop()
            match1 = IN_QUEUE.pop()
            MATCHES[match0.getpeername()] = match1
            MATCHES[match1.getpeername()] = match0
            
            print "\tPaired", match0.getpeername(), "with", match1.getpeername()

            match0.send(Pack(MESSAGE_SET_PLAYER1))
            match1.send(Pack(MESSAGE_SET_PLAYER2))
            match0.send(Pack(MESSAGE_NFO_FNDGAME))
            match1.send(Pack(MESSAGE_NFO_FNDGAME))
         
    server_socket.close()
