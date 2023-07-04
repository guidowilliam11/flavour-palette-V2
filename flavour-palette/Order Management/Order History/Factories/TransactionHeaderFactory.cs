using Model = flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History
{
    public class TransactionHeaderFactory
    {
        public Model.TransactionHeader create(int userId, int paymentId, String date, String status)
        {
            Model.TransactionHeader header = new Model.TransactionHeader();

            header.UserID = userId;
            header.PaymentID = paymentId;
            header.TransactionDate = DateTime.Parse(date);
            header.TransactionStatus = status;

            return header;
        }
    }
}