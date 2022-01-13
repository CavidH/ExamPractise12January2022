using Microsoft.AspNetCore.Identity;

namespace ExamPractise12January2022.Models
{
    public class User:IdentityUser
    {
        public string SurName { get; set; }
        public string Name { get; set; }
    }
}