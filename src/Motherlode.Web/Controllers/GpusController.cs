using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Motherlode_Web.Controllers
{
	[Route("api/[controller]")]
	public class GpusController : Controller
	{
		private static Gpu[] GPUs = new Gpu[]
		{
			new Gpu
			{
				Id = 0,
				TemperatureC = 55,
				Name = "GeForce GTX 980 Ti",
				MinerName = "EWBF",
				IsEnabled = false
			},
			new Gpu
			{
				Id = 1,
				TemperatureC = 80,
				Name = "GeForce GTX 1080 Ti",
				MinerName = "EWBF",
				IsEnabled = false
			},
			new Gpu
			{
				Id = 2,
				TemperatureC = 78,
				Name = "GeForce GTX 1070 OC",
				MinerName = "EWBF",
				IsEnabled = false
			}
		};

		[HttpGet()]
		public IActionResult Get()
		{
			return Ok(GPUs);
		}

		[HttpPut("{id}")]
		public IActionResult Put(Int32 id, [FromBody] Gpu gpu)
		{
			var resource = GPUs.SingleOrDefault(x => x.Id == id);
			
			if (resource == null)
			{
				return this.NotFound();
			}

			GPUs[id] = gpu;

			return Ok(gpu);
		}

		public class Gpu
		{
			public Int32 Id { get; set; }

			public Double TemperatureC { get; set; }

			public String Name { get; set; }

			public String MinerName { get; set; }

			//public Double TemperatureF => 32 + (this.TemperatureC / 0.5556d);

			public Boolean IsEnabled { get; set; }
		}
	}
}
