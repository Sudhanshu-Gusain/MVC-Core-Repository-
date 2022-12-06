
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VasuBookStore

{
    public class Startup
    {
        // all the services used into a application are configure here.
        //Method called at runtime
        // use this method to add services to the container.

        public void ConfigureServices(IServiceCollection service) //To add all the Dependencies which we are going to use in this application.
                                                                   //If we want to use MVc design pattern.

            //There are 2 ways to add MVC
        {
            // 1)
            // *** service.AddMvc();

            //2) But we are using 3.0, we got few more methods.
            // *** service.AddControllers();
            
            //We need Views also so we will use in current application so we use this.

            service.AddControllersWithViews();
        }

        // This method is used as a middleware into the app.
        // Middleware is everthing use in Http call into the application are  configure here.
        // use this method to configure ***HTTP PIPELINE *** 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //IWebHostEnvironment - To get the access the current environment.
                                                                                //Provides information about the web hosting environment an application is running
        {
            //env.IsEnvironment - Compares the current host environment name against the specified value.
            //env.IsProduction - Checks if the current host environment name is Microsoft.Extensions.Hosting.EnvironmentName.Production.
            //env.IsStaging - Checks if the current host environment name is Microsoft.Extensions.Hosting.EnvironmentName.Staging
            //A staging environment (stage) is a nearly exact replica of a production environment for software testing.
            //Staging environments are made to test codes, builds, and updates to ensure quality under a production-like environment
            //before application deployment.

            if (env.IsDevelopment())//Checks if the current host environment name is Microsoft.Extensions.Hosting.EnvironmentName.Development.
            {
                app.UseDeveloperExceptionPage(); //MIDDLEWARE
            }

            //app - create a new middleware
            //use- create and adds a middleware delegate to application request pipeline.

            // ** CODE ** 
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from first middleware"); // THIS IS TOO MIDDLEWARE
            //    await next();
            //    await context.Response.WriteAsync("Hello from first middleware Response.");
            //});

            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("Hello from second middleware");
            //     await next();
            //     await context.Response.WriteAsync("Hello from second middleware Response.");
            // });

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from third middleware");
            //    await next(); // iF WE DON'T USE THIS NEXT(), AFTER THIS MIDDLEWARE WILL NOT CONSIDER IN THE HTTP PIPELINE.
            //    await context.Response.WriteAsync("Hello from third middleware Response.");
            //});

            //Enable Routing
            //Adds a routing that matches HTTP Get request for specified pattern.
            //** Map a particular URL to a particular resource.
            app.UseRouting();

            //Do default Routing.
            app.UseEndpoints(endpoints =>
            {
                // ** Here we are mapping the particualar url  to the resource through [*** MapGet() ***]\

                // We can use Map() method here.
                //MapGet() - will handle the incoming request for particular Route 
                //Map() - Will  handle all the request for particular Route, means every route contain '/' will call it.

               // *** endpoints.MapGet("/", async context => await context.Response.WriteAsync("'Hello world'"));

                endpoints.MapDefaultControllerRoute(); // By calling this Home controller index method will call.
                                                      // This method  adds the default route {Controller}/{action=index()}/{id?}


                // *** endpoints.MapGet("/", async context =>
                //{     
                //    if (env.IsDevelopment())
                //    {
                //        await context.Response.WriteAsync("Development environment");
                //    }
                //    else if (env.IsProduction())
                //    {
                //        await context.Response.WriteAsync("Production environment");

                //    }
                //    else if (env.IsStaging())
                //    {
                //        await context.Response.WriteAsync("Staging environment");
                //    }
                //    else
                //    {
                //        await context.Response.WriteAsync(env.EnvironmentName);
                //    }
                //    // **** THESE WILL CHANGE ACCORDING TO ENVIRONMENT VARIABLE INSIDE THE [ *** LAUNCHSETTING.JSON ***] FILE.]
                //    //ENVIRONMENT WE DEFINE THERE WILL CALL HERE ONLY.
                //});

                //IF WE WANT TO COMOPARE THE ENVIRONMENTS THEN,
                
                //endpoints.MapGet("/", async context =>
                //{
                //    if(env.IsEnvironment("Development"))
                //    {
                //        await context.Response.WriteAsync("Hello from custom environment.");
                //    }
                //    else
                //    {
                //        await context.Response.WriteAsync(env.EnvironmentName);
                //    }
                //});
            });

            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapGet("/Sudhanshu", async context => await context.Response.WriteAsync("Hello from sudhanshu.."));
            //    }
            //    );
            //}
        }
    }
}