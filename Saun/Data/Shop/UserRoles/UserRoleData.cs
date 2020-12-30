using System;
using Data.Abstractions;

namespace Data.Shop.UserRoles
{
    public sealed class UserRoleData : UniqueEntityData
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Comment { get; set; }
    }
}