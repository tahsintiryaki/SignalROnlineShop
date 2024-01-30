
using SignalRServer.API.Controllers;
using SignalRServer.API.IService;
using SignalRServer.API.Service;

namespace SignalRServer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR().AddJsonProtocol(options => {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });
            builder.Services.AddSingleton<IHubGameDispatcher, HubGameDispatcher>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.WithOrigins("https://localhost:7286", "https://localhost:5257").  //Ýstediðimiz kadar client ekleyebiliyoruz.
                     AllowAnyHeader().
                     AllowAnyMethod().
                     AllowCredentials();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
            app.MapHub<GamesHub>("/gameHub");
            app.UseCors("CorsPolicy");  //Tanýmladýðýmýz Policy'i kullanýyoruz.
            app.Run();
        }
    }
}
