using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Port.Models;
using Microsoft.AspNetCore.Identity;

namespace Port
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            /*//////////////////////////////////////////////////////////////////////////*/
            /*layer inject database*/
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(connection));

            /*//////////////////////////////////////////////////////////////////////////*/
            /*layer authentication*/

            /*//////////////////////////////////////////////////////////////////////////*/
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
          
            app.Run();
        }
    }
}
