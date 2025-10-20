using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.BLL.Service.Product;
using Quiz.DAL.Contexts;
using Quiz.DAL.Unit_Of_Work;

namespace MVC_Quiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(
                Options => Options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
                );


            builder.Services.AddDbContext<QuizDbContext>(options =>
            {

                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//3shan ygeb el connection string mn el appsettings.json
                options.UseLazyLoadingProxies();                                                                       //it will be more flexiable too for test and production 
            });


            builder.Services.AddScoped<IUnitOfWork, UOW>();


            builder.Services.AddScoped<IProductService, ProductService>();
            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();


            app.UseStaticFiles();//files
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
