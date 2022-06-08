using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VietShape
{
    public partial class clsServices
    {
        private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
        Thread thr;

        public string sReturn = "-1";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ReceiveData(IAsyncResult ar)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            Socket socket = (Socket)ar.AsyncState;
            int received = socket.EndReceive(ar);
            byte[] dataBuf = new byte[received];
            Array.Copy(receivedBuf, dataBuf, received);
            sReturn = (Encoding.ASCII.GetString(dataBuf));
            //rb_chat.AppendText("\nServer: " + lb_stt.Text);
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);

        }

        public bool SendLoop()
        {
            try
            {
                while (true)
                {
                    //Console.WriteLine("Enter a request: ");
                    //string req = Console.ReadLine();
                    //byte[] buffer = Encoding.ASCII.GetBytes(req);
                    //_clientSocket.Send(buffer);

                    byte[] receivedBuf = new byte[1024];
                    int rev = _clientSocket.Receive(receivedBuf);
                    if (rev != 0)
                    {
                        byte[] data = new byte[rev];
                        Array.Copy(receivedBuf, data, rev);
                        return true;
                        //= ("Received: " + Encoding.ASCII.GetString(data));

                    }
                    else _clientSocket.Close();

                }
            }
            catch { return false; }
        }

        private void Send(string sCheck)
        {
            if (_clientSocket.Connected)
            {

                byte[] buffer = Encoding.ASCII.GetBytes(sCheck);
                _clientSocket.Send(buffer);
            }

        }

        public void connect()
        {
            LoopConnect();
            // SendLoop();
            _clientSocket.BeginReceive(receivedBuf, 0, receivedBuf.Length, SocketFlags.None, new AsyncCallback(ReceiveData), _clientSocket);
            byte[] buffer = Encoding.ASCII.GetBytes("@@" + Commons.IConnections.Server);
            _clientSocket.Send(buffer);
        }


        private void LoopConnect()
        {
            int attempts = 0;
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    //_clientSocket.Connect(IPAddress.Loopback, 100);
                    _clientSocket.Connect(Commons.IConnections.Server, 65000);
                }
                catch (SocketException)
                {
                    //Console.Clear();
                    //lb_stt.Text = ("Connection attempts: " + attempts.ToString());
                }
            }
            //lb_stt.Text = ("Connected!");
        }

    }
}
