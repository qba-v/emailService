using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DAL.Commands.Interfaces
{
    public interface IEmailCommands
    {
        Email Create(Email email);
        void Update(IEnumerable<Email> emailsToSend);
    }
}
