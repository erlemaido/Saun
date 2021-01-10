using System;
using Data.Abstractions;

namespace Data.Shop.Users
{
    public sealed class UserData : UniqueEntityData
    {
        public string PersonId { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Comment { get; set; }
    }
}