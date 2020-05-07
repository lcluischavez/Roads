using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roads.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }

        [Required]
        [Display(Name = "Original Color")]
        public string Color { get; set; }

        [Display(Name = "Image Url")]
        public string ImagePath { get; set; }

        [Display(Name = "Performance")]
        public string PerformanceMods { get; set; }

        [Display(Name = "Aesthetic")]
        public string AstheticMods { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
