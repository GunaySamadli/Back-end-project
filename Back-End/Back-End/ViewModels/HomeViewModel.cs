using Back_End.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }

        public List<About> Abouts { get; set; }

        public List<Service> Services { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Status> Statuses { get; set; }
        public List<City> Cities { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> FeaturedProduct{ get; set; }
        public List<ProductTag> ProductTags { get; set; }
        public List<Setting> Settings { get; set; }

        public Order LastProduct { get; set; }



    }
}
