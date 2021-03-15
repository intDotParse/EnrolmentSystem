using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnrolmentSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage ="Name is mandatory!")]
        public string Name { get; set; }

        [Required, Range(16, 99)]
        public int Age { get; set; }

        [Required, StringLength(200)]
        public string  Address { get; set; }
    }
}
