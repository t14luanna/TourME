namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Place")]
    public partial class Place
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Place()
        {
            Comments = new HashSet<Comment>();
            Events = new HashSet<Event>();
            TripBookHasPlaces = new HashSet<TripBookHasPlace>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [StringLength(50)]
        public string ZoomSize { get; set; }

        [Required]
        public string Address { get; set; }

        public int ServeStatus { get; set; }

        public int PlaceKindId { get; set; }

        public int RootPlaceId { get; set; }

        public int? TimeOpen { get; set; }

        public int? TimeClose { get; set; }

        public int RatingStar { get; set; }

        public int? NofSearch { get; set; }

        public int? Poppular { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string PageUrl { get; set; }

        public int? UserId { get; set; }

        [StringLength(100)]
        public string PhoneNumber { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? LastConfirm { get; set; }

        public bool? isEnable { get; set; }

        public string Definition { get; set; }

        public double? MinPrice { get; set; }

        public double? MaxPrice { get; set; }

        public int Promote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        public virtual PlaceKind PlaceKind { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TripBookHasPlace> TripBookHasPlaces { get; set; }
    }
}
