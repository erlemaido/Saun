using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Abstractions
{
    public abstract class UniqueEntityView
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string GetId() => Id;
    }
}
