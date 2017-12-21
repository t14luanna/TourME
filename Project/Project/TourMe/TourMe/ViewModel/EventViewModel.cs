using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class EventViewModel
    {
        public EventViewModel()
        {

        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(150)]
        public string Url { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public int EventKindId { get; set; }

        public int PlaceId { get; set; }
        
        public int Priority { get; set; }
    }
}