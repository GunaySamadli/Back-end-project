using Back_End.Helpers;
using Back_End.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1, string search = null)
        {
            var query = _context.Products.AsQueryable();

            ViewBag.CurrentSearch = search;

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x => x.Name.Contains(search));
            }
            List<Product> products = query.Include(x => x.Category).Include(x => x.City).Include(x => x.Team).Include(x => x.Status).Include(x => x.ProductImages).Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(query.Count() / 4m);
            ViewBag.SelectedPage = page;


            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams.ToList();
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Tags = _context.Tags.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Product product)
        {
            ViewBag.Teams = _context.Teams.ToList();
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            if (!_context.Teams.Any(x => x.Id == product.TeamId)) ModelState.AddModelError("TeamId", "Team not found!");
            if (!_context.Categories.Any(x => x.Id == product.CategoryId)) ModelState.AddModelError("CategoryId", "Category not found!");
            if (!_context.Statuses.Any(x => x.Id == product.StatusId)) ModelState.AddModelError("StatusId", "Status not found!");
            if (!_context.Cities.Any(x => x.Id == product.CityId)) ModelState.AddModelError("CityId", "City not found!");




            foreach (var tagid in product.TagIds)
            {
                Tag tag = _context.Tags.FirstOrDefault(x => x.Id == tagid);

                if (tag == null)
                {
                    ModelState.AddModelError("TagId", "Tag not found!");
                    return View();
                }

                ProductTag productTag = new ProductTag
                {
                    TagId = tagid
                };
                product.ProductTags.Add(productTag);
            }
            if (!ModelState.IsValid) return View();


            product.ProductImages = new List<ProductImage>();

            if (product.PosterFile == null)
            {
                ModelState.AddModelError("PosterFile", "Poster file is required");
            }
            else
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                string newFileName = Guid.NewGuid().ToString() + product.PosterFile.FileName;
                string path = Path.Combine(_env.WebRootPath, "uploads/product", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    product.PosterFile.CopyTo(stream);
                }

                ProductImage poster = new ProductImage
                {
                    Image = newFileName,
                    PosterStatus = true,
                };
                product.ProductImages.Add(poster);
            }


           

            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {

                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {

                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    ProductImage image = new ProductImage
                    {
                        PosterStatus = false,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/product", file)
                    };

                    product.ProductImages.Add(image);
                }
            }



            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult Edit(int id)
        {
            Product product = _context.Products.Include(x => x.ProductImages).Include(x => x.Team).Include(x => x.Category).
                Include(x => x.City).Include(x => x.Status)
                .Include(x => x.ProductTags).ThenInclude(x=>x.Tag).FirstOrDefault(x => x.Id == id);

            ViewBag.Teams = _context.Teams.ToList();
            ViewBag.Category = _context.Categories.ToList();
            ViewBag.City = _context.Cities.ToList();
            ViewBag.Status = _context.Statuses.ToList();
            ViewBag.Tags = _context.Tags.ToList();

            product.TagIds = product.ProductTags.Select(x => x.TagId).ToList();


            if (product == null) return NotFound();

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!_context.Teams.Any(x => x.Id == product.TeamId)) ModelState.AddModelError("TeamId", "Team not found!");
            if (!_context.Categories.Any(x => x.Id == product.CategoryId)) ModelState.AddModelError("CategoryId", "Category not found!");
            if (!_context.Statuses.Any(x => x.Id == product.StatusId)) ModelState.AddModelError("StatusId", "Status not found!");
            if (!_context.Cities.Any(x => x.Id == product.CityId)) ModelState.AddModelError("CityId", "City not found!");

            if (!ModelState.IsValid) return View();


            Product existProudct = _context.Products.Include(x => x.ProductImages).Include(x => x.ProductTags).FirstOrDefault(x => x.Id == product.Id);

            existProudct.ProductTags.RemoveAll(x => !product.TagIds.Contains(x.TagId));

            if (existProudct == null) return NotFound();

            if (product.TagIds != null)
            {
                foreach (var tagId in product.TagIds.Where(x => !existProudct.ProductTags.Any(bt => bt.TagId == x)))
                {
                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId,
                        ProductId = product.Id
                    };

                    existProudct.ProductTags.Add(productTag);
                }
            }



            if (product.PosterFile != null)
            {
                if (product.PosterFile.ContentType != "image/png" && product.PosterFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("PosterFile", "File type can be only jpeg,jpg or png!");
                    return View();
                }

                if (product.PosterFile.Length > 2097152)
                {
                    ModelState.AddModelError("PosterFile", "File size can not be more than 2MB!");
                    return View();
                }

                ProductImage poster = existProudct.ProductImages.FirstOrDefault(x => x.PosterStatus == true);

                string NewFileName = FileManager.Save(_env.WebRootPath, "uploads/product", product.PosterFile);

                if (poster == null)
                {
                    poster = new ProductImage
                    {
                        PosterStatus = true,
                        Image = NewFileName,
                        ProductId = product.Id
                    };

                    _context.ProductImages.Add(poster);
                }
                else
                {
                    FileManager.Delete(_env.WebRootPath, "uploads/product", poster.Image);
                    poster.Image = NewFileName;

                }
            }



            existProudct.ProductImages.RemoveAll(x => x.PosterStatus == false && !product.ProductImageIds.Contains(x.Id));

            if (product.ImageFiles != null)
            {
                foreach (var file in product.ImageFiles)
                {

                    if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
                    {

                        continue;
                    }

                    if (file.Length > 2097152)
                    {
                        continue;
                    }

                    ProductImage image = new ProductImage
                    {
                        PosterStatus = false,
                        Image = FileManager.Save(_env.WebRootPath, "uploads/product", file)
                    };

                    existProudct.ProductImages.Add(image);
                }
            }



            existProudct.Name = product.Name;
            existProudct.TeamId = product.TeamId;
            existProudct.CategoryId = product.CategoryId;
            existProudct.StatusId = product.StatusId;
            existProudct.CityId = product.CityId;
            existProudct.Rooms = product.Rooms;
            existProudct.Beds = product.Beds;
            existProudct.Baths = product.Baths;
            existProudct.HomeArea = product.HomeArea;
            existProudct.WhichFloor = product.WhichFloor;
            existProudct.HouseFloor = product.HouseFloor;
            existProudct.ParkingCount = product.ParkingCount;
            existProudct.CreatedAt = product.CreatedAt;
            existProudct.SalePrice = product.SalePrice;
            existProudct.Desc = product.Desc;
            existProudct.Rate = product.Rate;
            existProudct.Location = product.Location;
            existProudct.IsFeatured = product.IsFeatured;

            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public IActionResult DeleteFetch(int id)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return Json(new { status = 404 });

            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return Json(new { status = 500 });
            }

            return Json(new { status = 200 });
        }
    }
}
