using flavour_palette.User_Management.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform
{
    public partial class Logout : System.Web.UI.Page
    {
        private AuthenticationController ac = new AuthenticationController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ac.logout();
            Response.Redirect("Authentication/Login.aspx");
        }
    }
}