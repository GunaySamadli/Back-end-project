using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100)]
        [Required]
        public string Icon { get; set; }
        [StringLength(maximumLength: 100)]
        [Required]
        public string Title { get; set; }
        [StringLength(maximumLength: 200)]
        public string Desc { get; set; }
        [StringLength(maximumLength: 50)]

        public string UrlText { get; set; }
    }
}
