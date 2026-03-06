using Microsoft.EntityFrameworkCore;
using OnlineBookShoping.Data;
using Microsoft.AspNetCore.Identity;
using OnlineBookShoping.Repositories.IRepository;
using OnlineBookShoping.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser,IdentityRole>
    (Options => Options.SignIn.RequireConfirmedAccount=false)
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddTransient<IHomeRepository, HomeRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IBookRepository , BookRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();
// for automatic request.. 
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.AddDefaulData(scope.ServiceProvider);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();


app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

app.Run();
