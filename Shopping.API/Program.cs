using Shopping.API.Data;

namespace Shopping.API
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
            builder.Services.AddSingleton<ProductContext>();
            builder.Services.AddLogging();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseSwagger();
               app.UseSwaggerUI();
                  

            app.UseAuthorization();

           

            app.MapControllers();

            app.Run();
        }
    }
}