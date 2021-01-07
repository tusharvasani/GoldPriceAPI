using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GoldPriceAPI.FixerCurrAPI;
using Newtonsoft.Json;

namespace GoldPriceAPI
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static void GetCurrencyRate()
        {
            RequestParam paramList = new RequestParam();
            paramList.AccessKey = Common.CurrencyRateKey;
            paramList.FromSymbol=  "HKD";
            paramList.ToSymbol = "INR";
            paramList.Amount = 1;
            paramList.DateVal = DateTime.Now;
            
            string jsonData = JsonConvert.SerializeObject(paramList);
            try
            {
                Response objReponse = FixerCurrencyController.CallApi(Common.FixerAPIURL, "convert", jsonData);
                if(objReponse != null)
                {

                }
            }
            catch(Exception ex)
            {
             
            }
        }
    }
}
