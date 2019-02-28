using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Administration;
using Ocelot.Provider.Consul;

namespace Ocelot.ApiGateways
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var ocelotBuilder = services.AddOcelot(new ConfigurationBuilder().AddJsonFile("ocelot.json").Build());
            
            ocelotBuilder.AddAdministration("/admin", options => {
                options.Authority = "http://localhost:6003";
                options.ApiName = "ocelot.admin";
                // options.SupportedTokens = IdentityServer4.AccessTokenValidation.SupportedTokens.Both;
                // options.ApiSecret = "secret";
                options.RequireHttpsMetadata = false;
            });

            ocelotBuilder.AddConsul();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseOcelot().Wait();
            app.UseMvc();
        }
    }
}
