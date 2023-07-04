using flavour_palette.Payment.Payment_Bounded_Context.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Payment.Payment
{
    public class PaymentHandler
    {
        private PaymentRepository pr = new PaymentRepository();
        public void insertPayment(int methodId, int price, String status, String date)
        {
            pr.add(methodId, price, status, date);
        }
        public int getLatestPaymentId()
        {
            return pr.getLatestPaymentId();
        }
    }
}