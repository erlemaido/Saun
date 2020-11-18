using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Brands;
using Domain.Brands;
using Pages.Brands;
using Infra;

namespace WebApp.Areas.Brands.Pages
{
    public class IndexModel : BrandsPage
    {

        public IndexModel(IBrandsRepository brandsRepository) : base(brandsRepository)
        {
        }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            await GetList(sortOrder, currentFilter, searchString, pageIndex, fixedFilter, fixedValue);

        }
    }
}
