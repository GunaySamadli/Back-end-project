using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        public List<Product> Products { get; set; }


    }
}
