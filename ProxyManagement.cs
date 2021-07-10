using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.With.Proxy.Demo
{
    public static class ProxyManagement
    {
        public static void ConfigWithProxy(this IApplicationBuilder app, IConfiguration configuration)
        {
            // First pipeline
            app.Use(async (context, next) => 
            {
                //await context.Response.WriteAsync("First pipeline step 1");
                await next();
                //await context.Response.WriteAsync("First pipeline step 2");
            });

            // Forward pipeline
            app.UseWhen(c => c.Request.Query.ContainsKey("forward"), a =>
            {
                //a.Run(async context => {
                //    await context.Response.WriteAsync("Forward pipeline");
                //});
            });

            // Second pipeline
            //app.Run(async context => 
            //{
            //    //await context.Response.WriteAsync("Secound pipeline step 1");
            //});
        }
    }
}
