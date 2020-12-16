using System;
using Data.Shop.Units;
using Domain.Shop.Units;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Units
{
    public class UnitsPage : ViewPage<IUnitsRepository, Unit, UnitView, UnitData>
    {
        public UnitsPage(IUnitsRepository repository) : base(repository, PagesNames.Units)
        {
        }

        protected internal override Unit ToObject(UnitView view) => UnitViewFactory.Create(view);

        protected internal override UnitView ToView(Unit obj) => UnitViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Units, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new UnitView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
