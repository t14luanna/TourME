namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripBookHasPlace")]
    public partial class TripBookHasPlace
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public int TripBookId { get; set; }

        public int PlaceId { get; set; }

        public bool? isTraveled { get; set; }

        public bool? isRemoved { get; set; }

        public string Vendor { get; set; }

        public virtual Place Place { get; set; }

        public virtual TripBook TripBook { get; set; }
    }
}
