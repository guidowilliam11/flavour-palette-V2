using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Food_Management.Catalog.Repository
{
    public class CatalogRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public List<Food> fetchAll()
        {
            return (from food in db.Foods select food).ToList();
        }

        public List<Food> fetchAvailable()
        {
            return (from food in db.Foods
                    where food.FoodStatus == "Available"
                    select food).ToList();
        }

        public List<Food> fetchArchived()
        {
            return (from food in db.Foods
                    where food.FoodStatus == "Archive"
                    select food).ToList();
        }
    }
}