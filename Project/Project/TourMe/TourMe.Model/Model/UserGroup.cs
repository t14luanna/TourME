namespace TourMe.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserGroup")]
    public partial class UserGroup
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }
    }
}
