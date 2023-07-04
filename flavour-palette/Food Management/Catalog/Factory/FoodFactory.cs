using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Food_Management.Catalog
{
    public class FoodFactory
    {
        public Food create(String image, String name, int price, String description, String status)
        {
            Food food = new Food();

            food.FoodImage = image;
            food.FoodName = name;
            food.FoodPrice = price;
            food.FoodDescription = description;
            food.FoodStatus = status;

            return food;
        }
    }
}