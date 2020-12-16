using System;
using Data.Abstractions;

namespace Data.Shop.Reviews
{
    public class ReviewData : UniqueEntityData
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime Time { get; set; }
    }
}