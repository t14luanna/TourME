namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
