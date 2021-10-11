using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Model
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TeamId { get; set; }
        public int StatusId { get; set; }
        public int CityId { get; set; }
        [Required]
        public bool IsFeatured { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [StringLength(maximumLength: 1500)]
        public string Desc { get; set; }
        [Required]
        public int SalePrice { get; set; }
        [Required]
        public int Rooms { get; set; }
        [Required]
        public int Beds { get; set; }
        [Required]
        public int Baths { get; set; }
        [Required]
        public double HomeArea { get; set; }
        [Required]
        public int Rate { get; set; }
        [StringLength(maximumLength:50)]
        public string Location { get; set; }

        [Required]
        public int ParkingCount { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public int? WhichFloor { get; set; }
        [Required]
        public int HouseFloor { get; set; }
        public Category Category { get; set; }
        public Team Team { get; set; }
        public Status Status { get; set; }
        public City City { get; set; }

        public List<ProductTag> ProductTags { get; set; } = new List<ProductTag>();


        [NotMapped]
        public IFormFile PosterFile { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        [NotMapped]
        public List<int> ProductImageIds { get; set; } = new List<int>();

        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();

    }
}
