using Model = flavour_palette.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flavour_palette.Payment.Payment
{
    public class PaymentFactory
    {
        public Model.Payment create(int methodId, int price, String status, String date)
        {
            Model.Payment payment = new Model.Payment();

            payment.PaymentMethodID = methodId;
            payment.TotalPrice = price;
            payment.Status = status;
            payment.PaymentDate = DateTime.Parse(date);

            return payment;
        }
    }
}