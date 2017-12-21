using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class ImageViewModel
    {
        public ImageViewModel()
        {

        }

        public int Id { get; set; }

        public string Url { get; set; }

        public DateTime? DateCreate { get; set; }

        public string Description { get; set; }

        public int ImageKindId { get; set; }

        public int? OwnId { get; set; }

    }
}