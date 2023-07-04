
using flavour_palette.User_Management.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Authentication
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
              
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string email = tbEmail.Text;
            string address = tbAddress.Text;
            string password = tbPassword.Text;
            string confPassword = tbPasswordConf.Text;
            string gender = rbGender.SelectedValue;

            AuthenticationController cc = new AuthenticationController();
            lbError.Text = cc.doRegister(name, email, address, password, confPassword, gender);

            if (lbError.Text == "")
            {
                Response.Redirect("Login.aspx");
            }
        }

    }
}