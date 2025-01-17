﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace S13Atelier.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class S13Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<S13Controller> _logger;

        public S13Controller(ILogger<S13Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<S13> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new S13
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
