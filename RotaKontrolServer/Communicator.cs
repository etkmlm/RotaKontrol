using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RotaKontrolServer
{
    public delegate void ClientEvent(Client client);
    public class Communicator
    {
        public readonly List<Client> clients;
        public const int PORT = 9000;
        private readonly Socket mainSocket;
        private readonly Socket screenSocket;
        private readonly Socket fileSocket;

        public event ClientEvent ClientAdded;
        public event ClientEvent ClientRemoved;

        public Communicator(string ip)
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Parse(ip), PORT);
            IPEndPoint point2 = new IPEndPoint(IPAddress.Parse(ip), PORT + 1);
            IPEndPoint point3 = new IPEndPoint(IPAddress.Parse(ip), PORT + 2);
            mainSocket = new Socket(point.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            screenSocket = new Socket(point2.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            fileSocket = new Socket(point3.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            screenSocket.Bind(point2);
            screenSocket.Listen(0);
            fileSocket.Bind(point3);
            fileSocket.Listen(1);
            mainSocket.Bind(point);
            mainSocket.Listen(2);
            clients = new List<Client>();
        }

        public void Start() =>
             new Thread(() =>
             {
                 while (true)
                 {
                     var socket = mainSocket.Accept();
                     var socket2 = screenSocket.Accept();
                     var socket3 = fileSocket.Accept();
                     socket.NoDelay = true;
                     ThreadPool.QueueUserWorkItem((a) =>
                     {
                         Client c = new Client { MainSocket = socket, ScreenSocket = socket2, FileSocket = socket3 };
                         clients.Add(c);
                         byte[] buffer = new byte[2048];
                         while (socket.Connected && socket.IsBound)
                         {
                             try
                             {
                                 socket.Receive(buffer);
                                 string[] d = Encoding.UTF8.GetString(buffer).Split(new char[] { ',' }, 2);
                                 string data = d[1].Substring(0, int.Parse(d[0]));
                                 if (data.StartsWith("id"))
                                 {
                                     string[] b = data.Substring(2).Split('|');
                                     c.IP = b[0];
                                     c.Name = b[1];
                                     ClientAdded?.Invoke(c);
                                 }
                             }
                             catch(Exception)
                             {

                             }
                         }
                         ClientRemoved?.Invoke(c);
                         clients.Remove(c);
                     });
                     Thread.Sleep(1000);
                 }
             }).Start();
    }

    public class Client
    {
        public Socket MainSocket { get; set; }
        public Socket ScreenSocket { get; set; }
        public Socket FileSocket { get; set; }
        public string IP { get; set; }
        public string Name { get; set; }

        public void Send(string msg)
        {
            try
            {
                MainSocket?.Send(Encoding.UTF8.GetBytes(msg));
            }
            catch (Exception)
            {
                
            }
        }
        public void Shutdown() =>
            Send("shutdown");

        public void LogOff() =>
            Send("logout");
        public void Msg(string title, string content) =>
            Send("msgBox" + title + "|" + content);

        public void Lock() =>
            Send("lock");
        public void Hibernate() =>
            Send("hibernate");

        public void SendCommand(string cmd) =>
            Send("cmd" + cmd);
        public void SendFile(FileStream stream, string fileName, Action<int> progressChanged, bool closeStream = true)
        {
            Send("beginSendFile" + Path.GetFileName(fileName));
            Main.isSending = true;
            SendFile(stream, FileSocket, progressChanged, closeStream);
            Main.isSending = false;
        }

        public void StartLiveText() =>
            Send("beginLiveText");
        public void StopLiveText() =>
           Send("endLiveText");

        public void SendLiveText(string text) =>
           Send("writeLiveText" + text);

        public void SendFile(Stream stream, Socket socket, Action<int> progressChanged, bool closeStream = true)
        {
            try
            {
                stream.Seek(0, SeekOrigin.Begin);
                long len = stream.Length;
                double per = (double)100 / len;
                double perc = 0;
                byte[] buffer = new byte[16384];
                int read;

                int count = (int)stream.Length / buffer.Length;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0 && Main.isSending)
                {
                    perc += read * per;
                    progressChanged.Invoke((int)perc);
                    string ax = string.Join("", buffer.Select(x => x.ToString("x2")));
                    buffer = new byte[16384];
                    try
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(ax);
                        socket?.Send(bytes);
                    }
                    catch (Exception)
                    {

                    }
                    Thread.Sleep(10);
                }
                byte[] b = Encoding.UTF8.GetBytes("end");
                socket?.Send(b);
                progressChanged.Invoke(0);
                if (closeStream)
                    stream.Close();
            }
            catch (OutOfMemoryException)
            {

            }
        }

        public void Restart() =>
            Send("restart");

        public void Disconnect() =>
            MainSocket?.Close();
    }
}
