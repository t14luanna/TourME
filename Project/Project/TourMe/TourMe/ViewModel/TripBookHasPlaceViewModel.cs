using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class TripBookHasPlaceViewModel
    {
        public TripBookHasPlaceViewModel()
        {

        }

        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public int TripBookId { get; set; }

        public int PlaceId { get; set; }

        public bool? isTraveled { get; set; }

        public bool? isRemoved { get; set; }

        public string Vendor { get; set; }
    }
}