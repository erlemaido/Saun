using Data.People;
using Domain.Abstractions;

namespace Domain.People
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