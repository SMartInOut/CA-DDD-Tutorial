using BuberDinner.Api.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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

			// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
			builder.Services.AddControllers();

			builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
		}

		var app = builder.Build();
		{
			// app.UseMiddleware<ErrorHandlingMiddleware>();
			app.UseExceptionHandler("/error");
			app.UseHttpsRedirection();
			app.MapControllers();
			app.Run();
		}
	}
}
