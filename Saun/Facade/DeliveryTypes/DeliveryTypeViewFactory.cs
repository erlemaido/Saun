using Aids.Methods;
using Data.DeliveryType;
using Domain.DeliveryTypes;

namespace Facade.DeliveryTypes
{
    public class DeliveryTypeViewFactory
    {
        public static DeliveryType Create(DeliveryTypeView view)
        {
            var deliveryTypeData = new DeliveryTypeData();
            // {
            //     Id = view.Id ?? Guid.NewGuid().ToString(),
            //     Description = view.Description,
            //     Name = view.Name
            // };
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
