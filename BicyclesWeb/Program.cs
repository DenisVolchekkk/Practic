using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Repositories.AppRepositories;
using Servcies.DbDataServcies;

namespace BicyclesWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connection = builder.Configuration.GetConnectionString("SqlServerConnection");


            builder.Services.AddDbContext<BicyclesContext>(options => options.UseSqlServer(connection));
            builder.Services.AddMemoryCache();
            builder.Services.AddRazorPages();

            builder.Services.AddScoped<BicycleRepository>();
            builder.Services.AddScoped<BicycleDataService>();

            builder.Services.AddScoped<PartRepository>();
            builder.Services.AddScoped<PartDataService>();

            builder.Services.AddScoped<PartBicycleRepository>();
            builder.Services.AddScoped<PartBicycleDataService>();

            builder.Services.AddScoped<SupplierRepository>();
            builder.Services.AddScoped<SupplierDataService>();

            builder.Services.AddScoped<SupplierTypeRepository>();
            builder.Services.AddScoped<SupplierTypeDataService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.Run();
        }
    }
}