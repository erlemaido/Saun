using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Abstractions
{
    public abstract class UniqueEntityView
    {
        [Required]
        public Guid Id { get; set; }

        public Guid GetId() => Id;
        
    }
}
