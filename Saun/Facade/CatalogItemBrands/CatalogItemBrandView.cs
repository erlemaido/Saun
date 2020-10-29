using System;
using Facade.Abstractions;

namespace Facade.CatalogItemBrands
{
    public class CatalogItemBrandView : DefinedEntityView
    {
        public Guid GetId()
        {
            return Id;
        }
    }
}
