using Microsoft.AspNetCore.Mvc;

namespace ExamPractise12January2022.Areas.AdminDeli.Controllers
{       
    [Area("AdminDeli")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
