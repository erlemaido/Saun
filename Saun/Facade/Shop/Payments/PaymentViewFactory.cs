using Aids.Methods;
using Data.Shop.Payments;
using Domain.Shop.Payments;

namespace Facade.Shop.Payments
{
    public class PaymentViewFactory
    {
        public static Payment Create(PaymentView view)
        {
            var paymentData = new PaymentData();
            Copy.Members(view, paymentData);

            return new Payment(paymentData);
        }

        public static PaymentView Create(Payment payment)
        {
            var view = new PaymentView();
            Copy.Members(payment.Data, view);

            return view;
        }
    }
}
