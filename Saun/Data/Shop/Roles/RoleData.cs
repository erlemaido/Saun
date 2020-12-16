using System;
using Data.Abstractions;

namespace Data.Shop.Roles
{
    public class RoleData : DefinedEntityData
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}