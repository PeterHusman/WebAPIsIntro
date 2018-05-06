using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIntro
{
    public partial class Test : System.Web.UI.Page
    {
        Random rnd = new Random();
        int number = 0;
        int guesses = 0;
        int stupidGuesses = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["number"] = rnd.Next(1, 101);
                Session["guesses"] = 0;
                Session["stupidGuesses"] = 0;
            }
            if (Session["usrName"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            stupidGuesses = (int)Session["stupidGuesses"];
            guesses = (int)Session["guesses"];
            number = (int)Session["number"];
            if(stupidGuesses >= 4)
            {
                Label1.Text = $"{Session["usrName"]}'s password is '{Session["password"]}'! Go away!";
                guess.Enabled = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userNum = 0;
            if (int.TryParse(TextBox1.Text, out userNum))
            {
                guesses++;
                if (userNum == number)
                {
                    Label1.Text = "Spot on, " + (string)Session["usrName"] + "! It only took you " + guesses.ToString() + " guesses. Choose something to do.";
                    restart.Visible = true;
                    restart.Enabled = true;
                    bTL.Enabled = true;
                    bTL.Visible = true;
                    guess.Enabled = false;
                }
                else
                {
                    Label1.Text = "Too " + (userNum > number ? "high" : "low") + ". Guess again!";
                }
                Session["guesses"] = guesses;
            }
            else
            {
                
                switch (stupidGuesses)
                {
                    case 0:
                        Label1.Text = $"{Session["usrName"]}, that's not a number! Guess again!";
                        break;
                    case 1:
                        Label1.Text = $"{Session["usrName"]}? Please?";
                        break;
                    case 2:
                        Label1.Text = "This is getting annoying! Do you want me to shout your password from the rooftops?!?";
                        break;
                    case 3:
                        Label1.Text = "This is your last warning!";
                        break;
                    default:
                        Label1.Text = $"{Session["usrName"]}'s password is '{Session["password"]}'! Go away!";
                        guess.Enabled = false;
                        break;
                }
                stupidGuesses++;
            }
            Session["stupidGuesses"] = stupidGuesses;
            TextBox1.Text = "";
        }

        protected void restart_Click(object sender, EventArgs e)
        {
            guesses = 0;
            Session["guesses"] = 0;
            number = rnd.Next(1, 101);
            Session["number"] = number;
            restart.Visible = false;
            restart.Enabled = false;
            bTL.Enabled = false;
            bTL.Visible = false;
            guess.Enabled = true;
            Label1.Text = "Guess a number from 1 to 100!";
            TextBox1.Text = "";
        }

        protected void bTL_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}