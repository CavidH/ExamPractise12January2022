using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise12January2022.DAL;
using ExamPractise12January2022.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.Areas.AdminDeli.Controllers
{
    [Area("AdminDeli")]
    public class ChoosesController : Controller
    {
        public AppDbContext _context { get; }

        public ChoosesController(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            var chooses = await _context.WhyChooses.Where(p => p.IsDeleted == false).ToListAsync();

            return View(chooses);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WhyChoose whyChoose)
        {
         await _context.WhyChooses.AddAsync(new WhyChoose{
                Title = whyChoose.Title,
                Content = whyChoose.Content,
               });

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var choose= await _context.WhyChooses.FindAsync(id);
            choose.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Chooses");
        }
        
        public async Task<IActionResult> Update(int? id)
        {
            var choose = await _context.WhyChooses.FindAsync(id);
            return View(choose);
        }
        [HttpPost]
        public async Task<IActionResult> Update(WhyChoose whyChoose,int? id)
        {
            var choose = await _context.WhyChooses.FindAsync(id);
            choose.Title = whyChoose.Title;
            choose.Content = whyChoose.Content;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Chooses");
        }



    }
}
