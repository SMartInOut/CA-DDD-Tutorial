using BuberDinner.Application;
using BuberDinner.Infrastructure;

namespace BuberDinner.Api;

public static class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		{
			builder.Services
				.AddApplication()
				.AddInfrastructure(builder.Configuration);
			
			builder.Services.AddControllers();
		}
		
		var app = builder.Build();
		{
			app.UseHttpsRedirection();
			app.MapControllers();
			app.Run();
		}
	}
}
