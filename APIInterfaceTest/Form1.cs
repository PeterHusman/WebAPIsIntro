using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace APIInterfaceTest
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

        private async void send_Click(object sender, EventArgs e)
        {
            if(msg.Text.Trim() == "" || name.Text.Trim() == "")
            {
                return;
            }
            HttpClient client = new HttpClient();
            await client.PostAsync("http://localhost:57109/api/msg/send", new StringContent($"{{\"Sender\": \"{name.Text.Trim()}\",\"Message\": \"{msg.Text.Trim()}\"}}", Encoding.UTF8, "application/json"));
            msg.Text = "";
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var histroy = await client.GetAsync("http://localhost:57109/api/msg/history");
            if (!histroy.IsSuccessStatusCode)
            {
                return;
            }
            string temp = await histroy.Content.ReadAsStringAsync();
            Msg[] msgs = JsonConvert.DeserializeObject<Msg[]>(temp);
            bool stayAtBottom = messageDisplay.SelectedIndex == messageDisplay.Items.Count - 1;
            if (msgs.Length > messageDisplay.Items.Count)
            {
                for (int i = messageDisplay.Items.Count; i < msgs.Length; i++)
                {
                    messageDisplay.Items.Add(msgs[i].ToString());
                }
            }
            if (stayAtBottom)
            {
                messageDisplay.SelectedIndex = messageDisplay.Items.Count - 1;
            }

            //messageDisplay.Items.AddRange((string[])(await histroy.Content.ReadAsByteArrayAsync()));
        }

        private void msg_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        
        private void msg_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void msg_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                send_Click(send,null);
            }
        }
    }

    public class Msg
    {
        public string Sender { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return $"{Sender}: {Message}";
        }
    }
}
