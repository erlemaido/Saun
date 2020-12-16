using Data.Abstractions;

namespace Data.People
{
    public class PersonData : UniqueEntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}