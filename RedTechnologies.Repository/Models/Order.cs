using RedTechnologies.Repository.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace RedTechnologies.Repository.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [Required, MaxLength(100)]
        public string CustomerName { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required, MaxLength(100)]
        public string CreatedByUserName { get; set; }

    }
}
