using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Team
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        [Required]
        public string Image { get; set; }
        [StringLength(maximumLength: 100)]
        [Required]
        public string Name { get; set; }
        [StringLength(maximumLength: 50)]
        public string FacebookIcon { get; set; }
        [StringLength(maximumLength: 50)]

        public string TwitterIcon { get; set; }
        [StringLength(maximumLength: 50)]

        public string LinkedinIcon { get; set; }




    }
}
