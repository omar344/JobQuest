
using JobQuest.Data;
using JobQuest.DTO;
using JobQuest.Interface;
using JobQuest.Repository;
using Microsoft.EntityFrameworkCore;

namespace JobQuest
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddDbContext<PlatformDbContext>(
		    options => options.UseSqlServer(
		    builder.Configuration.GetConnectionString("ConnectionString")));



			// Add services to the container.
			builder.Services.AddScoped<IClientRepository, ClientRepository>();
			builder.Services.AddScoped<IJobRepository, JobRepository>();
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

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

			app.Run();
		}
	}
}
