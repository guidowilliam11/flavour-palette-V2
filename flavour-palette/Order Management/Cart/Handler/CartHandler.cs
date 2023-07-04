using flavour_palette.Order_Management.Cart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Cart
{
    public class CartHandler
    {
        private CartRepository cr = new CartRepository();

        public void insertCart(int userId, int foodId, int qty)
        {
            cr.add(userId, foodId, qty);
        }

        public List<Model.Cart> getUserCart(int userId)
        {
            return cr.fetchByuser(userId);
        }

        public void deleteCart(int userId, int foodId)
        {
            cr.delete(userId, foodId);
        }

        public Model.Cart findSameFood(int userId, int foodId)
        {
            return cr.search(userId, foodId);
        }

        public void updateQty(int userId, int foodId, int newQty)
        {
            cr.updateQty(userId, foodId, newQty);
        }

        public int getCartQty(int userId, int foodId)
        {
            return cr.getCartQty(userId, foodId);
        }
    }
}