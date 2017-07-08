using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Motherlode.Web.Controllers
{
	[Route("api/[controller]")]
	public class RigsController : Controller
	{
		private static IList<Rig> Rigs = new List<Rig>
		{
			new Rig
			{
				Id = Guid.NewGuid(),
				Name = "rig01"
			}
		};

		[HttpGet()]
		public IActionResult Get()
		{
			return Ok(Rigs);
		}
	}
	
	public class Rig
	{
		public Guid Id { get; set; }

		public String Name { get; set; }

		public String IpAddress { get; set; }

		public DateTime? FirstSeen { get; set; }

		public DateTime? LastSeen { get; set; }
	}
}
