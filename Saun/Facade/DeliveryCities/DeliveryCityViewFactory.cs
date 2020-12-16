﻿using Aids.Methods;
using Data.Cities;
using Domain.Cities;

namespace Facade.DeliveryCities
{
    public class DeliveryCityViewFactory
    {
        public static DeliveryCity Create(DeliveryCityView view)
        {
            var deliveryCityData = new DeliveryCityData();
            // {
            //     Id = view.Id ?? Guid.NewGuid().ToString(),
            //     Description = view.Description,
            //     Name = view.Name
            // };
            Copy.Members(view, deliveryCityData);
            return new DeliveryCity(deliveryCityData);
        }

        public static DeliveryCityView Create(DeliveryCity city)
        {
            var view = new DeliveryCityView();
            Copy.Members(city.Data, view);
            return view;
        }
    }
}
