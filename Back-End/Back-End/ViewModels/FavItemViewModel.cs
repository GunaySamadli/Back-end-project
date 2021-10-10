using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.ViewModels
{
    public class FavItemViewModel
    {
        public int ProductId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

    }
}
