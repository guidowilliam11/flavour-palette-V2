using flavour_palette.Order_Management.Cart;
using flavour_palette.Order_Management.Checkout;
using flavour_palette.Order_Management.Order_History;
using flavour_palette.Payment.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace flavour_palette.View.Webform.Main
{
    public partial class Payment : System.Web.UI.Page
    {
        private CartController cc = new CartController();
        private PaymentController pc = new PaymentController();
        private CheckoutController ckc = new CheckoutController();
        private OrderController oc = new OrderController();
        public List<Model.Cart> carts = new List<Model.Cart>();
        public int userId = 0;
        public int totalAmount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            userId = (int)HttpContext.Current.Session["userId"];
            carts = cc.getCart(userId);
            cartRepeater.DataSource = carts;
            cartRepeater.DataBind();

            if (!IsPostBack)
            {
                totalAmount = GetTotalAmount();
                totalAmountLiteral.Text = totalAmount.ToString();
            }
        }

        protected int GetTotalAmount()
        {
            int totalAmount = 0;

            foreach (Model.Cart c in carts)
            {   
                totalAmount += (int)c.Qty * (int)c.Food.FoodPrice;
            }

            return totalAmount;
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            string address = addressInput.Text.Trim();

            if (string.IsNullOrEmpty(address))
            {
                addressErrorLabel.Visible = true;
                return;
            }

            addressErrorLabel.Visible = false;
            pc.insertNewPayment(int.Parse(paymentMethod.SelectedValue), GetTotalAmount(), DateTime.Now.ToString("yyyy-MM-dd"));
            oc.insertTh(userId, pc.getLatestPaymentId(), DateTime.Now.ToString("yyyy-MM-dd"), "In Progress");

            foreach (Model.Cart c in carts)
            {
                oc.insertTd(oc.getLastThID(), c.FoodID, (int)c.Qty);
            }

            ckc.clearCart(userId);
            Response.Redirect("Home.aspx");
        }
    }
}