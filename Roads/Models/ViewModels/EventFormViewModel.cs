using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roads.Models.ViewModels
{
    public class EventFormViewModel
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

        [Display(Name = "Image Url")]
        public string ImagePath { get; set; }

        public List<SelectListItem> EventTypeOptions { get; set; }

        public int EventTypeId { get; set; }

        [Display(Name = "Event Type")]
        public EventType EventType { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
