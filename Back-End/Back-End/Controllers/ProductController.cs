using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;

        public ProductController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult AddToFav(int id)
        {
            Product product = _context.Products.Include(x=>x.ProductImages).FirstOrDefault(x => x.Id == id);
            FavItemViewModel favItem = null;

            if (product == null) return NotFound();

            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<FavItemViewModel> products = new List<FavItemViewModel>();

            if (member == null)
            {
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
                        Price = product.SalePrice,
                        Count = 1
                    };
                    products.Add(favItem);
                }

                ProductStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Product", ProductStr);

            }
            else
            {
                FavItems memberFavItem = _context.FavItems
                                        .FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);
                if (memberFavItem == null)
                {
                    memberFavItem = new FavItems
                    {
                        AppUserId = member.Id,
                        ProductId = id,
                        Count = 1
                    };
                    _context.FavItems.Add(memberFavItem);
                }
               
                _context.SaveChanges();
                products = _context.FavItems.Select(x =>
                  new FavItemViewModel
                  {
                      ProductId = x.ProductId,
                      Count = x.Count,
                      Name = x.Product.Name,
                      Price = x.Product.SalePrice,
                      Image = x.Product.ProductImages
                                .FirstOrDefault(bi => bi.PosterStatus == true).Image
                  }).ToList();
            }
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


            AppUser member = null;

            if (User.Identity.IsAuthenticated)
            {
                member = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            }

            List<FavItemViewModel> products = new List<FavItemViewModel>();


            if (member==null)
            {
                string ProductStr = HttpContext.Request.Cookies["Product"];
                products = JsonConvert.DeserializeObject<List<FavItemViewModel>>(ProductStr);

                favItem = products.FirstOrDefault(x => x.ProductId == id);



               products.Remove(favItem);
               

                ProductStr = JsonConvert.SerializeObject(products);
                HttpContext.Response.Cookies.Append("Product", ProductStr);
            }
            else
            {
                FavItems memberFavItem = _context.FavItems.Include(x => x.Product).FirstOrDefault(x => x.AppUserId == member.Id && x.ProductId == id);

                

                 _context.FavItems.Remove(memberFavItem);
                


                _context.SaveChanges();

                products = _context.FavItems.Include(x => x.Product).ThenInclude(bi => bi.ProductImages).Where(x => x.AppUserId == member.Id)
                    .Select(x => new FavItemViewModel { ProductId = x.ProductId, Count = x.Count, Name = x.Product.Name, Price = x.Product.SalePrice, Image = x.Product.ProductImages.FirstOrDefault(b => b.PosterStatus == true).Image }).ToList();

            }

            return PartialView("_FavPartial", products);

        }

        public IActionResult Detail(int id,Review review)
        {
            Product product = _context.Products.Include(x => x.ProductImages).Include(x => x.Team).Include(x => x.Category).
               Include(x => x.City).Include(x => x.Status)
               .Include(x => x.ProductTags).ThenInclude(x => x.Tag).FirstOrDefault(x => x.Id == id);

            ViewBag.Categories = _context.Categories.Include(x => x.Products).ToList();


            ShopViewModel shopVM = new ShopViewModel
            {
                Product = product,
                Reviews=_context.Reviews.Include(x=>x.AppUser).Where(x=>x.ProductId==id).ToList()
            };


            return View(shopVM);
        }
    }
}
