using AddressBookBL.EmailSenderBusiness;
using AddressBookBL.ImplementationOfManagers;
using AddressBookBL.InterfacesOfManagers;
using AddressBookDL;
using AddressBookDL.ImplementationsOfRepo;
using AddressBookDL.InterfacesOfRepo;
using AddressBookEL.IdentityModels;
using AddressBookEL.Mapping;
using AddressBookPL.DefaultData;
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

var lockoutOptions = new LockoutOptions()
{
    AllowedForNewUsers = true,
    DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1),
    MaxFailedAccessAttempts = 2
};

//identity ayar�
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "qwertyuopasdfghjklizxcvbnm-_1234567890";
    options.Lockout = lockoutOptions;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<MyContext>();

//auto mapper ayarlar�
builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile(typeof(Maps));
});

//interfacelerin DI i�in ya�am d�ng�leri (AddScoped)
builder.Services.AddScoped<ICityManager,CityManager>();
builder.Services.AddScoped<ICityRepo,CityRepo>();

builder.Services.AddScoped<IDistrictManager,DistrictManager>();
builder.Services.AddScoped<IDistrictRepo,DistrictRepo>();

builder.Services.AddScoped<INeighbourhoodManager, NeighbourhoodManager>();
builder.Services.AddScoped<INeighbourhoodRepo, NeighbourhoodRepo>();

builder.Services.AddScoped<IUserAddressManager, UserAddressManager>();
builder.Services.AddScoped<IUserAddressRepo, UserAddressRepo>();

builder.Services.AddScoped<IEmailSender, EmailSender>();

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
//Proje ilk �al��aca�� zaman default olarak eklenmesini istedi�iniz verileri ya da ba�ka i�lermleri yazd���n�z class� burada �a��rmal�s�n�z.
//app.Data();

using (var scope = app.Services.CreateScope())
{
    //Resolve ASP .NET Core Identity with DI help
    var userManager = (UserManager<AppUser>?)scope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
    var roleManager = (RoleManager<AppRole>?)scope.ServiceProvider.GetService(typeof(RoleManager<AppRole>));
    // do you things here

    DataDefaultXihan d = new DataDefaultXihan();

    d.CheckAndCreateRoles(roleManager);

}



app.Run(); //Uygulamay� burada �al��t�r�r.
