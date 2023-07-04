using flavour_palette.Food_Management.Catalog;
using flavour_palette.Food_Management.Inventory;
using flavour_palette.Model;
using flavour_palette.Order_Management.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Main
{
    public partial class MenuDetail : System.Web.UI.Page
    {
        private InventoryController ic = new InventoryController();
        private CatalogController cc = new CatalogController();
        private CartController ccr = new CartController();
        public String imageName;
        protected void Page_Load(object sender, EventArgs e)
        {
            foodRepeater.DataSource = cc.getAvailableFood();
            foodRepeater.DataBind();

            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Food f = ic.getFoodDetail(id);
            imageName = f.FoodImage;
            lbName.Text = f.FoodName;
            lbName2.Text = f.FoodName;
            lbPrice.Text = "Rp" + string.Format("{0:N2}", f.FoodPrice);
            lbDescription.Text = f.FoodDescription;
            price.Text = f.FoodPrice.ToString();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int userId = (int)HttpContext.Current.Session["userId"];

            Button btn = (Button)sender;
            int foodId = Convert.ToInt32(Request.QueryString["id"].ToString());
            ccr.insertCart(userId, foodId, int.Parse(quantity.Text));

            Response.Redirect("Home.aspx");
        }
    }
}