using Aids.Methods;
using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;

namespace Facade.Shop.OrderItems
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
