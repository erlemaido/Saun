using Aids.Methods;
using Data.Shop.Statuses;
using Domain.Shop.Statuses;

namespace Facade.Shop.Statuses
{
    public class StatusViewFactory
    {
        public static Status Create(StatusView view)
        {
            var statusData = new StatusData();

            Copy.Members(view, statusData);
            return new Status(statusData);
        }

        public static StatusView Create(Status status)
        {
            var view = new StatusView();
            Copy.Members(status.Data, view);
            return view;
        }
    }
}
