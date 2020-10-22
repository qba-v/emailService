using Domain.Entities;
using EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Service
{
    public interface IMailService
    {
        EmailResponse Send(IEnumerable<Email> emails, bool concerinPriority = false);
    }
}
