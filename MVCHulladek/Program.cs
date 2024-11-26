using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCHulladek.Data;
using MVCHulladek.Models;
namespace MVCHulladek
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<MVCHulladekContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MVCHulladekContext") ?? throw new InvalidOperationException("Connection string 'MVCHulladekContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MVCHulladekContext>(opts =>
            {
                opts.UseSqlServer(
                    builder.Configuration["ConnectionStrings:MVCHulladekContext"]);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            SeedData.EnsurePopulated(app);

            app.Run();
        }
    }
}
