import socket

print "Connecting"

s = socket.socket()
s.connect(("127.0.0.1", 5000))

print "Waiting for instructions..."

#s.close()
#s = None
