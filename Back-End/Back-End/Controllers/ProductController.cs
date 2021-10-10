using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult AddToFav(int id)
        {
            Product product = _context.Products.Include(x=>x.ProductImages).FirstOrDefault(x => x.Id == id);
            FavItemViewModel favItem = null;

            if (product == null) return NotFound();

            List<FavItemViewModel> products = new List<FavItemViewModel>();

            string ProductStr;

            if (HttpContext.Request.Cookies["Product"] != null)
            {
                ProductStr = HttpContext.Request.Cookies["Product"];
                products = JsonConvert.DeserializeObject<List<FavItemViewModel>>(ProductStr);

                favItem = products.FirstOrDefault(x => x.ProductId == id);
            }

            if (favItem == null)
            {
                favItem = new FavItemViewModel
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Image = product.ProductImages.FirstOrDefault(x => x.PosterStatus == true).Image,
                    Price =product.SalePrice ,
                    Count = 1
                };
                products.Add(favItem);
            }
            else
            {
                favItem.Count++;
            }
            ProductStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Product", ProductStr);

            return PartialView("_FavPartial", products);

        }
        public IActionResult ShowFav()
        {
            var ProductSr = HttpContext.Request.Cookies["Product"];
            return Content(ProductSr);
        }

        public IActionResult DeleteFromFav(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).FirstOrDefault(x => x.Id == id);
            FavItemViewModel favItem = null;

            List<FavItemViewModel> products = new List<FavItemViewModel>();


            string ProductStr = HttpContext.Request.Cookies["Product"];
            products = JsonConvert.DeserializeObject<List<FavItemViewModel>>(ProductStr);

            favItem = products.FirstOrDefault(x => x.ProductId == id);



            if (favItem.Count == 1)
            {

                products.Remove(favItem);
            }
            else
            {
                favItem.Count--;
            }
            ProductStr = JsonConvert.SerializeObject(products);
            HttpContext.Response.Cookies.Append("Product", ProductStr);

            return PartialView("_FavPartial", products);

        }
    }
}
