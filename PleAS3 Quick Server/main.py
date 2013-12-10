# LORgames PleAS3 Matchmaking Server
# Additionally has much of the code required for the game server for prototyping

import socket, select
import cStringIO
import struct
import datetime

RECV_BUFFER = 4096      # Advisable to keep it as an exponent of 2
MMAKE_PORT = 5000       # The matchmaking server port
SECPL_PORT = 5187       # The flash policy server port

SECURITYCK_LIST = []    # list of socket clients WAITING FOR POLICY
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

    policy_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    policy_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1) # this has no effect, why ?
    policy_socket.bind(("0.0.0.0", SECPL_PORT))
    policy_socket.listen(10)
 
    # Add server socket to the list of readable connections
    CONNECTION_LIST.append(server_socket)
    CONNECTION_LIST.append(policy_socket)
 
    print "Matchmaking Server started on port " + str(MMAKE_PORT)
    print "Security Policy Server started on port " + str(SECPL_PORT)
 
    while 1:
        # Get the list sockets which are ready to be read through select
        gaming_sockets,write_blank,write_blank = select.select(CONNECTION_LIST,[],[])
        
        for sock in gaming_sockets:
            #New connection
            if sock == server_socket:
                # Handle the case in which there is a new connection recieved through server_socket
                sockfd, addr = server_socket.accept()
                CONNECTION_LIST.append(sockfd)
                print "[GAMING] Client (%s, %s) connected" % addr

                if len(IN_QUEUE) > 0:
                    match = IN_QUEUE.pop()
                    MATCHES[sockfd.getpeername()] = match
                    MATCHES[match.getpeername()] = sockfd
                    
                    print "\tPaired", sockfd.getpeername(), "with", match.getpeername()

                    match.send(Pack(MESSAGE_SET_PLAYER1))
                    sockfd.send(Pack(MESSAGE_SET_PLAYER2))
                    match.send(Pack(MESSAGE_NFO_FNDGAME))
                    sockfd.send(Pack(MESSAGE_NFO_FNDGAME))
                else:
                    IN_QUEUE.append(sockfd)
                    print "\tNo one is waiting just yet..."

            #A client is connecting to make sure this server is safe
            elif sock == policy_socket:
                sockfd, addr = policy_socket.accept()
                SECURITYCK_LIST.append(sockfd)
                print "[POLICY] Client (%s, %s) connected" % addr
                
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
                            print "Not sure, but", sock.getpeername(), "appears to be trying to send data to the server? Message=", data
                        ##sock.send('OK ... ' + data)
                    else:
                        #Throw exception so that the socket is cleaned up :)
                        raise Exception()
                
                # client disconnected, so remove from socket list
                except Exception, e:
                    print "[EXCEPT] "+`e`
                    ProcessSocketClosed(sock)
                    continue

        #now do basically the same thing for the security sockets
        if len(SECURITYCK_LIST) > 0:
            policy_sockets,write_blank,error_blank = select.select(SECURITYCK_LIST,[],[])

            for sock in policy_sockets:
                # Data recieved from client, process it
                try:
                    #In Windows, sometimes when a TCP program closes abruptly,
                    # a "Connection reset by peer" exception will be thrown
                    data = sock.recv(RECV_BUFFER)
                    # echo back the client message
                    if data:
                        sock.send("<cross-domain-policy><allow-access-from domain=\"*\" to-ports=\"5000\" /></cross-domain-policy>\x00");
                        sock.flush()
                        raise Exception()
                    else:
                        #Throw exception so that the socket is cleaned up :)
                        raise Exception()
                
                # client disconnected, so remove from socket list
                except Exception, e:
                    print "[POLICY] Client (%s, %s) disconnected! ("+`e`+")"  % sock.getpeername()
                    sock.close()
                    SECURITYCK_LIST.remove(sock)
                    continue
         
    server_socket.close()
    policy_socket.close()
