using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotaKontrolClient
{
    public partial class LiveTextForm : Form
    {
        public LiveTextForm()
        {
            InitializeComponent();
        }

        public void UpdateText(string text)
        {
            txtText.Text = text.Trim('0', '\0');
        }
    }
}
