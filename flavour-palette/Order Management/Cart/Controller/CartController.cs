using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Cart
{
    public class CartController
    {
        CartHandler ch = new CartHandler();

        public List<Model.Cart> getCart(int userId)
        {
            return ch.getUserCart(userId);
        }

        public void insertCart(int userId, int foodId, int qty)
        {
            ch.insertCart(userId, foodId, qty);
        }

        public void deleteCart(int userId, int foodId)
        {
            ch.deleteCart(userId, foodId);
        }

        public Model.Cart findSameFood(int userId, int foodId)
        {
            return ch.findSameFood(userId, foodId);
        }

        public void updateQty(int userId, int foodId, int newQty)
        {
            ch.updateQty(userId, foodId, newQty);
        }

       public int getCartQty(int userId, int foodId)
        {
            return ch.getCartQty(userId, foodId);
        }

    }
}