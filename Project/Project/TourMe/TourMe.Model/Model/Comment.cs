namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Content { get; set; }

        [Required]
        [StringLength(50)]
        public string Kind { get; set; }

        public int UserId { get; set; }

        public int? PlaceId { get; set; }

        public int? EventId { get; set; }

        public virtual Event Event { get; set; }

        public virtual Place Place { get; set; }

        public virtual User User { get; set; }
    }
}
