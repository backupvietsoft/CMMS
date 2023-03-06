using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace VS.Api
{
    public class Startup
    {
        public static string vscnn { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            vscnn = configuration.GetSection("VSConn").Value.ToString();
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddSwaggerGen();

            #region And thong tin chung vao

            //////////services.AddSwaggerGen(options =>
            //////////{
            //////////    options.SwaggerDoc("v1.0", new OpenApiInfo
            //////////    {
            //////////        Version = "v1.0",
            //////////        Title = "ToDo API",
            //////////        Description = "VS.Api V1",
            //////////        TermsOfService = new Uri("https://vietsoft.com.vn"),
            //////////        Contact = new OpenApiContact
            //////////        {
            //////////            Name = "Tran Nhat",
            //////////            Url = new Uri("https://vietsoft.com.vn/trannhat")
            //////////        },
            //////////        License = new OpenApiLicense
            //////////        {
            //////////            Name = "License",
            //////////            Url = new Uri("https://vietsoft.com.vn/trannhat")
            //////////        }
            //////////    });
            //////////});

            #endregion
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            ////////app.UseSwaggerUI(c =>
            ////////{
            ////////    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vs.API V1");
            ////////    //c.RoutePrefix = string.Empty;
            ////////});


            ////////if (env.IsDevelopment())
            ////////{
            ////////    app.UseDeveloperExceptionPage();
            ////////}
            ////////else
            ////////{
            ////////    app.UseHsts();
            ////////}


            ////////app.UseSwaggerUI(c =>
            ////////{
            ////////    if (env.IsDevelopment())
            ////////    {
            ////////        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
            ////////    }
            ////////    else
            ////////    {
            ////////        // To deploy on IIS
            ////////        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");
            ////////    }

            ////////});

            //app.UseSwaggerUI(c =>
            //{
            //    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            //    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "VS.Api");
            //});

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Vs.API");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
            
        }

        //public static void RegisterRoutes(RouteCollection routes)
        //{
        //    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        //    //ASP.NET Web API Route Config
        //    routes.MapHttpRoute(
        //        name: "swagger_root",
        //        routeTemplate: "",
        //        defaults: null,
        //        constraints: null,
        //        handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger"));

        //    routes.MapRoute(
        //        name: "Default",
        //        url: "{controller}/{action}/{id}",
        //        defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        //    );
        //}

    }


    

}
