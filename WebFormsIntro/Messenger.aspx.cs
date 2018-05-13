using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIntro
{
    public partial class Messenger : System.Web.UI.Page
    {
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["name"] != null)
            {
                name.Text = (string)Session["name"];
            }
            if(Session["msg"] != null)
            {
                msg.Text = (string)Session["msg"];
                msg.Focus();
            }
        }

        protected async void timer_Tick(object sender, EventArgs e)
        {
            if(count > 100)
            {
                Session["name"] = name.Text;
                Session["msg"] = msg.Text;
                Response.Redirect("Messenger.aspx");
            }
            count++;
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
                    if (msgs[i] != null) { messageDisplay.Items.Add(msgs[i].ToString()); }
                }
            }
            if (stayAtBottom)
            {
                messageDisplay.SelectedIndex = messageDisplay.Items.Count - 1;
            }
        }

        protected async void send_Click(object sender, EventArgs e)
        {
            if (msg.Text.Trim() == "" || name.Text.Trim() == "")
            {
                return;
            }
            HttpClient client = new HttpClient();
            await client.PostAsync("http://localhost:57109/api/msg/send", new StringContent(JsonConvert.SerializeObject(new Msg(msg.Text,name.Text)), Encoding.UTF8, "application/json"));
            msg.Text = "";
            msg.Focus();
        }

        public class Msg
        {
            public Msg(string msg, string name)
            {
                Sender = name;
                Message = msg;
            }

            public string Sender { get; set; }
            public string Message { get; set; }
            public override string ToString()
            {
                return $"{Sender}: {Message}";
            }
        }
    }
}