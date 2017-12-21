using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using TourMe.Model.Model;

namespace TourMe.ViewModel
{
    public class PlaceViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [StringLength(50)]
        public string ZoomSize { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime? DateCreate { get; set; }

        public bool? isEnable { get; set; }

        public int ServeStatus { get; set; }

        public int PlaceKindId { get; set; }

        public int RootPlaceId { get; set; }

        public int RatingStar { get; set; }

        public int? NofSearch { get; set; }

        public int? Poppular { get; set; }

        public int? TimeOpen { get; set; }

        public int? TimeClose { get; set; }

        public DateTime? LastConfirm { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string PageUrl { get; set; }

        public int? UserId { get; set; }

        public double? MinPrice { get; set; } 

        public double? MaxPrice { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public List<ImageViewModel> Imgs { get; set; }
    }
}