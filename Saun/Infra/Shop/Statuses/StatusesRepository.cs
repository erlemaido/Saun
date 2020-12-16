using Data.Shop.Statuses;
using Domain.Shop.Statuses;
using Infra.Abstractions;

namespace Infra.Shop.Statuses
{
    public sealed class StatusesRepository : UniqueEntityRepository<Status, StatusData>, IStatusesRepository
    {
        protected internal override Status ToDomainObject(StatusData data) => new Status(data);

        public StatusesRepository(SaunaDbContext context) : base(context, context.Statuses)
        {
        }
    }
}
