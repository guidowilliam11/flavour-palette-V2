using Model = flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History
{
    public class TransactionDetailFactory
    {
        public Model.TransactionDetail create(int transactionId, int foodId, int quantity)
        {
            Model.TransactionDetail detail = new Model.TransactionDetail();

            detail.TransactionID = transactionId;
            detail.FoodID = foodId;
            detail.Qty = quantity;

            return detail;
        }
    }
}