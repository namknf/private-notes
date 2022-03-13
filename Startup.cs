using Microsoft.AspNetCore.Identity;
using PrivateNotes.Models;

namespace PrivateNotes
{
    using System;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using PrivateNotes.Data;
    using PrivateNotes.Helpers;
    using PrivateNotes.Mappers;
    using PrivateNotes.Repositories.Account;
    using PrivateNotes.Repositories.Note;
    using PrivateNotes.Services.Auth;
    using PrivateNotes.Services.Note;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication("Cookie")
                .AddCookie("Cookie", config =>
                {
                    config.LoginPath = "/Authorization";
                    config.AccessDeniedPath = "/Index";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Authorized", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "authorized");
                });
            });
            services.AddRazorPages();

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            var config2 = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PrivateNotesContext>(options =>
            options.UseNpgsql(config2));

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped(typeof(IAccountRepository<>), typeof(AccountRepository<>));

            services.AddScoped<INoteService, NoteService>();
            services.AddScoped(typeof(INoteRepository<>), typeof(NoteRepository<>));

            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(NoteMapper));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<PrivateNotesContext>();

            services.AddCors();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCookiePolicy();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(x => x.MapControllers());
        }
    }
}
