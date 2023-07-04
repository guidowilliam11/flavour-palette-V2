using flavour_palette.Model;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History.Repository
{
    public class TransactionDetailRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public void add(int transactionId, int foodId, int quantity)
        {
            TransactionDetailFactory tf = new TransactionDetailFactory();
            TransactionDetail t = tf.create(transactionId, foodId, quantity);

            db.TransactionDetails.Add(t);
            db.SaveChanges();
        }

        public List<TransactionDetail> fetchAll()
        {
            return (from transaction in db.TransactionDetails select transaction).ToList();
        }

        public TransactionDetail fetchOneDataByTransaction(int id)
        {
            return (from transaction in db.TransactionDetails where transaction.TransactionID == id select transaction).FirstOrDefault();
        }

        public List<TransactionDetail> fetchByTransaction(int id)
        {
            return (from transaction in db.TransactionDetails where transaction.TransactionID == id select transaction).ToList();
        }

        public List<TransactionDetail> fetchByFood(int id)
        {
            return (from transaction in db.TransactionDetails where transaction.FoodID == id select transaction).ToList();
        }

        public TransactionDetail search(int transactionId, int foodId)
        {
            return (from transaction in db.TransactionDetails where transaction.TransactionID == transactionId && transaction.FoodID == foodId select transaction).FirstOrDefault();
        }

        public void delete(int transactionId, int foodId)
        {
            TransactionDetail t = search(transactionId, foodId);
            db.TransactionDetails.Remove(t);
            db.SaveChanges();
        }

        public void update(int transactionId, int foodId, int quantity)
        {
            TransactionDetail t = search(transactionId, foodId);
            t.TransactionID = transactionId;
            t.FoodID = foodId;
            t.Qty = quantity;

            db.SaveChanges();
        }

        public int getLatestThId()
        {
            var latestTransaction = (from transaction in db.TransactionHeaders
                                     orderby transaction.TransactionID descending
                                     select transaction).FirstOrDefault();

            return latestTransaction.TransactionID;
        }

    }
}