using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roads.Models.ViewModels
{
    public class PartFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Brand { get; set; }
        [Display(Name = "Image Url")]
        public string ImagePath { get; set; }

        public List<SelectListItem> PartTypeOptions { get; set; }

        public int PartTypeId { get; set; }

        [Display(Name = "Part Type")]
        public PartType PartType { get; set; }

        public string ApplicationUserId { get; set; }

    }
}
