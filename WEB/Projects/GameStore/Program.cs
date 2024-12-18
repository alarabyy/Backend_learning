using GameStore.Data;
using GameStore.Services;
using GameStore.Services;
using GameStore.Services;
using Microsoft.EntityFrameworkCore;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /*//////////////////////////////////////////////////////////////////////////*/
            var connection = builder.Configuration.GetConnectionString("DefaultConnection");
            
            /*//////////////////////////////////////////////////////////////////////////*/
            /*layer inject database*/
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(connection));
            /*//////////////////////////////////////////////////////////////////////////*/
            /*layer authentication*/

            /*//////////////////////////////////////////////////////////////////////////*/
            /*dependacy injection to categries*/
            builder.Services.AddScoped<ICategoriesServeces, CategoriesServeces>();
            builder.Services.AddScoped<IDevicesServices, DevicesServices>();
            builder.Services.AddScoped<IGamesServices, GamesServices>();
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
