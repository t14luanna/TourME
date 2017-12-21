namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Image")]
    public partial class Image
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Url { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Description { get; set; }

        public int ImageKindId { get; set; }

        public int? OwnId { get; set; }

        public virtual ImageKind ImageKind { get; set; }
    }
}
