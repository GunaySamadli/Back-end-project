using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int page=1)
        {
            ShopViewModel shopVM = new ShopViewModel
            {
                Products = _context.Products.Include(x => x.ProductImages).
                Include(x => x.Status).Include(x => x.City).Include(x => x.Team).Skip((page - 1) * 4).Take(4).ToList(),
                Statuses = _context.Statuses.ToList(),
                Categories = _context.Categories.ToList(),
            };
            ViewBag.TotalPage = Math.Ceiling(_context.Teams.Count() / 4m);
            ViewBag.SelectedPage = page;
            return View(shopVM);
        }
    }
}
