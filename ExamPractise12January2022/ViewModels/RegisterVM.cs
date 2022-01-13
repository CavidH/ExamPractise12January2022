using System.ComponentModel.DataAnnotations;

namespace ExamPractise12January2022.ViewModels
{
    public class RegisterVM
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Parol tekrari")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parol tekrari dogru deyil")]
        public string ConfirmPassword { get; set; }
    }
}
