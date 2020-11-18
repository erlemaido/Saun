using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Brands;
using Domain.Brands;
using Infra;
using Pages.Brands;

namespace WebApp.Areas.Brands.Pages
{
    public class EditModel : BrandsPage
    {
        public EditModel(IBrandsRepository brandsRepository) : base(brandsRepository)
        {
        }

        public async Task<IActionResult> OnGetAsync(Guid id, string fixedFilter, string fixedValue)
        {
            await GetObject(id, fixedFilter, fixedValue);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string fixedFilter, string fixedValue)
        {
            await UpdateObject(fixedFilter, fixedValue);
            return Redirect(IndexUrl);
        }
    }
}
