using Back_End.Model;
using Back_End.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public LayoutService(AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
        public List<FavItemViewModel> GetFavItems()
        {
            List<FavItemViewModel> items = new List<FavItemViewModel>();

            var itemsStr = _contextAccessor.HttpContext.Request.Cookies["Product"];

            if (itemsStr != null)
            {
                items = JsonConvert.DeserializeObject<List<FavItemViewModel>>(itemsStr);

                foreach (var item in items)
                {
                    Product product = _context.Products.Include(c => c.ProductImages).FirstOrDefault(x => x.Id == item.ProductId);
                    if (product != null)
                    {
                        item.Name = product.Name;
                        item.Price = product.SalePrice;
                        item.Image = product.ProductImages.FirstOrDefault(x => x.PosterStatus == true)?.Image;
                    }
                }
            }

            return items;
        }

    }
}
