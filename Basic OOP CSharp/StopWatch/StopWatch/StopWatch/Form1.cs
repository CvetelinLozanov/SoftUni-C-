using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //required for dll import

namespace StopWatch
{
    public partial class Form1 : Form
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEY_ID = 0;

        int timeMil, timeSec, timeMin;
        bool isActive;

        public Form1()
        {
            // Modifier keys codes: Alt = 1, Ctrl = 2, Shift = 4, Win = 8
            // Compute the addition of each combination of the keys you want to be pressed
            // ALT+CTRL = 1 + 2 = 3 , CTRL+SHIFT = 2 + 4 = 6...
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0, (int)Keys.F10);

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                isActive = true;
                ResetTime();
            }
            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isActive)
            {
                timeMil++;

                if(timeMil >= 1)
                {
                    timeSec++;
                    timeMil = 0;

                    if(timeSec >= 60)
                    {
                        timeMin++;
                        timeSec = 0;
                    }
                }
            }

            DrawTime();
        }

        private void DrawTime()
        {
            lblSec.Text = String.Format("{0:00}", timeSec);
            lblMin.Text = String.Format("{0:00}", timeMin);
        }

        private void LblSec_Click(object sender, EventArgs e)
        {

        }

        private void LblMin_Click(object sender, EventArgs e)
        {

        }

        private void ResetTime()
        {
            timeMil = 0;
            timeSec = 0;
            timeMin = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            ResetTime();
        }
    }
}
