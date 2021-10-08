using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class About
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        [Required]
        public string Icon { get; set; }
        [StringLength(maximumLength: 50)]

        public string Title { get; set; }


    }
}
