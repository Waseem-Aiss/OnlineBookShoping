using Microsoft.EntityFrameworkCore;
using OnlineBookShoping.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser,IdentityRole>(Options => Options.SignIn.RequireConfirmedAccount=true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI().AddDefaultTokenProviders();

builder.Services.AddTransient<IHomeRepository, HomeRepository>();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
