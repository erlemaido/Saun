using System;
using System.Collections.Generic;
using System.Text;
using Saun.Facade.Abstractions;

namespace Saun.Facade.UnitFacade
{
    public class UnitView : NamedEntityView
    {
        public Guid GetId()
        {
            return Id;
        }
    }
}
