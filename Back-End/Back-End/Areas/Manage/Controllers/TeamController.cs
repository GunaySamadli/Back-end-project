using Back_End.Model;
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
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index(int page = 1)
        {

            List<Team> teams = _context.Teams.Include(x=>x.Products).Skip((page - 1) * 4).Take(4).ToList();

            ViewBag.TotalPage = Math.Ceiling(_context.Teams.Count() / 4m);
            ViewBag.SelectedPage = page;

            return View(teams);
        }


        public IActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (team.ImageFile != null)
            {

                if (team.ImageFile.ContentType != "image/jpeg" && team.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }


                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be mor than 2mb");
                    return View();
                }

                string filename = team.ImageFile.FileName;
                if (filename.Length > 64)
                {
                    filename = filename.Substring(filename.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + team.ImageFile.FileName;

                string path = Path.Combine(_env.WebRootPath, "uploads/team", newFileName);
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    team.ImageFile.CopyTo(stream);
                }
                team.Image = newFileName;
            }

            _context.Teams.Add(team);
            _context.SaveChanges();

            return RedirectToAction( "index");
        }

        public IActionResult Edit(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return NotFound();
            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            Team ExistTeam = _context.Teams.FirstOrDefault(x => x.Id == team.Id);

            if (ExistTeam == null) return NotFound();

            ExistTeam.Name = team.Name;

            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType != "image/jpeg" && team.ImageFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("ImageFile", "Content type can be only jpeg or png!");
                    return View();
                }

                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "File size can not be more than 2mb!");
                    return View();
                }


                string filename = team.ImageFile.FileName;
                if (filename.Length > 64)
                {
                    filename = filename.Substring(filename.Length - 64, 64);
                }
                string newFileName = Guid.NewGuid().ToString() + filename;

                string path = Path.Combine(_env.WebRootPath, "uploads/team", newFileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    team.ImageFile.CopyTo(stream);
                }

                if (ExistTeam.Image != null)
                {
                    string deletePath = Path.Combine(_env.WebRootPath, "uploads/team", ExistTeam.Image);

                    if (System.IO.File.Exists(deletePath))
                    {
                        System.IO.File.Delete(deletePath);
                    }
                }


                ExistTeam.Image = newFileName;
            }

            else if (team.Image == null && ExistTeam.Image != null)
            {
                string deletePath = Path.Combine(_env.WebRootPath, "uploads/author", ExistTeam.Image);

                if (System.IO.File.Exists(deletePath))
                {
                    System.IO.File.Delete(deletePath);
                }

                ExistTeam.Image = null;
            }

            _context.SaveChanges();

            return RedirectToAction("index");
        }


        public IActionResult DeleteFetch(int id)
        {
            Team team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team == null) return Json(new { status = 404 });

            try
            {
                _context.Teams.Remove(team);
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
