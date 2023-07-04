using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Payment.Payment
{
    public class PaymentController
    {
        private PaymentHandler ph = new PaymentHandler();
        public void insertNewPayment(int paymentMethodID, int totalPrice, String paymentDate)
        {
            ph.insertPayment(paymentMethodID, totalPrice, "Success", paymentDate);
        }

        public int getLatestPaymentId()
        {
            return ph.getLatestPaymentId();
        }
    }
}