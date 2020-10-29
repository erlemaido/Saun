using System;
using Facade.Abstractions;

namespace Facade.Units
{
    public class UnitView : NamedEntityView
    {
        public Guid GetId()
        {
            return Id;
        }
    }
}
