using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamPractise12January2022.Areas.AdminDeli.ViewModels;
using ExamPractise12January2022.DAL;
using ExamPractise12January2022.Models;
using ExamPractise12January2022.Services.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.Areas.AdminDeli.Controllers
{
    [Area("AdminDeli")]
    public class GaleryController : Controller
    {
        private AppDbContext _context { get; }
        private IWebHostEnvironment _env { get; }

        public GaleryController(AppDbContext context, IWebHostEnvironment env)
        {
            _env = env;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GaleryVM galeryVm)
        { 
            
            if (!ModelState.IsValid)
            {
                return View(galeryVm);
            }

            if (!galeryVm.File.CheckFileType("image/"))
            {
                ModelState.AddModelError("File", "image formatinda fayl daxil edin");
                return View();
            }

            if (!galeryVm.File.CheckFileSize(350))
            {
                ModelState.AddModelError("File", "faylin hecmi 300 kb dan chox olmali deyil!");
                return View();
            }

            string filename = await galeryVm.File.SaveFileAsync(_env.WebRootPath, "Assets", "img");
            var galeryimage = new GaleryImage();
            galeryimage.ImageName = filename;
            await _context.GaleryImages.AddAsync(galeryimage);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Galery");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var galeryImage = await _context.GaleryImages.FindAsync(id);
            if (galeryImage == null) return NotFound();
            galeryImage.IsDeleted = true;
            // Helper.RemoveFile(_env.WebRootPath, galeryImage.ImageName, "Assets", "img");
            // _context.Remove(galeryImage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Galery");
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var galeryImage = await _context.GaleryImages.FindAsync(id);
            if (galeryImage == null) return NotFound();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, GaleryVM galeryVm)
        {
            var galeryImage = await _context.GaleryImages.FindAsync(id);
            if (galeryImage == null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View(galeryVm);
            }

            if (!galeryVm.File.CheckFileType("image/"))
            {
                ModelState.AddModelError("File", "image formatinda fayl daxil edin");
                return View();
            }

            if (!galeryVm.File.CheckFileSize(350))
            {
                ModelState.AddModelError("File", "faylin hecmi 300 kb dan chox olmali deyil!");
                return View();
            }

            string filename = await galeryVm.File.SaveFileAsync(_env.WebRootPath, "Assets", "img");
            galeryImage.ImageName = filename;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Galery");
        }
    }
}