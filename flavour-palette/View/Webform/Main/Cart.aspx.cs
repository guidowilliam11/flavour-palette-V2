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
    public partial class Cart : System.Web.UI.Page
    {
        private CartController cc = new CartController();
        public List<Model.Cart> carts = new List<Model.Cart>();
        public List<Food> cartFoodInfo = new List<Food>();
        public int userId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (int)HttpContext.Current.Session["userId"];
            carts = cc.getCart(userId);
            cartRepeater.DataSource = carts;
            cartRepeater.DataBind();

            if (!IsPostBack)
            {
                int totalAmount = GetTotalAmount();
                totalAmountLiteral.Text = "Rp"+String.Format("{0:N2}", totalAmount);
            }
        }

        protected int GetTotalAmount()
        {
            int totalAmount = 0;

            foreach (Model.Cart c in carts)
            {
                System.Diagnostics.Debug.WriteLine((int)c.Qty);
                System.Diagnostics.Debug.WriteLine((int)c.Food.FoodPrice);
                
                System.Diagnostics.Debug.WriteLine("________________");
                totalAmount += (int)c.Qty * (int)c.Food.FoodPrice;
            }

            return totalAmount;
        }

        protected void button_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Decrease")
            {
                string argument = e.CommandArgument.ToString();
                string[] values = argument.Split('|');
                int foodId = int.Parse(values[0]);
                int qty = int.Parse(values[1]);

                System.Diagnostics.Debug.WriteLine("Decrease - FoodID: " + foodId + ", Qty: " + qty);
                cc.updateQty(userId, foodId, qty - 1);
            }
            else if (e.CommandName == "Increase")
            {
                string argument = e.CommandArgument.ToString();
                string[] values = argument.Split('|');
                int foodId = int.Parse(values[0]);
                int qty = int.Parse(values[1]);

                System.Diagnostics.Debug.WriteLine("Increase - FoodID: " + foodId + ", Qty: " + qty);
                cc.updateQty(userId, foodId, qty + 1);
            }
            Response.Redirect(Request.RawUrl);
        }

        protected void checkoutButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }
    }
}