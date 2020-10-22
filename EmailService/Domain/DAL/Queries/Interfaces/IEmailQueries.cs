using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DAL.Queries.Interfaces
{
    public interface IEmailQueries
    {
        Email GetById(int emailId);
        IEnumerable<Email> Get();
        IEnumerable<Email> Browse(Func<Email, bool> predicate);
        string GetStatusById(int emailId);
    }
}
