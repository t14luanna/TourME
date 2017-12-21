using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourMe.ViewModel
{
    public class CrawPlaceViewModel
    {
        public CrawPlaceViewModel()
        {

        }

        public string address { get; set; }
        public string brand { get; set; }
        public string category { get; set; }
        public int count_reviews { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string facebook { get; set; }
        public GPS gps { get; set; }
        public string hash { get; set; }
        public string img { get; set; }
        public string img_big { get; set; }
        public bool is_promoted { get; set; }
        public bool no_image { get; set; }
        public string phone { get; set; }
        public string[] photos { get; set; }
        public int rating { get; set; }
        public string title { get; set; }
        public string url { get; set; }
    }

    public class GPS
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
}