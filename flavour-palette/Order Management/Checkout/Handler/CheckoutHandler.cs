using flavour_palette.Order_Management.Checkout.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Checkout
{
    public class CheckoutHandler
    {
        private CheckoutRepository cr = new CheckoutRepository();
        public void clearCart(int userId)
        {
            cr.clearCart(userId);
        }
    }
}