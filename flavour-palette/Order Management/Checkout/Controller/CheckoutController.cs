using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Checkout
{
    public class CheckoutController
    {
        CheckoutHandler ch = new CheckoutHandler();
        public void clearCart(int userId)
        {
            ch.clearCart(userId);
        }
    }
}