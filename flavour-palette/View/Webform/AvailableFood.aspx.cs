using flavour_palette.Food_Management.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Main
{
    public partial class DeleteFood : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            InventoryController ic = new InventoryController();
            ic.availableFood(id);
            Response.Redirect("Main/Menu.aspx");
        }
    }
}