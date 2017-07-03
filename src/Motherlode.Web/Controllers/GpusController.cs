using System;
using System.Collections.Concurrent;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Motherlode.Common.Miners;
using Motherlode.Miners.Ewbf;

namespace Motherlode_Web.Controllers
{
	[Route("api/[controller]")]
	public class GpusController : Controller
	{
		private static ConcurrentDictionary<Int32, IMiner> Miners = new ConcurrentDictionary<Int32, IMiner>();

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
			var rand = new Random();

			foreach (var gpu in GPUs)
			{
				gpu.TemperatureC = rand.Next(55, 85);
			}

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

		[HttpPut("{id}/enable")]
		public IActionResult Enable(Int32 id)
		{
			var resource = GPUs.SingleOrDefault(x => x.Id == id);

			if (resource == null)
			{
				return this.NotFound();
			}
			
			resource.IsEnabled = true;

			var miner = Miners.GetOrAdd(id, x =>
			{
				var log = new FileMinerLog($"C:\\Applications\\Motherlode\\logs\\Miners\\{id}.log");

				return new EwbfMiner(log);
			});

			if (miner.IsRunning)
			{
				return this.BadRequest();
			}

			miner.Start();

			return Ok();
		}
		
		[HttpPut("{id}/disable")]
		public IActionResult Disable(Int32 id)
		{
			var resource = GPUs.SingleOrDefault(x => x.Id == id);

			if (resource == null)
			{
				return this.NotFound();
			}

			if (!Miners.TryGetValue(id, out var miner))
			{
				return this.NotFound();
			}

			miner.Stop();

			resource.IsEnabled = false;
			
			return Ok();
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
