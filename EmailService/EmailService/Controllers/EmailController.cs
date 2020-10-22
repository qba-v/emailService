using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL.Commands.Interfaces;
using Domain.DAL.Queries.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _config;

        private readonly IEmailCommands _emailCommands;
        private readonly IEmailQueries _emailQueries;

        public EmailController(IConfiguration config,
            IEmailCommands emailCommands, IEmailQueries emailQueries)
        {
            _config = config;

            _emailCommands = emailCommands;
            _emailQueries = emailQueries;
        }

        //AllMails
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var emails = _emailQueries.Get();
                if (emails == null)
                    return NotFound();

                return Ok(emails);
            }
            catch (Exception ex)
            {
                //Logger.LogError......
                return BadRequest($"Wystąpił błąd: {ex.Message}");
            }
        }

        //Email Details
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var email = _emailQueries.GetById(id);
                if (email == null)
                    return NotFound();

                return Ok(email);
            }
            catch (Exception ex)
            {
                //Logger.LogError......
                return BadRequest($"Wystąpił błąd: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult CreateEmail(Email email)
        {
            try
            {
                //Here should be validation of email address

                email.Sender = email.Sender ?? _config.GetValue<string>("AppSettings:sender");
                _emailCommands.Create(email);

                return Ok(email);
            }
            catch (Exception ex)
            {
                //Logger.LogError......
                return BadRequest($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
