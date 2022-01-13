using ExamPractise12January2022.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPractise12January2022.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<WhyChoose> WhyChooses { get; set; }
        public DbSet<GaleryImage> GaleryImages { get; set; }
    }
}
