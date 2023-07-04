using flavour_palette.Model;
using flavour_palette.Order_Management.Order_History.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History
{
    public class TransactionHeaderHandler
    {
        private TransactionHeaderRepository thr = new TransactionHeaderRepository();

        public void insertThr(int userId, int paymentId, String transactionDate, String status)
        {
            thr.add(userId, paymentId, transactionDate, status);
        }

        public List<TransactionHeader> getTh()
        {
            return thr.fetchAll();
        }

        public List<TransactionHeader> getUserTh(int userId)
        {
            return thr.fetchByUser(userId);
        }

        public List<Object> fetchAllWithFood(int userId)
        {
            return thr.fetchAllWithFood(userId);
        }

        public TransactionHeader search(int transactionId)
        {
            return thr.search(transactionId);
        }
    }
}