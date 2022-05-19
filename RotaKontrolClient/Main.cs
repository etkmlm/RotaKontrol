using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RotaKontrolClient
{
    public partial class Main : Form
    {

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        public static Communicator communicator;
        public static Main main;

        private bool changeMode = false;

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

            btnChange.Click += (a, b) =>
            {
                if (changeMode)
                {
                    Properties.Settings.Default.Password = CreatePassword(txtPassword.Text);
                    Properties.Settings.Default.Save();
                    txtPassword.Clear();
                    changeMode = false;
                }
                else
                {
                    if (Check(txtPassword.Text, Properties.Settings.Default.Password))
                    {
                        changeMode = true;
                        txtPassword.Clear();
                    }
                    else
                        Error("Yanlış şifre.");
                }
            };

            btnHide.Click += (a, b) => Hide();

            btnSave.Click += (a, b) =>
            {
                if (!changeMode)
                {
                    Error("Önce şifreyi onaylamalısınız.");
                    return;
                }

                Properties.Settings.Default.IP = txtIP.Text;
                Properties.Settings.Default.Save();
                communicator?.SetIP(txtIP.Text, 9000);
            };

            communicator = new Communicator();
            communicator.MainSocketDataReceived += ProcessData;
            communicator.ScreenSocketDataReceived += ProcessScreenData;
            communicator.FileSocketDataReceived += ProcessFileData;
            

            communicator.Start();

            main = this;

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.IP))
            {
                txtIP.Text = Properties.Settings.Default.IP;
                communicator.SetIP(Properties.Settings.Default.IP, 9000);
            }

            RegisterHotKey(Handle, 0, 0x0001 | 0x0002 | 0x0004, 0x74);

            Shown += (a, b) => Hide();
        }

        public static string CreatePassword(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
                return "";
            using (var sha256 = SHA256.Create())
                return string.Join("", sha256.ComputeHash(Encoding.UTF8.GetBytes(pass)).Select(x => x.ToString("x2")));
        }

        public static bool Check(string pass, string sha) =>
            CreatePassword(pass) == sha;

        public static void Error(string msg) =>
            MessageBox.Show(msg, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private bool receivingFile = false;
        public byte[] screen;
        private string _screen;
        private ScreenForm shareForm;
        private LiveTextForm liveForm;
        private FileStream fileStream;
        public void ProcessData(string data)
        {
            Debug.WriteLine(data);
            if (data.StartsWith("msgBox"))
            {
                string[] d = data.Substring(6).Split('|');
                ThreadPool.QueueUserWorkItem((a) => MessageBox.Show(d[1], d[0], MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
            else if (data.StartsWith("shutdown"))
                Process.Start("shutdown", "/s /t 0");
            else if (data.StartsWith("lock"))
                Process.Start(@"C:\Windows\System32\rundll32.exe", "user32.dll,LockWorkStation");
            else if (data.StartsWith("hibernate"))
                Application.SetSuspendState(PowerState.Hibernate, true, true);
            else if (data.StartsWith("cmd"))
                Process.Start("cmd.exe", "/c " + data.Substring(3));
            else if (data.StartsWith("beginSendFile"))
            {
                string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fileStream = new FileStream(desktop + "\\" + data.Substring(13), FileMode.OpenOrCreate);
                receivingFile = true;
            }
            else if (data.Contains("beginScreenShare"))
            {
                shareForm = new ScreenForm();
                ThreadPool.QueueUserWorkItem((a) => shareForm.ShowDialog());
            }
            else if (data.Contains("endScreenShare"))
            {
                shareForm?.Close();
                shareForm = null;
                screen = null;
                _screen = "";
                return;
            }
            else if (data.StartsWith("beginLiveText"))
            {
                liveForm = new LiveTextForm();
                ThreadPool.QueueUserWorkItem((a) => liveForm.ShowDialog());
            }
            else if (data.StartsWith("writeLiveText"))
                liveForm?.UpdateText(data.Substring(13));
            else if (data.StartsWith("endLiveText"))
            {
                liveForm.Close();
                liveForm = null;
            }
            else if (data.Contains("logout"))
                Process.Start("shutdown", "/l /t 0");
            else if (data.Contains("restart"))
                Process.Start("shutdown", "/d /t 0");
        }

        public void ProcessScreenData(string data)
        {
            if (shareForm == null)
                return;
            if (data.Contains("end"))
            {
                screen = GetHexadecimal(_screen);
                _screen = "";
                shareForm.UpdateScreen(screen);
            }
            else
                _screen += data;
        }
        public void ProcessFileData(string data)
        {
            if (!receivingFile || string.IsNullOrWhiteSpace(data))
                return;
            if (data.Contains("end"))
            {
                receivingFile = false;
                fileStream?.Close();
                return;
            }
            byte[] buffer = GetHexadecimal(data);
            fileStream.Write(buffer, 0, buffer.Length);
        }

        public byte[] GetHexadecimal(string hex)
        {
            int len = hex.Length / 2;
            byte[] buffer = new byte[len];
            string f;
            try
            {
                for (int i = 0; i < len; i++)
                {
                    int first = i * 2;
                    f = hex[first] + "" + hex[first + 1];
                    buffer[i] = (byte)int.Parse(f, System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception)
            {

            }
            return buffer;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam == IntPtr.Zero)
                Show();
            base.WndProc(ref m);
        }
    }
}
