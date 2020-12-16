using Aids.Methods;
using Data.Shop.PaymentTypes;
using Domain.Shop.PaymentTypes;

namespace Facade.Shop.PaymentTypes
{
    public class PaymentTypeViewFactory
    {
        public static PaymentType Create(PaymentTypeView view)
        {
            var paymentTypeData = new PaymentTypeData();
            Copy.Members(view, paymentTypeData);

            return new PaymentType(paymentTypeData);
        }

        public static PaymentTypeView Create(PaymentType paymentType)
        {
            var view = new PaymentTypeView();
            Copy.Members(paymentType.Data, view);

            return view;
        }
    }
}
