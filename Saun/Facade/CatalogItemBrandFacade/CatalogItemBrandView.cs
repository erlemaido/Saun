using System;
using System.Collections.Generic;
using System.Text;
using Saun.Facade.Abstractions;

namespace Saun.Facade.CatalogItemBrandFacade
{
    public class CatalogItemBrandView : DefinedEntityView
    {
        public Guid GetId()
        {
            return Id;
        }
    }
}
