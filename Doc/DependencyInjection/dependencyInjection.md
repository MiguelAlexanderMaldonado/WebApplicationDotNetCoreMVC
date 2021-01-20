# Dependency Injection

.NET supports the [dependency injection](https://docs.microsoft.com/es-es/dotnet/core/extensions/dependency-injection) (DI) software design pattern, which is a technique for achieving  [Inversion of Control (IoC)](https://docs.microsoft.com/es-es/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion)  between classes and their dependencies. Dependency injection in .NET is a  [first-class citizen](https://en.wikipedia.org/wiki/First-class_citizen), along with configuration, logging, and the options pattern.

A  _dependency_  is an object that another object depends on.

## Services injected into Startup

Services can be injected into the  `Startup`  constructor and the  `Startup.Configure`  method.

Only the following services can be injected into the  `Startup`  constructor when using the Generic Host ([IHostBuilder](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostbuilder)):

-   [IWebHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.iwebhostenvironment)
-   [IHostEnvironment](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostenvironment)
-   [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration)

## The Startup Class

The [Startup Class](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-3.1) configures services and the app's request pipeline.


-   Optionally includes a  [ConfigureServices](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configureservices)  method to configure the app's  _services_. A service is a reusable component that provides app functionality. Services are  _registered_  in  `ConfigureServices`  and consumed across the app via  [dependency injection (DI)](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)  or  [ApplicationServices](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.iapplicationbuilder.applicationservices).

-   Includes a  [Configure](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.startupbase.configure)  method to create the app's request processing pipeline.

`ConfigureServices`  and  `Configure`  are called by the ASP.NET Core runtime when the app starts:

```
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
        services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
```
## **Example** 

* Add service

	```
	public interface IHello
	{
		string SayHello();	
	}
	```

	```
	public class Hello: IHello
	{
		public Hello(){}
		public string SayHello()
		{
			return "Hello from class"
		} 
	}
	```

	```
	public class Startup
	{
		...
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IHello, Hello>();
        }
        ...
	}
	```
	
* Consume registered service

	```
	pubic class HelloController : Controller
	{
		public HelloController (){}

		public IAction Index ()
		{
			var services = this.HttpContext.RequestServices;
	        var hello = (IHello)services.GetService(typeof(IHello));	        
	        hello.SayHello();	    
	        return View();
		}
	}
	```	

### [Multiple Environments](https://docs.microsoft.com/es-es/aspnet/core/fundamentals/environments?view=aspnetcore-3.1#environment-based-startup-class-and-methods) 

[Back to index](../../README.md)