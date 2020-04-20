using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using Microsoft.Extensions.Logging;
using ContosoUniversity.Models.Injection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using ContosoUniversity.Models;
using ContosoUniversity.Middleware;

namespace ContosoUniversity
{
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddRazorPages();

            //services.AddHttpClient("github", x =>
            //{
            //    x.BaseAddress = new Uri("https://api.github.com/");
            //    x.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            //    x.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");

            //});

            services.AddHttpClient<GitHubService>(c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            services.AddDbContext<SchoolContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SchoolContext")));

            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            //services.AddScoped<IMyDependency, MyDependency>();
            services.AddScoped<IMyDependency>(x => new MyDependency("To jest message z parametru"));
            services.TryAddScoped<IMyDependency>(x => new MyDependency("To jest message z parametru po try"));

           
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

            app.UseHttpContextItemsMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });

            //----------------------------------------------------------------------------------------

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseDatabaseErrorPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //// app.UseCookiePolicy();

            //app.UseRouting();
            //// app.UseRequestLocalization();
            //// app.UseCors();

            //app.UseAuthentication();
            //app.UseAuthorization();
            //// app.UseSession();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller=Home}/{action=Index}/{id?}");
            //});

            //----------------------------------------------------------------------------------------------------------------

            //app.UseWhen(context => context.Request.Query.ContainsKey("branch"),
            //                  HandleBranch);

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from non-Map delegate. <p>");
            //});

            //----------------------------------------------------------------------------------------------------------------------

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //// Approach 1: Writing a terminal middleware.
            //app.Use(next => async context =>
            //{
            //    if (context.Request.Path == "/")
            //    {
            //        await context.Response.WriteAsync("Hello terminal middleware!");
            //        return;
            //    }

            //    await next(context);
            //});

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    // Approach 2: Using routing.
            //    endpoints.MapGet("/Movie", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello routing!");
            //    });
            //});


        }

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                var branchVer = context.Request.Query["branch"];
                await context.Response.WriteAsync($"Branch used = {branchVer}");
            });
        }
    }
}
