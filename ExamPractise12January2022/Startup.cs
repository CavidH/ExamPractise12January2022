using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExamPractise12January2022.DAL;
using ExamPractise12January2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ExamPractise12January2022
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Default"]);
            });
            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false; 
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false; 
                options.Lockout.MaxFailedAccessAttempts = 5; 
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5); 
                options.Lockout.AllowedForNewUsers = true; 
                options.User.RequireUniqueEmail = true; 
                options.SignIn.RequireConfirmedEmail = true; 
                options.SignIn.RequireConfirmedPhoneNumber = false;  

            });
            services.ConfigureApplicationCookie(option => //cookie burada yarat??l??r.
            {
                option.LoginPath = "/account/login";
                option.LogoutPath = "/account/logout";
                option.AccessDeniedPath = "/account/accessdenied"; //yanl???? yere girenler i??in gereklidir. 
                option.SlidingExpiration = true; //session s??resi 20 dk d??r 20 dk boyunca herhangi bir istek gelmezse oturum kapat??l??r. 
                option.ExpireTimeSpan = TimeSpan.FromMinutes(36); //36 dk'l??k bir session olu??tur.

                option.Cookie = new CookieBuilder
                {
                    HttpOnly = true, //cookie'yi sadece http olarak alabiliriz.
                    Name = ".Shopapp.Security.Cookie",
                    SameSite = SameSiteMode.Strict //B kullan??c??s?? An??n cookiesine sahip olsa bile onun ad??na i??lem ypaamz bunu yazarsak 
                };


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
