using Domain.DAL.Commands.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DAL.Commands
{
    public class EmailComannds : IEmailCommands
    {
        private readonly Context _context;


        public EmailComannds(Context context)
        {
            _context = context;
        }

        public Email Create(Email email)
        {
            try
            {
                _context.Email.Add(email);
                _context.SaveChanges();

                return email;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void Update(IEnumerable<Email> emailsToSend)
        {
            try
            {
                foreach (var email in emailsToSend)
                {
                    email.Status = "sent";
                    _context.Entry(email).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
