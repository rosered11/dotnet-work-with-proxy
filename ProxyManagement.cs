using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Client.With.Proxy.Demo
{
    public static class ProxyManagement
    {
        public static List<string> ignore = new List<string> { "/api/A" };
        public static void ConfigWithProxy(this IApplicationBuilder app, IConfiguration configuration)
        {
            // First pipeline
            app.Use(async (context, next) => 
            {
                if (ignore.Contains(context.Request.Path.Value))
                {
                    context.Request.Headers.Remove("X-Forwarded-For");
                    context.Request.Headers.Remove("X-Forwarded-Proto");
                }
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
