using System;
using Data.Shop.People;
using Domain.Shop.People;
using Facade.Shop.People;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.People
{
    public sealed class PeoplePage : ViewPage<IPeopleRepository, Person, PersonView, PersonData>
    {
        public PeoplePage(IPeopleRepository repository) : base(repository, PagesNames.People)
        {
        }

        protected internal override Person ToObject(PersonView view) => PersonViewFactory.Create(view);
        
        protected internal override PersonView ToView(Person obj) => PersonViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.People, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new PersonView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}