using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "City name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Population is required.")]
        public int Population { get; set; }
    }
}
