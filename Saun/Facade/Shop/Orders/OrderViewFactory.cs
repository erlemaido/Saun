using Aids.Methods;
using Data.Shop.Orders;
using Domain.Shop.Orders;

namespace Facade.Shop.Orders
{
    public sealed class OrderViewFactory
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
