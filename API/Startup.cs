using API.Data;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API {
  public class Startup {
    private readonly IConfiguration config;
    public Startup (IConfiguration config) 
    {
      this.config = config;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices (IServiceCollection services) {
      services.AddControllers ();
      services.AddScoped<IListRepository, ListRepository>();
      services.AddDbContext<DataContext> (options => {
        options.UseSqlite (config.GetConnectionString("DefaultConnection"));
      });
      services.AddCors();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment ()) {
        app.UseDeveloperExceptionPage ();
      }

      app.UseHttpsRedirection ();

      app.UseRouting ();

      app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod()
        .WithOrigins("https://localhost:4200"));

      app.UseAuthorization ();

      app.UseEndpoints (endpoints => {
        endpoints.MapControllers ();
      });
    }
  }
}