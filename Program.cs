using AuctionApplication.Core;
using AuctionApplication.Core.Interfaces;
using AuctionApplication.Persistence;
using Microsoft.AspNetCore.Identity;
using AuctionApplication.Data;
using AuctionApplication.Areas.Identity.Data;
using AuctionApplication.Persistence.Repositories;
using AuctionApplication.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionPersistence, AuctionSqlPersistence>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserPersistence, UserPersistence>();

builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuctionUnitOfWork, AuctionUnitOfWork>();
builder.Services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();


builder.Services.AddDbContext<AuctionDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbConnection")));

builder.Services.AddDbContext<AuctionApplicationIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionDbIdentityConnection")));

builder.Services.AddDefaultIdentity<AuctionApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuctionApplicationIdentityContext>();

builder.Services.AddAutoMapper(typeof(Program));

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AuctionApplicationUser>>();

    string name = "admin@auctionapp.com";

    if(await userManager.FindByNameAsync(name) == null)
    {
        var user = new AuctionApplicationUser();
        user.UserName = name;
        user.Email = name;

        await userManager.CreateAsync(user, app.Configuration["Identity:AdminPassword"]);

        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.Run();
