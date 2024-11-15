using Alumni.Web;
using Alumni.Web.Areas.Identity;
using Alumni.Web.Data;
using Alumni.Web.Infrastructure;
using Alumni.Web.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.GetSection(AppSettings.SectionName).Bind(AppSettings.Settings);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(AppSettings.Settings.ConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
{ 
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 4;
    options.Password.RequireUppercase = true;
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ApplyDatabaseMigrations(); 
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGalleryService, GalleryService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<INoticeService, NoticeService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
