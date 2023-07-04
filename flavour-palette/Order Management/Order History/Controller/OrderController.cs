using flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History
{
    public class OrderController
    {

        private TransactionHeaderHandler thh = new TransactionHeaderHandler();
        private TransactionDetailHandler tdh = new TransactionDetailHandler();

        public void insertTh(int userId, int paymentId, String transactionDate, String status)
        {
            thh.insertThr(userId, paymentId, transactionDate, status);
        }

        public int getLastThID()
        {
            return tdh.getLatestThId();
        }

        public void insertTd(int lastThID, int foodId, int qty)
        {
            tdh.insert(lastThID, foodId, qty);
        }

        public List<TransactionHeader> getUserTh(int userId)
        {
            return thh.getUserTh(userId);
        }

        public TransactionDetail fetchOneDataByTransaction(int transactionId)
        {
            return tdh.fetchOneDataByTransaction(transactionId);
        }
        public List<Object> fetchAllWithFood(int userId)
        {
            return thh.fetchAllWithFood(userId);
        }
        public List<TransactionDetail> getTrDetail(int transactionId)
        {
            return tdh.getTrDetail(transactionId);
        }
        public TransactionHeader search(int transactionId)
        {
            return thh.search(transactionId);
        }
    }
}