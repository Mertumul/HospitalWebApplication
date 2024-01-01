using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HospitalWebApplication.Data;
using HospitalWebApplication.Areas.Identity.Data;
using HospitalWebApplication.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HospitalWebApplicationContextConnection") ?? throw new InvalidOperationException("Connection string 'HospitalWebApplicationContextConnection' not found.");

builder.Services.AddDbContext<HospitalWebApplicationContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HospitalWebApplicationContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dil Desteði----------------------------------------------------------------------------------------------------
builder.Services.AddLocalization(opt=>
{
    opt.ResourcesPath = "Resources";

});
builder.Services.AddMvc().AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
//Dil Desteði Bitiþ----------------------------------------------------------------------------------------------------


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
//Dil Desteði----------------------------------------------------------------------------------------------------

var supportedCulteres = new[] { "en", "tr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCulteres[0]).AddSupportedCultures(supportedCulteres).AddSupportedUICultures(supportedCulteres);
app.UseRequestLocalization(localizationOptions);
//Dil Desteði Bitiþ----------------------------------------------------------------------------------------------------

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
using (var scope = app.Services.CreateScope())
{
    await DbSeeder.SeedRolesAndAdminAsync(scope.ServiceProvider);
}
app.Run();