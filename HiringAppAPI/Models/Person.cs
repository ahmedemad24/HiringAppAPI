using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HiringAppAPI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters")]
        public string Name { get; set; }
        [MinLength(5, ErrorMessage = "Family name must be at least 5 characters")]
        public string FamilyName { get; set; }
        [MinLength(10, ErrorMessage = "Invalid address should be 10 characters at least")]
        public string Address { get; set; }
        public string CountryOfOrigin { get; set; }
        public string EmailAddress { get; set; }
        [Range(20, 60, ErrorMessage = "Age should be between 20 and 60")]
        public int Age { get; set; }
        public bool IsHired { get; set; }
    }
}
