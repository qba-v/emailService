using Domain.DAL.Queries.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.DAL.Queries
{
    public class EmailQueries : IEmailQueries
    {
        private readonly Context _context;


        public EmailQueries(Context context)
        {
            _context = context;
        }
        public Email GetById(int emailId)
        {
            try
            {
                var email = _context.Email.Include(x => x.Recipients).FirstOrDefault(x => x.Id == emailId);
                if (email != null)
                    return email;

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetStatusById(int emailId)
        {
            try
            {
                var email = _context.Email.Find(emailId);
                if (email != null)
                    return email.Status;

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Email> Get()
        {
            try
            {
                var emails = _context.Email.Include(x => x.Recipients).ToList();
                return emails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Email> Browse(Func<Email,bool> predicate)
        {
            try
            {
                var emails = _context.Email.Where(predicate).ToList();
                return emails;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
