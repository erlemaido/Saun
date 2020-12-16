using Data.Shop.People;
using Domain.Shop.People;
using Infra.Abstractions;

namespace Infra.Shop.People
{
    public sealed class PeopleRepository : UniqueEntityRepository<Person, PersonData>, IPeopleRepository
    {
        protected internal override Person ToDomainObject(PersonData data) => new Person(data);

        public PeopleRepository(SaunaDbContext context) : base(context, context.People)
        {
        }
    }
}