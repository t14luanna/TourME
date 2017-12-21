namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TripBook")]
    public partial class TripBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TripBook()
        {
            TripBookHasPlaces = new HashSet<TripBookHasPlace>();
        }

        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public int UserId { get; set; }

        public bool? isTraveled { get; set; }

        public bool? isRemoved { get; set; }

        public int? FeedBackId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripBookHasPlace> TripBookHasPlaces { get; set; }
    }
}
