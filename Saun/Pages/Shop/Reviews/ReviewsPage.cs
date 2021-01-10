using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Products;
using Data.Shop.Reviews;
using Data.Shop.Users;
using Domain.Shop.Products;
using Domain.Shop.Reviews;
using Domain.Shop.Users;
using Facade.Shop.Reviews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Reviews
{
    public sealed class ReviewsPage : ViewPage<IReviewsRepository, Review, ReviewView, ReviewData>
    {
        public ReviewsPage(
            IReviewsRepository repository,
            IProductsRepository productsRepository,
            IUsersRepository usersRepository) : base(repository, PagesNames.Reviews)
        {
            Products = NewItemsList<Product, ProductData>(productsRepository);
            Users = NewUsersList<User, UserData>(usersRepository);
        }

        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        protected internal override Review ToObject(ReviewView view) => ReviewViewFactory.Create(view);

        protected internal override ReviewView ToView(Review obj) => ReviewViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Reviews, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new ReviewView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public string GetProductName(string itemProductId) => GetItemName(Products, itemProductId);

        public string GetUserName(string itemUserId) => GetItemName(Users, itemUserId);
    }
}
