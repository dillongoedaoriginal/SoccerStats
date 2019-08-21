using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Soccer.Api.Graph;

namespace Soccer.Api
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
            services.AddTransient<IStatsProvider, PostgresStatsProvider>();
            services.AddTransient<ITeamsProvider, PostgresTeamsProvider>();

            services.AddScoped<SoccerSchema>();

            //services.AddGraphQL(x =>
            //{
            //    x.ExposeExceptions = true; //set true only in development mode. make it switchable.
            //})
            //.AddGraphTypes(ServiceLifetime.Scoped);

            //  services.AddControllers();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseGraphQL<SoccerSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphiQl();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
