using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class PlaceKindViewModel
    {
        public PlaceKindViewModel()
        {

        }

        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(40)]
        public string Kind { get; set; }

        public int Priority { get; set; }
    }
}