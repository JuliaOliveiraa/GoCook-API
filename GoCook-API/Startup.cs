using GoCook_API.Interfaces;
using GoCook_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Configuration;
using Microsoft.Extensions.Configuration;


namespace GoCook_API;


public class Startup
{
    public IConfiguration _configuration { get; }

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IReceitaService, ReceitaService>();
        services.AddScoped<Facade>();

        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<GoCookDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "GoCook", Version = "v1" });
        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        app.UseRouting(); // Adicione esta linha para habilitar o roteamento.

        //app.Use(async (context, next) =>
        //{
        //    await next.Invoke();
        //    await context.Response.WriteAsync("API GoCook funcionando, siga para a swagger: https://gocook.azurewebsites.net/swagger/index.html");
        //});

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers(); // Esta linha configura os controllers para usar o roteamento.
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoCook");
        });
    }

}
