using System;
using System.ComponentModel.DataAnnotations;

namespace Saun.Facade.Abstractions
{
    public abstract class UniqueEntityView
    {
        [Required]
        public Guid Id { get; set; }
    }
}
