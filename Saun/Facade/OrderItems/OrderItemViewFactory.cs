using System;
using System.Collections.Generic;
using System.Text;
using Aids.Methods;
using Data.OrderItems;
using Domain.OrderItems;

namespace Facade.OrderItems
{
    public class OrderItemViewFactory
    {
        public static OrderItem Create(OrderItemView view)
        {
            var orderItemData = new OrderItemData();
            Copy.Members(view, orderItemData);

            return new OrderItem(orderItemData);
        }

        public static OrderItemView Create(OrderItem orderItem)
        {
            var view = new OrderItemView();
            Copy.Members(orderItem.Data, view);

            return view;
        }
    }
}
