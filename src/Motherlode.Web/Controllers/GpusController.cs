using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Motherlode.Common.Miners;
using Motherlode.Miners.Ewbf;
using Motherlode.Miners.Ewbf.Configuration;

namespace Motherlode_Web.Controllers
{
	[Route("api/rigs/{rigId:guid}/[controller]")]
	public class GpusController : Controller
	{
		private static ConcurrentDictionary<String, IMiner> Miners = new ConcurrentDictionary<String, IMiner>();

		private static List<RigGpu> GPUs = new List<RigGpu>
		{
			new RigGpu
			{
				Id = "0",
				Temperature = 55,
				Name = "GeForce GTX 980 Ti",
				MinerName = "EWBF",
				IsEnabled = false
			},
			new RigGpu
			{
				Id = "1",
				Temperature = 80,
				Name = "GeForce GTX 1080 Ti",
				MinerName = "EWBF",
				IsEnabled = false
			},
			new RigGpu
			{
				Id = "2",
				Temperature = 78,
				Name = "GeForce GTX 1070 OC",
				MinerName = "EWBF",
				IsEnabled = false
			}
		};

		[HttpGet("api/[controller]")]
		public IActionResult Get()
		{
			var rand = new Random();

			foreach (var gpu in GPUs)
			{
				gpu.Temperature = rand.Next(55, 85);
			}

			return Ok(GPUs);
		}
		
		public IActionResult GetForRig(Guid rigId)
		{
			var rand = new Random();

			foreach (var gpu in GPUs)
			{
				gpu.Temperature = rand.Next(55, 85);
			}

			return Ok(GPUs);
		}

		[HttpPut("{id}")]
		public IActionResult Put(Guid rigId, String id, [FromBody] RigGpu gpu)
		{
			var index = GPUs.FindIndex(x => x.Id == id);

			if (index < 0)
			{
				return this.NotFound();
			}
			
			GPUs[index] = gpu;

			return Ok(gpu);
		}

		[HttpPut("{id}/enable")]
		public IActionResult Enable(Guid rigId, String id)
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

				var config = new EwbfConfiguration
				{
					CudaDevices = new List<Device>
					{
						new Device
						{
							Id = 0,
							Intensity = 64
						}
					},
					TempuratureLimit = 80,
					TempuratureScale = TempuratureScale.Celcius,
					CalculatePowerEfficiency = true,
					LogLevel = 1,
					LogFile = "miner.log",
					Servers = new List<StratumServer>
					{
						new StratumServer
						{
							Address = "us1-zcash.flypool.org",
							Port = 3333,
							Username = "t1KjwjJLHpnpSnfZdAULrc93NTi8AudtTAe.rig01",
							Password = "x"
						},
						new StratumServer
						{
							Address = "equihash.usa.nicehash.com",
							Port = 3357,
							Username = "1J8Z7jLvbN5u616BfhAgBYMz5wgmhR2LpB.rig01",
							Password = "x"
						}
					}
				};

				return new EwbfMiner(log, @"C:\Users\chaws\Desktop\Mining\ZEC\EWBF\0.3.4b 2", id.ToString(), config);
			});

			if (miner.IsRunning)
			{
				return this.BadRequest();
			}

			miner.Start();

			return Ok();
		}
		
		[HttpPut("{id}/disable")]
		public IActionResult Disable(Guid rigId, String id)
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

		public class RigGpu
		{
			public String Id { get; set; }

			public String BusId { get; set; }

			public String Name { get; set; }

			public Decimal HashRate { get; set; }

			public Decimal Temperature { get; set; }

			public Decimal FanSpeed { get; set; }

			public Decimal PowerUsage { get; set; }

			public Decimal PowerLimit { get; set; }

			public Decimal MaxPowerLimit { get; set; }

			public Decimal CoreClock { get; set; }

			public Decimal MaxCoreClock { get; set; }

			public Decimal MemoryClock { get; set; }

			public Decimal MaxMemoryClock { get; set; }

			public String MinerName { get; set; }

			public Boolean IsEnabled { get; set; }
		}
	}
}
