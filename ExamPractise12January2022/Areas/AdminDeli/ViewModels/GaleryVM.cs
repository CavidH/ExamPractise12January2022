using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ExamPractise12January2022.Areas.AdminDeli.ViewModels
{
    public class GaleryVM
    {
        [Required(ErrorMessage ="fayl daxil edin")]
        public IFormFile File { get; set; }
    }
}
