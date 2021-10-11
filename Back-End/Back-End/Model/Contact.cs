using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }

        [StringLength(maximumLength: 50)]
        public string Desc1 { get; set; }

        [StringLength(maximumLength: 50)]
        public string Desc2 { get; set; }
    }
}
