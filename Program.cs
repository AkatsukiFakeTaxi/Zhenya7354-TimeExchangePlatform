using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeExchangePlatform.Data;
using TimeExchangePlatform.Models;
using TimeExchangePlatform.Services;

namespace TimeExchangePlatform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TEPDbContext>(c => c.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnectionString")));
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<TEPDbContext>().AddDefaultTokenProviders();

            builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
            builder.Services.AddTransient<IEmailService, EmailService>();
            builder.Services.AddScoped<IOfferService,OfferService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TEPDbContext>();
                db.Database.Migrate();
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
                name: "default",
                pattern: "{controller=Offer}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
