using System;
using Data.Abstractions;

namespace Data.Roles
{
    public class RoleData : DefinedEntityData
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}