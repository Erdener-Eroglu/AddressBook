using AddressBookDL;
using AddressBookEL.IdentityModels;
using AddressBookEL.Mapping;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});


//identity ayarý
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "qwertyuopasdfghjklizxcvbnm-_1234567890";
}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

//auto mapper ayarlarý
builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile(typeof(Maps));
});

//interfacelerin DI için yaþam döngüleri (AddScoped)



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles(); //wwwroot

app.UseRouting();

app.UseAuthentication(); //login logout


app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
