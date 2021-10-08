using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    public class ServiceController : Controller
    {

        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ServiceViewModel serviceVM = new ServiceViewModel
            {
                Abouts = _context.Abouts.ToList(),
                Services = _context.Services.ToList(),
            };
            return View(serviceVM);
        }
    }
}
