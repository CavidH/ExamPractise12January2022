using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise12January2022.DAL;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.Areas.AdminDeli.Controllers
{
    [Area("AdminDeli")]
    public class GaleryController : Controller
    {
        private AppDbContext _context { get; }
        public GaleryController(AppDbContext context)
        {
            _context = context;
        }
      

        public async Task<IActionResult> Index()
        {
            var galeryImages = await _context
                .GaleryImages
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            return View(galeryImages);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return Content("");
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
