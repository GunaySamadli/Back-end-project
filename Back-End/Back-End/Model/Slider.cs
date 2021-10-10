using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public int Order { get; set; }
        [StringLength(maximumLength: 50)]
        public string Icon { get; set; }
        [StringLength(maximumLength: 25)]
        public string IconTitle { get; set; }
        [StringLength(maximumLength: 50)]
        [Required]
        public string Title1 { get; set; }
        [StringLength(maximumLength: 50)]
        public string Title2 { get; set; }
        [StringLength(maximumLength: 100)]
        public string Subtitle { get; set; }
        [StringLength(maximumLength: 100)]
        public string Image { get; set; }
        [StringLength(maximumLength: 50)]
        public string RedirectUrlText { get; set; }
        [StringLength(maximumLength: 150)]
        public string RedirectUrl { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
