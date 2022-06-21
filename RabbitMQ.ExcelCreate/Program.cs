using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.ExcelCreate.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

} ).AddEntityFrameworkStores<AppDBContext>();



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
app.UseAuthentication();    
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
using (var scope =app.Services.CreateScope())
{
    var appDbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    appDbContext.Database.Migrate();
    if (!appDbContext.Users.Any())
    {
        userManager.CreateAsync(new IdentityUser()
        {
            UserName = "adem",
            Email = "adem@gmail.com",
            PasswordHash = "12345"

        }).Wait();
        userManager.CreateAsync(new IdentityUser()
        {
            UserName = "adem2",
            Email = "adem2@gmail.com",
            PasswordHash = "12345"

        }).Wait();
    }
}



app.Run();
