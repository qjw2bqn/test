using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace gdal
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use((next)=> {
                Console.WriteLine("A");

                return async (context) =>
                {

                    Console.WriteLine("A-BeginNext");
                    
                    await next(context);

                    Console.WriteLine("A-EndNext");
                };
            });

            app.Use((next) => {
                Console.WriteLine("B");

                return async (context) =>
                {

                    Console.WriteLine("B-BeginNext");

                    await next(context);

                    Console.WriteLine("B-EndNext");
                };
            });

            app.Use((next) => {
                Console.WriteLine("C");

                return async (context) =>
                {

                    Console.WriteLine("C-BeginNext");

                    await context.Response.WriteAsync("Hello World!");
                    //await next(context);

                    Console.WriteLine("C-EndNext");
                };
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
