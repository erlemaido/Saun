using System;
using System.Collections.Generic;
using System.Text;
using Aids.Methods;
using Data.DeliveryStatus;
using Domain.DeliveryCities;
using Domain.DeliveryStatuses;
using Facade.DeliveryCities;

namespace Facade.DeliveryStatuses
{
    public class DeliveryStatusViewFactory
    {
        public static DeliveryStatus Create(DeliveryStatusView view)
        {
            var deliveryStatusData = new DeliveryStatusData();
            // {
            //     Id = view.Id ?? Guid.NewGuid().ToString(),
            //     Description = view.Description,
            //     Name = view.Name
            // };
            Copy.Members(view, deliveryStatusData);
            return new DeliveryStatus(deliveryStatusData);
        }

        public static DeliveryStatusView Create(DeliveryStatus status)
        {
            var view = new DeliveryStatusView();
            Copy.Members(status.Data, view);
            return view;
        }
    }
}
