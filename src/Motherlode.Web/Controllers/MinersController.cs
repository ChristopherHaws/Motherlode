using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Motherlode.Web.Controllers
{
	[Route("api/[controller]")]
	public class MinersController : Controller
	{
		// GET: api/miners
		[HttpGet]
		public IEnumerable<Miner> Get()
		{
			return new Miner[]
			{
				new Miner
				{
					Name = "EWBF"
				},
				new Miner
				{
					Name = "excavator"
				},
				new Miner
				{
					Name = "nheqminer"
				},
				new Miner
				{
					Name = "eqm"
				}
			};
		}

		// GET api/miners/5
		[HttpGet("{id}")]
		public string Get(Int32 id)
		{
			return "value";
		}

		// POST api/miners
		[HttpPost]
		public void Post([FromBody] String value)
		{
		}

		// PUT api/miners/5
		[HttpPut("{id}")]
		public void Put(Int32 id, [FromBody] String value)
		{
		}

		// DELETE api/miners/5
		[HttpDelete("{id}")]
		public void Delete(Int32 id)
		{
		}
	}

	public class Miner
	{
		public String Name { get; set; }
	}
}
