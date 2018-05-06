using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsIntro
{
    public partial class MainPage : System.Web.UI.Page
    {
        //int number = 0;
        //Random rnd = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Session["randNum"] = rnd.Next(1, 21);
            //}
                            

            //number = (int)Session["randNum"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = number.ToString();
            //Response.Redirect("Test.aspx");            
            Session["usrName"] = usrName.Text;
            Session["password"] = pass.Text;
            Response.Redirect("Game.aspx");
        }
    }
}