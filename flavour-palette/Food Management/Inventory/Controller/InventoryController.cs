using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace flavour_palette.Food_Management.Inventory
{
    public class InventoryController
    {
        InventoryHandler ih = new InventoryHandler();
        public void archiveFood(int foodId)
        {
            ih.updateStatus(foodId, "Archive");
        }

        public void availableFood(int foodId)
        {
            ih.updateStatus(foodId, "Available");
        }

        public void deleteFood(int foodId)
        {
            ih.deleteFood(foodId);
        }
    
        public Food getFoodDetail(int foodId)
        {
            return ih.getFood(foodId);
        }

        public string updateFood(int foodId, FileUpload foodImage, String foodName, int foodPrice, String foodDescirption, String foodStatus)
        {
            String errorMsg = null;
            String fileExtension = Path.GetExtension(foodImage.FileName).ToLower();

            String fileImage = foodName + fileExtension;

            String filePath = HttpContext.Current.Server.MapPath("../../../Storage/profile/menu/") + fileImage;

            foodImage.SaveAs(filePath);

            ih.updateFood(foodId, fileImage, foodName, foodPrice, foodDescirption, foodStatus);
            return errorMsg;
        }

        public string addFood(FileUpload foodImage, String foodName, int foodPrice, String foodDescirption, String foodStatus)
        {
            String errorMsg = null;
            String fileExtension = Path.GetExtension(foodImage.FileName).ToLower();

            String fileImage = foodName + fileExtension;

            String filePath = HttpContext.Current.Server.MapPath("../../../Storage/profile/menu/") + fileImage;

            foodImage.SaveAs(filePath);
            ih.addCatalog(fileImage, foodName, foodPrice, foodDescirption, foodStatus);
            return errorMsg;
        }
    }
}