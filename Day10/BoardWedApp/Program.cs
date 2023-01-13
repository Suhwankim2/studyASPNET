using BoardWedApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BoardWedApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // DB���� �߰�

            builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DbConnection")
                ));

			builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	                .AddEntityFrameworkStores<ApplicationDbContext>()
	                .AddDefaultTokenProviders();


            // �н����� ��å ���� ����
            builder.Services.Configure<IdentityOptions>(
                opt =>
                {
                    opt.Password.RequiredLength = 4; // ���� ���� ����
                    opt.Password.RequireNonAlphanumeric = false; // Ư�� ���� ���
                    opt.Password.RequireDigit = false;// ������ ���
                    opt.Password.RequireLowercase = false; // �ҹ��� ���
                    opt.Password.RequireUppercase = false; // �빮�� ���

                }
                );

            // ���� ���� 
            builder.Services.AddAuthorization(Options =>
            {
                Options.AddPolicy("AdminRolePolicy", policy => policy.RequireRole("Admin"));
            });

            builder.Services.AddAuthorization(Options =>
            {
                Options.AddPolicy("EditRolePolicy", policy => policy.RequireClaim("Edit Role"));
                Options.AddPolicy("DeleteRolePolicy", policy => policy.RequireClaim("Delete Role"));
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // ���� �������� ������ ����ҰŴ�
         

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}