using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class TripBookViewModel
    {
        public TripBookViewModel()
        {

        }

        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public int UserId { get; set; }

        public bool? isTraveled { get; set; }

        public bool? isRemoved { get; set; }

        public int? FeedBackId { get; set; }
    }
}