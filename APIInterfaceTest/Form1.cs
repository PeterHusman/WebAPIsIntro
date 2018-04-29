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
            HttpClient client = new HttpClient();
            await client.PostAsync("http://localhost:57109/api/msg/send", new StringContent($"{{\"Sender\": \"{name.Text}\",\"Message\": \"{msg.Text}\"}}", Encoding.UTF8, "application/json"));
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var histroy = await client.GetAsync("http://localhost:57109/api/msg/history");
            messageDisplay.Items.Clear();
            //messageDisplay.Items.AddRange((string[])(await histroy.Content.ReadAsByteArrayAsync()));
        }
    }
}
