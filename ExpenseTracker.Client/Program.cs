using ExpenseTracker.Entities.Interface;
using ExpenseTracker.DataAccess.Repository;
using Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var con = builder.Configuration.GetConnectionString("con");
            builder.Services.AddDbContext<EtDbContext>(options => options.UseSqlServer(con));

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Category}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
