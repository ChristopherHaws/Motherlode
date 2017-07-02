using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Motherlode_Web.Controllers
{
	[Route("api/[controller]")]
	public class GpuController : Controller
	{
		private static String[] Gpus = new[]
		{
			"GeForce GTX 1080 Ti", "GeForce GTX 1070 OC", "GeForce GTX 980 Ti"
		};

		[HttpGet()]
		public IEnumerable<Gpu> Get()
		{
			var rng = new Random();

			var index = 0;

			foreach (var gpu in Gpus)
			{
				yield return new Gpu
				{
					Id = index++,
					TemperatureC = rng.Next(55, 85),
					Name = gpu
				};
			}
		}

		public class Gpu
		{
			public Int32 Id { get; set; }
			public Double TemperatureC { get; set; }
			public String Name { get; set; }

			public Double TemperatureF => 32 + (this.TemperatureC / 0.5556d);
		}
	}
}
