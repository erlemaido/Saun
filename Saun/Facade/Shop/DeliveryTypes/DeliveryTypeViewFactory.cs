using Aids.Methods;
using Data.Shop.DeliveryTypes;
using Domain.Shop.DeliveryTypes;

namespace Facade.Shop.DeliveryTypes
{
    public sealed class DeliveryTypeViewFactory
    {
        public static DeliveryType Create(DeliveryTypeView view)
        {
            var deliveryTypeData = new DeliveryTypeData();

            Copy.Members(view, deliveryTypeData);
            return new DeliveryType(deliveryTypeData);
        }

        public static DeliveryTypeView Create(DeliveryType type)
        {
            var view = new DeliveryTypeView();
            Copy.Members(type.Data, view);
            return view;
        }
    }
}
