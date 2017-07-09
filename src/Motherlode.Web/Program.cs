using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace Motherlode_Web
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = new WebHostBuilder()
				.UseSetting(WebHostDefaults.PreventHostingStartupKey, "true")
				.ConfigureLogging((context, builder) =>
				{
					builder.AddConfiguration(context.Configuration.GetSection("Logging"));
					builder.AddConsole();
					builder.AddDebug();
				})
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();

			host.Run();
		}
	}
}
