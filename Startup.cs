namespace PrivateNotes
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Security.Claims;
    using PrivateNotes.Helpers;
    using PrivateNotes.Models;
    using PrivateNotes.Services;
    using PrivateNotes.Services.Repositories;

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
            services.AddRazorPages();

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            var config2 = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PrivateNotesContext>(options =>
            options.UseNpgsql(config2));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));

            services.AddScoped<INoteService, NoteService>();
            services.AddScoped(typeof(INoteRepository<>), typeof(NoteRepository<>));

            services.AddAutoMapper(typeof(UserProfile));
            services.AddAutoMapper(typeof(NoteMapper));

            services.AddCors();
            services.AddControllers();

            services.AddAuthentication("Cookie")
                .AddCookie("Cookie", config =>
                {
                    config.LoginPath = "/Index";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("authorized", builder =>
                {
                    builder.RequireClaim(ClaimTypes.Role, "authorized");
                });
            });
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
