using Assignment1_PROG3340.Data;
using Assignment1_PROG3340.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// register unit of work for di
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

// register dbcontext with env
builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var env = serviceProvider.GetRequiredService<IWebHostEnvironment>();
    options.UseSqlite("Data Source=app.db");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
