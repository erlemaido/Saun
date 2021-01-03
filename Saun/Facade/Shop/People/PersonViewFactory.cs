using Aids.Methods;
using Data.Shop.People;
using Domain.Shop.People;

namespace Facade.Shop.People
{
    public sealed class PersonViewFactory
    {
        public static Person Create(PersonView view)
        {
            var personData = new PersonData();
            Copy.Members(view, personData);

            return new Person(personData);
        }

        public static PersonView Create(Person personData)
        {
            var view = new PersonView();
            Copy.Members(personData.Data, view);

            return view;
        }
    }
}
