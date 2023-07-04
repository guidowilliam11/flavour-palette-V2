using flavour_palette.Model;
using flavour_palette.Payment.Payment;
using flavour_palette.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Payment.Payment_Bounded_Context.Repository
{
    public class PaymentRepository
    {
        private DatabaseEntities db = DatabaseSingleton.getInstance();

        public void add(int methodId, int price, String status, String date)
        {
            PaymentFactory pf = new PaymentFactory();
            Model.Payment p = pf.create(methodId, price, status, date);

            db.Payments.Add(p);
            db.SaveChanges();
        }
        public int getLatestPaymentId()
        {
            var latestTransaction = (from payment in db.Payments
                                     orderby payment.PaymentID descending
                                     select payment).FirstOrDefault();

            return latestTransaction.PaymentID;
        }
    }
}