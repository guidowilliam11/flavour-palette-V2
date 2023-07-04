using Model = flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Cart
{
    public class CartFactory
    {
        public Model.Cart create(int userId, int foodId, int quantity)
        {
            Model.Cart cart = new Model.Cart();

            cart.UserID = userId;
            cart.FoodID = foodId;
            cart.Qty = quantity;

            return cart;
        }
    }
}