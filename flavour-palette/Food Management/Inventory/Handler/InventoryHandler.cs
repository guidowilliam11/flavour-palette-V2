using flavour_palette.Food_Management.Catalog.Repository;
using flavour_palette.Food_Management.Inventory.Repository;
using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Food_Management.Inventory
{
    public class InventoryHandler
    {
        private InventoryRepository ir = new InventoryRepository();

        public void addCatalog(String foodImage, String foodName, int foodPrice, String foodDescirption, String foodStatus)
        {
            ir.add(foodImage, foodName, foodPrice, foodDescirption, foodStatus);
        }

        public Food searchFood(int foodId)
        {
            return ir.search(foodId);
        }

        public void updateStatus(int foodId, String foodStatus)
        {
            ir.updateStatus(foodId, foodStatus);
        }

        public void updateFood(int foodId, String foodImage, String foodName, int foodPrice, String foodDescirption, String foodStatus)
        {
            ir.update(foodId, foodImage, foodName, foodPrice, foodDescirption, foodStatus);
        }

        public void deleteFood(int foodId)
        {
            ir.delete(foodId);
        }

        public Food getFood(int foodId)
        {
            return ir.search(foodId);
        }
    }
}