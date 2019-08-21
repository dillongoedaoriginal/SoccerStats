using System;
using Data;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Soccer.Api.Graph;
using Soccer.Contracts.Interfaces;

namespace Soccer.Graph.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


            services.AddScoped<SoccerContext>();
            services.AddScoped<IStatsProvider, PostgresStatsProvider>();
            services.AddScoped<ITeamsProvider, PostgresTeamsProvider>();


            services.AddScoped<IServiceProvider>(x => new FuncServiceProvider(x.GetRequiredService));
            services.AddScoped<SoccerSchema>();
            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in development mode. make it switchable.
            })
             .AddGraphTypes(ServiceLifetime.Scoped);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseGraphQL<SoccerSchema>();
            app.UseGraphiQl();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });


        }
    }
}
