namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime DateUpdate { get; set; }

        public int ArticleKindId { get; set; }

        public int? OwnId { get; set; }

        public virtual ArticleKind ArticleKind { get; set; }
    }
}
