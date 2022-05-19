using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotaKontrolServer
{
    public partial class Main : Form
    {

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public static Main main;
        public static Communicator communicator;
        public static bool isSending = false;
        public static bool isSharingScreen = false;
        public static bool liveText = false;

        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            MouseDown += (a, b) =>
            {
                if (b.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, 0xA1, 0x2, 0);
                }
            };

            btnClose.Click += (a, b) => Environment.Exit(0);

            btnMsgSend.Click += (a, b) =>
            {
                Send((client) => client.Msg(txtMsgTitle.Text, txtMsgContent.Text));
                txtMsgTitle.Clear();
                txtMsgContent.Clear();
            };

            btnShutdown.Click += (a, b) => Send((client) => client.Shutdown());
            btnLock.Click += (a, b) => Send((client) => client.Lock());
            btnHibernate.Click += (a, b) => Send((client) => client.Hibernate());
            btnMinimize.Click += (a, b) => WindowState = FormWindowState.Minimized;
            btnCmdSend.Click += (a, b) =>
            {
                Send((client) => client.SendCommand(txtCommand.Text));
                txtCommand.Clear();
            };

            btnSelectFile.Click += (a, b) =>
            {
                OpenFileDialog dialog = new OpenFileDialog
                {
                    Title = "Bir dosya seç"
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                    txtFile.Text = dialog.FileName;
            };

            btnFileSend.Click += (a, b) =>
            {
                string file = txtFile.Text;
                if (!File.Exists(file))
                    return;
                if (lbSockets.SelectedItems.Count == 0)
                    return;
                isSending = true;
                ThreadPool.QueueUserWorkItem((sx) =>
                {
                    using (var stream = new FileStream(file, FileMode.Open))
                    {
                        foreach (var s in lbSockets.SelectedItems)
                        {
                            string f = s.ToString();
                            var client = communicator.clients.FirstOrDefault(x => (x.IP + " - " + x.Name) == f);
                            client.SendFile(stream, file, (x) => prgFile.Value = x, false);
                        }
                    }
                });
            };
            btnFileCancel.Click += (a, b) => isSending = false;

            btnRestart.Click += (a, b) => Send((client) => client.Restart());
            btnLiveScreenStop.Click += (a, b) =>
            {
                isSharingScreen = false;
                Send((client) => client.Send("endScreenShare"));
            };
            btnLiveScreenStart.Click += (a, b) =>
            {
                isSharingScreen = true;
                Send((client) => client.Send("beginScreenShare"));
                StartScreenShare();
            };

            btnLogout.Click += (a, b) => Send((client) => client.LogOff());
            btnLiveTextStart.Click += (a, b) =>
            {
                liveText = true;
                Send((client) => client.StartLiveText());
            };
            btnLiveTextStop.Click += (a, b) =>
            {
                liveText = false;
                Send((client) => client.StopLiveText());
                txtLiveText.Clear();
            };
            txtLiveText.TextChanged += (a, b) =>
            {
                if (liveText)
                    Send((client) => client.SendLiveText(txtLiveText.Text));
            };

            lblIP.Text = GetLocalIPAddress();

            communicator = new Communicator(lblIP.Text);
            communicator.ClientAdded += (a) => lbSockets.Items.Add(a.IP + " - " + a.Name);
            communicator.ClientRemoved += (a) => lbSockets.Items.Remove(a.IP + " - " + a.Name);
            communicator.Start();

            main = this;

            txtWidth.Text = Properties.Settings.Default.Width.ToString();
            txtHeight.Text = Properties.Settings.Default.Height.ToString();
        }

        public void StartScreenShare() =>
            new Thread(() =>
            {
                isSending = true;
                while (isSharingScreen)
                {
                    try
                    {

                        int w = int.Parse(txtWidth.Text);
                        int h = int.Parse(txtHeight.Text);
                        using (var stream = new MemoryStream())
                        {
                            using (var bitmap = new Bitmap(w, h, PixelFormat.Format32bppArgb))
                            {
                                using (var graphics = Graphics.FromImage(bitmap))
                                    graphics.CopyFromScreen(0, 0, 0, 0, new Size(w, h), CopyPixelOperation.SourceCopy);
                                bitmap.Save(stream, ImageFormat.Png);
                            }
                            isSending = true;
                            Send((client) => client.SendFile(stream, client.ScreenSocket, (a) => { }, false));
                            isSending = false;
                        }
                        
                        Thread.Sleep(50);
                    }
                    catch (Exception)
                    {

                    }
                }
                isSending = false;
            }).Start();

        private void Send(Action<Client> onFound)
        {
            if (lbSockets.SelectedItems.Count == 0)
                return;
            foreach (var s in lbSockets.SelectedItems)
            {
                string f = s.ToString();
                var client = communicator.clients.FirstOrDefault(x => (x.IP + " - " + x.Name) == f);
                onFound.Invoke(client);
            }
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostAddresses(Dns.GetHostName());
            return host.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork).ToString();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtWidth.Text, out int width))
                return;
            Properties.Settings.Default.Width = width;
            Properties.Settings.Default.Save();
        }

        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtHeight.Text, out int height))
                return;
            Properties.Settings.Default.Height = height;
            Properties.Settings.Default.Save();
        }
    }
}
