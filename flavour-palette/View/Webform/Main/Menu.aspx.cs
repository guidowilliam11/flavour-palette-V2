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
    public partial class Menu : System.Web.UI.Page
    {
        private CatalogController cc = new CatalogController();
        private CartController ccr = new CartController();
        private InventoryController ic = new InventoryController();
        protected void Page_Load(object sender, EventArgs e)
        {
            availableFoodRepeater.DataSource = cc.getAvailableFood();
            availableFoodRepeater.DataBind();

            archivedFoodRepeater.DataSource = cc.getArchivedFood();
            archivedFoodRepeater.DataBind();

            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                if (!Page.IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"].ToString());
                    Food f = ic.getFoodDetail(id);
                    tbName.Text = f.FoodName;
                    tbPrice.Text = f.FoodPrice.ToString();
                    tbDescription.Text = f.FoodDescription;
                    if(f.FoodStatus == "Available") rbStatus.SelectedValue = "Available";
                    else rbStatus.SelectedValue = "Archive";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int price;
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"].ToString());

                if (int.TryParse(tbPrice.Text, out price))
                {

                    lbError.Text = ic.updateFood(id, fuImage, tbName.Text, price, tbDescription.Text, rbStatus.SelectedValue);
                    Response.Redirect("Menu.aspx");
                    return;
                }
                else
                {
                    lbError.Text = "Menu's price must be number";
                }
            }

            if (int.TryParse(tbPrice.Text, out price))
            {
                lbError.Text = ic.addFood(fuImage, tbName.Text, price, tbDescription.Text, rbStatus.SelectedValue);
                Response.Redirect(Request.Url.AbsoluteUri);
                return;
            }
            else
            {
                lbError.Text = "Menu's price must be number";
            }

            return;
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int userId = (int)HttpContext.Current.Session["userId"];

            Button btn = (Button)sender;
            int foodId = Convert.ToInt32(btn.CommandArgument);
            ccr.insertCart(userId, foodId, 1);
        }
    }
}