using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Food_Management.Catalog
{
    public class CatalogController
    {
        CatalogHandler ch = new CatalogHandler();
        public List<Food> getFood()
        {
            return ch.getAllFood();
        }

        public List<Food> getArchivedFood()
        {
            return ch.getArchivedFood();
        }

        public List<Food> getAvailableFood()
        {
            return ch.getAvailableFood();
        }
    }
}