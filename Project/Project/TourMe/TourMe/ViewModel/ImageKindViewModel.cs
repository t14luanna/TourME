using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class ImageKindViewModel
    {
        public ImageKindViewModel()
        {

        }

        public ImageKindViewModel(int Id, DateTime DateCreate, string Description, string Kind)
        {
            this.Id = Id;
            this.DateCreate = DateCreate;
            this.Description = Description;
            this.Kind = Kind;
        }

        public int Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Description { get; set; }
        public string Kind { get; set; }
    }
}