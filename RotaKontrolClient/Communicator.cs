using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace RotaKontrolClient
{
    
    public class Communicator
    {
        private Listener mainSocket;
        private Listener screenSocket;
        private Listener fileSocket;
        private string ip;
        private int port;

        public event SocketDataReceived MainSocketDataReceived;
        public event SocketDataReceived ScreenSocketDataReceived;
        public event SocketDataReceived FileSocketDataReceived;

        public void SetIP(string ip, int port)
        {
            mainSocket?.Close();
            screenSocket?.Close();
            fileSocket?.Close();

            this.ip = ip;
            this.port = port;
        }

        public void Start() =>
            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Main.main.lblState.Text = "Bağlantı deneniyor...";
                        if (this.ip == null)
                        {
                            Main.main.lblState.Text = "Soket geçersiz.";
                            Thread.Sleep(1000);
                            continue;
                        }
                        screenSocket = new Listener(new IPEndPoint(IPAddress.Parse(this.ip), port + 1));
                        screenSocket.Received += ScreenSocketDataReceived;
                        screenSocket.Connect(true);

                        fileSocket = new Listener(new IPEndPoint(IPAddress.Parse(this.ip), port + 2));
                        fileSocket.Received += FileSocketDataReceived;
                        fileSocket.Connect(true);

                        mainSocket = new Listener(new IPEndPoint(IPAddress.Parse(this.ip), port));
                        mainSocket.Received += MainSocketDataReceived;

                        string ip = GetLocalIPAddress();
                        mainSocket.Connected += () => mainSocket.Send("id" + ip + "|" + Environment.MachineName);

                        Main.main.lblState.Text = "Bağlandı.";
                        mainSocket.Connect(false);
                        
                    }
                    catch(Exception e)
                    {
                        Main.main.lblState.Text = "Hata";
                    }
                    Thread.Sleep(1000);
                }
            }).Start();

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostAddresses(Dns.GetHostName());
            return host.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork).ToString();
        }
    }
}
