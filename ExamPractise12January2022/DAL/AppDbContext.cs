using ExamPractise12January2022.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.DAL
{
    public class AppDbContext:IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
    
        }


        public DbSet<WhyChoose> WhyChooses { get; set; }
        public DbSet<GaleryImage> GaleryImages { get; set; }
    }
}
