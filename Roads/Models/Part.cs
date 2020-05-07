using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roads.Models
{
    public class Part
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Brand { get; set; }
        public string ImagePath { get; set; }

        [Required]
        public int PartTypeId { get; set; }
        [Display(Name = "Part Type")]
        public PartType PartType { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Posted By")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
