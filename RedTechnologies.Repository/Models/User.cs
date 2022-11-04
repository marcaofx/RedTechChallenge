using System;
using System.ComponentModel.DataAnnotations;

namespace RedTechnologies.Repository.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(100)]
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
