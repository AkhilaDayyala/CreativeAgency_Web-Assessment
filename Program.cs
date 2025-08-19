using Web.CreativeAgency.Services;

namespace Web.CreativeAgency
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // ⚡ Register Contact Service for DI
            builder.Services.AddSingleton<IContactService, FileContactService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Blog route
            app.MapControllerRoute(
               name: "blog-slug",
               pattern: "blog/{slug}",
               defaults: new { controller = "Blog", action = "Detail" });

            // Default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
