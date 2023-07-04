using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using Model = flavour_palette.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Cart.Repository
{
    public class CartRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public void add(int userId, int foodId, int quantity)
        {
            CartFactory cf = new CartFactory();
            Model.Cart c = cf.create(userId, foodId, quantity);

            db.Carts.Add(c);
            db.SaveChanges();
        }

        public List<Model.Cart> fetchAll()
        {
            return (from cart in db.Carts select cart).ToList();
        }

        public List<Model.Cart> fetchByuser(int id)
        {
            return (from cart in db.Carts where cart.UserID == id select cart).ToList();
        }

        public List<Model.Cart> fetchByFood(int id)
        {
            return (from cart in db.Carts where cart.FoodID == id select cart).ToList();
        }

        public Model.Cart search(int userId, int foodId)
        {
            return (from cart in db.Carts where cart.UserID == userId && cart.FoodID == foodId select cart).FirstOrDefault();
        }

        public void delete(int userId, int foodId)
        {
            Model.Cart c = search(userId, foodId);
            db.Carts.Remove(c);
            db.SaveChanges();
        }

        public void update(int userId, int foodId, int quantity)
        {
            Model.Cart c = search(userId, foodId);
            c.UserID = userId;
            c.FoodID = foodId;
            c.Qty = quantity;

            db.SaveChanges();
        }

        public void updateQty(int userId, int foodId, int newQty)
        {
            Model.Cart c = search(userId, foodId);
            c.Qty = newQty;

            db.SaveChanges();
        }

        public int getCartQty(int userId, int foodId)
        {
            Model.Cart c = search(userId, foodId);
            return (int)c.Qty;
        }
    }
}