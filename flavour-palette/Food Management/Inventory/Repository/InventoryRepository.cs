using flavour_palette.Food_Management.Catalog;
using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Food_Management.Inventory.Repository
{
    public class InventoryRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();
        public void add(String foodImage, String foodName, int foodPrice, String foodDescirption, String foodStatus)
        {
            FoodFactory ff = new FoodFactory();
            Food f = ff.create(foodImage, foodName, foodPrice, foodDescirption, foodStatus);

            db.Foods.Add(f);
            db.SaveChanges();
        }

        public Food search(int id)
        {
            return (from food in db.Foods where food.FoodID == id select food).FirstOrDefault();
        }

        public void delete(int id)
        {
            Food f = search(id);
            db.Foods.Remove(f);
            db.SaveChanges();
        }

        public void updateStatus(int foodId, String foodStatus)
        {
            Food f = search(foodId);

            f.FoodStatus = foodStatus;

            db.SaveChanges();
        }

        public void update(int foodId, String foodImage, String foodName, int foodPrice, String foodDescirption, String foodStatus)
        {
            Food f = search(foodId);

            f.FoodImage = foodImage;
            f.FoodName = foodName;
            f.FoodPrice = foodPrice;
            f.FoodDescription = foodDescirption;
            f.FoodStatus = foodStatus;

            db.SaveChanges();
        }
    }
}