using Domain.Entities;
using EmailService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Service
{
    public class MailService : IMailService
    {
        public EmailResponse Send(IEnumerable<Email> emails, bool priorityRequired = false)
        {
            try
            {
                EmailResponse response = new EmailResponse();

                if (priorityRequired)
                    emails = emails.OrderByDescending(x => x.Priority);

                foreach (var email in emails)
                {
                    //Here should be creation of MailMessage from e.g. System.Net.Mail
                    //Assing data: email object to MailMessage object
                    
                    //Here should be implementation of sending email using SMTP account
                    //Something Like:
                    //string smtipServer = ...                    
                    //using (SmtpClient client = new SmtpClient(smtipServer))
                    //{
                    //    client.Send(message);
                    //}
                }
                response.Success = true;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
