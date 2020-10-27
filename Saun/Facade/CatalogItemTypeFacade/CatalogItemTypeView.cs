using System;
using System.Collections.Generic;
using System.Text;
using Saun.Facade.Abstractions;

namespace Saun.Facade.CatalogItemTypeFacade
{
    public class CatalogItemTypeView : NamedEntityView
    {
        public Guid GetId()
        {
            return Id;
        }
    }
}
