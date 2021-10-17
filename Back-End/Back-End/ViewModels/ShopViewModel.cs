using Back_End.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.ViewModels
{
    public class ShopViewModel
    {
        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public List<Status> Statuses { get; set; }

        public List<Review> Reviews { get; set; }
        public List<City> Cities { get; set; }

        public Review Review { get; set; }




    }
}
