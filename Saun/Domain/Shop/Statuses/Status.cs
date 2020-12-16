using Data.Shop.Statuses;
using Domain.Abstractions;

namespace Domain.Shop.Statuses
{
    public sealed class Status : NamedEntity<StatusData>
    {
        public Status() : this(null)
        {

        }

        public Status(StatusData data) : base(data)
        {

        }
    }
}
