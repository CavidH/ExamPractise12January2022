using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise12January2022.DAL;
using ExamPractise12January2022.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var chooses = await _context.WhyChooses.Where(p => p.IsDeleted == false).ToListAsync();
            HomeVM homeVm = new HomeVM
            {
                WhyChooses = chooses
            };
            return View(homeVm);
        }
    }
}
