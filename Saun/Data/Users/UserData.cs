using System;
using Data.Abstractions;

namespace Data.Users
{
    public class UserData : UniqueEntityData
    {
        public string PersonId { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Comment { get; set; }
    }
}