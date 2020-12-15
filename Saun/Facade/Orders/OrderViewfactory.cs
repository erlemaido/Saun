using System;
using System.Collections.Generic;
using System.Text;
using Aids.Methods;
using Data.Orders;
using Domain.Orders;

namespace Facade.Orders
{
    public class OrderViewfactory
    {
        public static Order Create(OrderView view)
        {
            var orderData = new OrderData();
            Copy.Members(view, orderData);

            return new Order(orderData);
        }

        public static OrderView Create(Order order)
        {
            var view = new OrderView();
            Copy.Members(order.Data, view);

            return view;
        }
    }
}
