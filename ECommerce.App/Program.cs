using ECommerce.App.Helper;
using ECommerce.App.Models;
using ECommerce.App.Service;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.

        builder.Services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", o =>
        {
            o.Cookie.Name = ".MyApp";
            o.LoginPath = "/home/index";
            o.SlidingExpiration = true;
            o.ExpireTimeSpan = TimeSpan.FromHours(12);

            o.Cookie.SameSite = SameSiteMode.Strict;
        });
        builder.Services.AddControllersWithViews();
        var db = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection");
        var dbContext = builder.Configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();
        builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection"));
       
        builder.Services.AddSingleton(dbContext);
        builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IDbHelper, DbHelper>();
        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddTransient<IUserService,UserService>();

        // Add services to the container.
        builder.Services.AddControllersWithViews();

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