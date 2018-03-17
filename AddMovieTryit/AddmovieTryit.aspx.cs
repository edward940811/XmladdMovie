using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AddMovieTryit.ServiceReference1;
using AddMovieTryit.ServiceReference2;

namespace AddMovieTryit
{
    public partial class AddmovieTryit : System.Web.UI.Page
    {
        ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
        ServiceReference2.Service1Client client2 = new ServiceReference2.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           client.AddMovie(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text
                ,TextBox7.Text , TextBox5.Text, TextBox6.Text);

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           SearchOutput.Text =  client2.Getnode( urlBox.Text , Key.Text);
        }
    }
}