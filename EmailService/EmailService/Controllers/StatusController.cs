using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IEmailQueries _emailQueries;

        public StatusController(IEmailQueries emailQueries)
        {
            _emailQueries = emailQueries;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var status = _emailQueries.GetStatusById(id);
                if (status == null)
                    return NotFound();

                return Ok(status);
            }
            catch (Exception ex)
            {
                //Logger.LogError......
                return BadRequest($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
