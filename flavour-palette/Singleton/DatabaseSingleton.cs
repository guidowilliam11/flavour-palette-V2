using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Singleton
{
    public class DatabaseSingleton
    {
        private static DatabaseEntities db = null;

        public static DatabaseEntities getInstance()
        {
            if (db == null) db = new DatabaseEntities();
            return db;
        }
    }
}