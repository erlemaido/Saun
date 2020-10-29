using System;
using Facade.Abstractions;

namespace Facade.CatalogItemTypes
{
    public class CatalogItemTypeView : NamedEntityView
    {
        public Guid GetId()
        {
            return Id;
        }
    }
}
