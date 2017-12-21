namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ArticleKind")]
    public partial class ArticleKind
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArticleKind()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(40)]
        public string Kind { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}
