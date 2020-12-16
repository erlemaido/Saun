using Data.Statuses;
using Domain.Abstractions;

namespace Domain.Statuses
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
