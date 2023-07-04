using flavour_palette.Model;
using flavour_palette.Order_Management.Order_History.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Order_Management.Order_History
{
    public class TransactionDetailHandler
    {
        private TransactionDetailRepository tdr = new TransactionDetailRepository();

        public int getLatestThId()
        {
            return tdr.getLatestThId();
        }

        public void insert(int latestThId, int foodId, int qty)
        {
            tdr.add(latestThId, foodId, qty);
        }

        public List<TransactionDetail> getTrDetail(int trId)
        {
            return tdr.fetchByTransaction(trId);
        }

        public TransactionDetail fetchOneDataByTransaction(int id)
        {
            return tdr.fetchOneDataByTransaction(id);
        }

    }
}