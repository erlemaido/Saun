using System;

namespace Data.Abstractions
{
    public class UniqueEntityData
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}