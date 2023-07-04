using flavour_palette.Food_Management.Catalog.Repository;
using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Food_Management.Catalog
{
    public class CatalogHandler
    {
        CatalogRepository cr = new CatalogRepository();
        public List<Food> getAllFood()
        {
            return cr.fetchAll();
        }

        public List<Food> getAvailableFood()
        {
            return cr.fetchAvailable();
        }

        public List<Food> getArchivedFood()
        {
            return cr.fetchArchived();
        }
    }
}