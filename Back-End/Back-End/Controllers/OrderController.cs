using Back_End.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Member")]
        public IActionResult Buy(int id)
        {
            AppUser member=_userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name && !x.IsAdmin);

            Product product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            Order order = new Order
            {
                AppUserId = member.Id,
                FullName=member.FullName,
                Email = member.Email,
                ProductId = product.Id,
                ProductName = product.Name,
                Price=product.SalePrice,
                CreatedAt=DateTime.UtcNow,
                Status=Model.Enum.OrderStatus.Pending

            };
            _context.Orders.Add(order);
            _context.SaveChanges();

            return RedirectToAction("profile","account");
        }
    }
}
