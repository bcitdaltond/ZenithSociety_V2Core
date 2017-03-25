using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZenithSocietyCore.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        public List<Event> Events { get; set; }
    }
}
