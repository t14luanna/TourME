using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {

        }

        public int Id { get; set; }

        public DateTime? DateCreate { get; set; }

        public DateTime? DateUpdate { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public int ImageId { get; set; }

        public string Email { get; set; }

        public bool? isEnable { get; set; }

        public int? Role { get; set; }
    }
}