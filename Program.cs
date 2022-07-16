using WepApp.Data;
using Microsoft.EntityFrameworkCore;

// Add services to the container.

// DON'T Work string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
const string connectionString = "Data Source=DESKTOP-H2FTP3N\\SQLEXPRESS;Initial Catalog=University;Integrated Security=True";
var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<SchoolContext>(options => options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();


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
