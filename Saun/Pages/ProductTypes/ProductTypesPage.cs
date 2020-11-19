// using System;
// using Data.ProductTypes;
// using Domain.ProductTypes;
// using Facade.ProductTypes;
//
// namespace Pages.ProductTypes
// {
//     public abstract class ProductTypesPage : CommonPage<IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
//     {
//         protected internal ProductTypesPage(IProductTypesRepository productTypesRepository) : base(
//             productTypesRepository)
//         {
//             PageTitle = "Toote tüübid";
//
//         }
//
//         public override Guid ItemId => Item.Id;
//
//         protected internal override string GetPageUrl() => "/Saun/ProductTypes";
//         //No idea, mis meil siin olema peaks
//         protected internal override ProductType ToObject(ProductTypeView view)
//         {
//             return ProductTypeViewFactory.Create(view);
//         }
//
//         protected internal override ProductTypeView ToView(ProductType obj)
//         {
//             return ProductTypeViewFactory.Create(obj);
//         }
//     }
// }
