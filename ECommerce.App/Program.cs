using System.Globalization;
using ECommerce.App.Helper;
using ECommerce.App.Models;
using ECommerce.App.Service;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var config = builder.Configuration.GetSection("ConnectionString");
builder.Services.AddControllersWithViews();
var db=builder.Configuration.GetSection("ConnectionStrings:DefaultConnection");
//builder.Services.AddOptions<ConnectionStrings>().BindConfiguration(nameof(ConnectionStrings))
//    .ValidateDataAnnotations()
//    .ValidateOnStart();
////.Validate(options =>
//// {
////     if (options.State != "Kerala") return false;
////     return true;
//// });

var dbContext=builder.Configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection"));
//var weatherOptions = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Get<ConnectionStrings>();
builder.Services.AddSingleton(dbContext);
builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddTransient<IDbHelper,DbHelper>();
builder.Services.AddTransient<IAuthService, AuthService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    //var isUserAuthenticated=
    // Call the next delegate/middleware in the pipeline.
    await next(context);
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
