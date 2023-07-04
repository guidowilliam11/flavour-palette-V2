using flavour_palette.User_Management.Authentication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
            private AuthenticationController ac = new AuthenticationController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpCookie userCookie = Request.Cookies["UserData"];

                if (userCookie != null)
                {
                    string username = userCookie.Values["email"];
                    string password = userCookie.Values["password"];

                    Debug.WriteLine(username, password);
                    if (ac.doRemember(username, password) == true)
                    {
                        Response.Redirect("../Main/Home.aspx");
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text;
            string password = tbPassword.Text;

            lbError.Text = ac.doLogin(email, password, cbRemember);

            if (lbError.Text == "")
            {
                Response.Redirect("../Main/Home.aspx");
            }
        }
    }
}