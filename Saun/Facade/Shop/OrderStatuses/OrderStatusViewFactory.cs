using Aids.Methods;
using Data.Shop.OrderStatuses;
using Domain.Shop.OrderStatuses;

namespace Facade.Shop.OrderStatuses
{
    public sealed class OrderStatusViewFactory
    {
        public static OrderStatus Create(OrderStatusView view)
        {
            var orderStatusData = new OrderStatusData();
            Copy.Members(view, orderStatusData);

            return new OrderStatus(orderStatusData);
        }

        public static OrderStatusView Create(OrderStatus orderStatus)
        {
            var view = new OrderStatusView();
            Copy.Members(orderStatus.Data, view);

            return view;
        }
    }
}
