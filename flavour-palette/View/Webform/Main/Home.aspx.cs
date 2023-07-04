using flavour_palette.Food_Management.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Main
{
    public partial class Home : System.Web.UI.Page
    {
        private CatalogController cc = new CatalogController();
        protected void Page_Load(object sender, EventArgs e)
        {
            foodRepeater.DataSource = cc.getAvailableFood().Take(5);
            foodRepeater.DataBind();
        }
    }
}