using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace CityTools.Components {
    public partial class Debugger : Form {
        private Socket m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        public Debugger() {
            InitializeComponent();

            m_Listener.Bind(new IPEndPoint(IPAddress.Loopback, 8888));
            m_Listener.Listen(16);
            m_Listener.BeginAccept(AcceptCallback, null);
        }

        public void Test() {
            
        }

        private void AcceptCallback(IAsyncResult ar) {
            Socket s = m_Listener.EndAccept(ar);
            m_Listener.Close();
            /* Use s here. */
        }
    }
}
