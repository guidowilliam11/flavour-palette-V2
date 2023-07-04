using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Checkout.Repository
{
    public class CheckoutRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public void clearCart(int userId)
        {
            List<Model.Cart> cartsToDelete = db.Carts.Where(c => c.UserID == userId).ToList();

            db.Carts.RemoveRange(cartsToDelete);
            db.SaveChanges();
        }

    }
}