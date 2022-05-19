using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotaKontrolClient
{
    public partial class ScreenForm : Form
    {
        public ScreenForm()
        {
            InitializeComponent();
        }

        public void UpdateScreen(byte[] buffer)
        {
            if (buffer == null)
                return;
            try
            {
                using(var ms = new MemoryStream())
                {
                    ms.Write(buffer, 0, buffer.Length);
                    pbScreen.Image = Image.FromStream(ms);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
