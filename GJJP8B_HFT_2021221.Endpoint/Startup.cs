using GJJP8B_HFT_2021221.Data;
using GJJP8B_HFT_2021221.Logic;
using GJJP8B_HFT_2021221.Repository;
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
            services.AddControllers();
            services.AddTransient<IMilkLogic, MilkLogic>();
            services.AddTransient<ICheeseLogic, CheeseLogic>();
            services.AddTransient<IBuyerLogic, BuyerLogic>();

            services.AddTransient<IMilkRepository, MilkRepository>();
            services.AddTransient<ICheeseRepository, CheeseRepository>();
            services.AddTransient<IBuyerRepository, BuyerRepository>();
            services.AddDbContext<CheeseContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
