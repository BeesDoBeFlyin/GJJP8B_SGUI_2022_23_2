using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Repository;
using GJJP8B_HFT_2021221.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GJJP8B_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CheeseContext>();

            services.AddScoped<IRepository<Milk>, MilkRepository>();
            services.AddScoped<IRepository<Cheese>, CheeseRepository>();
            services.AddScoped<IRepository<Buyer>, BuyerRepository>();

            services.AddScoped<IMilkLogic, MilkLogic>();
            services.AddScoped<ICheeseLogic, CheeseLogic>();
            services.AddScoped<IBuyerLogic, BuyerLogic>();

            services.AddSignalR();
            services.AddControllers();
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:8281"));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
