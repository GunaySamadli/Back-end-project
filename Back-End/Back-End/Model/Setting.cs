using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Setting
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
       
        public string HeaderLogo { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string FooterLogo { get; set; }
        [Required]
        [StringLength(maximumLength: 20)]

        public string ContactPhone { get; set; }
        [Required]
        [StringLength(maximumLength: 250)]
        public string FooterAddress { get; set; }
        [Required]
        [StringLength(maximumLength: 250)]
        public string HeaderAddress { get; set; }
        [StringLength(maximumLength: 50)]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 50)]
        public string InstagramUrl { get; set; }
        [StringLength(maximumLength: 50)]
        public string SkypeUrl { get; set; }
        [StringLength(maximumLength: 50)]
        public string DribbbleUrl { get; set; }

        [StringLength(maximumLength: 50)]
        public string LinkedinUrl { get; set; }
        [StringLength(maximumLength: 50)]
        public string YoutubeUrl { get; set; }
        [StringLength(maximumLength: 100)]
        public string HeaderEmail { get; set; }
        [StringLength(maximumLength: 100)]
        public string ContactEmail { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string AboutTitle { get; set; }
        [Required]
        [StringLength(maximumLength: 150)]
        public string AboutSubtitle { get; set; }

        [StringLength(maximumLength: 150)]
        public string AboutDesc { get; set; }

        [StringLength(maximumLength: 150)]
        public string AboutVideo { get; set; }
    }
}
