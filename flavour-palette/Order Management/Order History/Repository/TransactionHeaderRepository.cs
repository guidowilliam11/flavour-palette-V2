using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History.Repository
{
    public class TransactionHeaderRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public void add(int userId, int paymentId, String transactionDate, String status)
        {
            TransactionHeaderFactory tf = new TransactionHeaderFactory();
            TransactionHeader t = tf.create(userId, paymentId, transactionDate, status);

            db.TransactionHeaders.Add(t);
            db.SaveChanges();
        }

        public List<TransactionHeader> fetchAll()
        {
            return (from transaction in db.TransactionHeaders select transaction).ToList();
        }

        public List<TransactionHeader> fetchByUser(int id)
        {
            return (from transaction in db.TransactionHeaders where transaction.UserID == id select transaction).ToList();
        }

        public TransactionHeader search(int id)
        {
            return (from transaction in db.TransactionHeaders where transaction.TransactionID == id select transaction).FirstOrDefault();
        }

        public void delete(int id)
        {
            TransactionHeader a = search(id);
            db.TransactionHeaders.Remove(a);
            db.SaveChanges();
        }

        public void update(int id, String transactionDate, int userId)
        {
            TransactionHeader t = search(id);
            t.TransactionDate = DateTime.Parse(transactionDate);
            t.UserID = userId;

            db.SaveChanges();
        }

        public List<Object> fetchAllWithFood(int id)
        {
            return (from header in db.TransactionHeaders
                    join detail in db.TransactionDetails on header.TransactionID equals detail.TransactionID
                    join food in db.Foods on detail.FoodID equals food.FoodID
                    where header.UserID == id
                    select new
                    {
                        TransactionID = header.TransactionID,
                        PaymentID = header.PaymentID,
                        TransactionDate = header.TransactionDate,
                        TransactionStatus = header.TransactionStatus,
                        FoodID = food.FoodID,
                        FoodImage = food.FoodImage,
                        FoodName = food.FoodName
                    }).ToList<object>();
        }

    }
}