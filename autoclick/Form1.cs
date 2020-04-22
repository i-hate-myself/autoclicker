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

namespace autoclick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        bool going = true;
        public void click(int xhk, int yhk)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, xhk, yhk, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xhk, yhk, 0, 0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (fixedmode == false)
                {
                    if (safemode)
                    {
                        going = true;
                        wait(Int32.Parse(textBox1.Text + "000"));
                        while (going)
                        {
                            wait(1);
                            click(Cursor.Position.X, Cursor.Position.Y);
                        }
                    }
                    if (safemode != true)
                    {
                        going = true;
                        wait(Int32.Parse(textBox1.Text + "000"));
                        while (going)
                        {
                            click(Cursor.Position.X, Cursor.Position.Y);
                        }
                    }
                }
                else
                {
                    if (safemode)
                    {
                        going = true;
                        wait(Int32.Parse(textBox1.Text + "000"));
                        while (going)
                        {
                            wait(1);
                            click(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                        }
                    }
                    if (safemode != true)
                    {
                        going = true;
                        wait(Int32.Parse(textBox1.Text + "000"));
                        while (going)
                        {
                            click(Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("oooh someone cant wait can they", "ooooooh owo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            //Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        [DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002; /* left button down */
        private const int MOUSEEVENTF_LEFTUP = 0x0004; /* left button up */
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention= CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons,
    int dwExtraInfo);

        private void button2_Click(object sender, EventArgs e)
        {
            going = false;
        }
        bool safemode = true;

        private void button3_Click(object sender, EventArgs e)
        {
            if (safemode)
            {
                safemode = false;
                button3.Text = "safe mode off";
            }
            else 
            {
                safemode = true;
                button3.Text = "safe mode on";
            }
        }
        bool fixedmode = false;
        private void button4_Click(object sender, EventArgs e)
        {
            if (fixedmode == false)
            {
                fixedmode = true;
                button4.Text = "fixedmode on";
                textBox2.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                fixedmode = false;
                button4.Text = "fixedmode off";
                textBox2.Visible = false;
                textBox3.Visible = false;
            }

        }
    }
}
