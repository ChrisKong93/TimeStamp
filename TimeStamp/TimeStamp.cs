using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Time
{
    public partial class TimeStamp : Form
    {
        public TimeStamp()
        {
            InitializeComponent();
            timer1.Start();
            button3.Text = "暂停";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("输入框不能为空");
            }
            else
            {
                long unixTimeStamp = long.Parse(textBox1.Text.Trim());
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                DateTime dt = startTime.AddSeconds(unixTimeStamp);
                //System.Console.WriteLine(dt.ToString("yyyy/MM/dd HH:mm:ss:ffff"));
                this.label1.Text = dt.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("输入框不能为空");
            }
            else
            {
                long unixTimeStamp = long.Parse(textBox1.Text.Trim());
                System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                DateTime dt = startTime.AddMilliseconds(unixTimeStamp);
                this.label1.Text = dt.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
            long timeStamps = (long)(DateTime.Now - startTime).TotalSeconds; // 相差秒数
            long timeStampms = (long)(DateTime.Now - startTime).TotalMilliseconds;
            //System.Console.WriteLine(timeStamp);
            this.label2.Text = "当前时间:" + DateTime.Now.ToString();
            this.label3.Text = "当前时间戳(秒):" + timeStamps;
            this.label4.Text = "当前时间戳(毫秒):" + timeStampms;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "暂停")  
            {
                timer1.Stop();
                button3.Text = "开始";
                return;
            }
            else if (button3.Text == "开始")
            {
                timer1.Start();
                button3.Text = "暂停";
                return;
            }
        }
    }
}
