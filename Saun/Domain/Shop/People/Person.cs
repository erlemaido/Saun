using Data.Shop.People;
using Domain.Abstractions;

namespace Domain.Shop.People
{
    public sealed class Person : UniqueEntity<PersonData>
    {
        public Person() : this(null)
        {

        }

        public Person(PersonData data) : base(data)
        {

        }
    }
}