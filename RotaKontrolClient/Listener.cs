using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RotaKontrolClient
{
    public delegate void SocketDataReceived(string data);
    public class Listener
    {
        public event SocketDataReceived Received;
        public event Action Connected;

        private readonly IPEndPoint point;
        private readonly Socket socket;

        public Listener(IPEndPoint point)
        {
            this.point = point;

            socket = new Socket(point.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            {
                NoDelay = true,
                ReceiveTimeout = 0
            };
        }

        public void Close()
        {
            if (socket?.Connected ?? false)
                socket?.Close();
        }

        public void Connect(bool queueInThread)
        {
            socket.Connect(point);

            Connected?.Invoke();

            if (queueInThread)
                ThreadPool.QueueUserWorkItem((a) => Connect());
            else
                Connect();
        }

        public void Send(string data) =>
            socket.Send(Encoding.UTF8.GetBytes(data.Length + "," + data));

        private void Connect()
        {
            while (socket.Connected && socket.IsBound)
            {
                try
                {
                    byte[] buffer = new byte[1048576];
                    int received = socket.Receive(buffer);
                    string data = Encoding.UTF8.GetString(buffer);
                    Received?.Invoke(data.Substring(0, received).Replace("\0", ""));
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("yanıt"))
                        continue;
                    Debug.WriteLine(e.Message + " " + e.StackTrace);
                }
            }
        }
    }
}
