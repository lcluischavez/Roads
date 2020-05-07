using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roads.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name = "Secondary Address (optional)")]
        public string SecondaryAddress { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [Required]
        public int EventTypeId { get; set; }

        [Display(Name = "Event Type")]
        public EventType EventType { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Hosted By")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
