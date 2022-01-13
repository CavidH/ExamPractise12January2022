using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ExamPractise12January2022.Models
{
    public class GaleryImage
    {
        public int Id { get; set; }
        public string ImageName  { get; set; }
        public bool IsDeleted { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}