using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DAL.Commands.Interfaces;
using Domain.DAL.Queries.Interfaces;
using Domain.Entities;
using EmailService.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {

        private readonly IEmailCommands _emailCommands;
        private readonly IEmailQueries _emailQueries;
        private readonly IMailService _emailService;

        public ProcessController(IEmailQueries emailQueries, IMailService emailService, IEmailCommands emailCommands)
        {

            _emailQueries = emailQueries;
            _emailService = emailService;
            _emailCommands = emailCommands;
        }

        [HttpPost]
        public IActionResult Send(bool priorityRequired)
        {
            try
            {
                var emailsToSend = _emailQueries.Browse(x => x.Status == "pending");

                var result = _emailService.Send(emailsToSend, priorityRequired);

                if (!result.Success)
                    return BadRequest("Wystąpił błąd wysyłki maili");

                
                _emailCommands.Update(emailsToSend);
                return Ok();
            }
            catch (Exception ex)
            {
                //Logger.LogError......
                return BadRequest($"Wystąpił błąd: {ex.Message}");
            }
        }
    }
}
