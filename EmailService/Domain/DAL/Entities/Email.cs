using Domain.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Status { get; set; } = "pending";
        public List<Recipient> Recipients { get; set; }
        public string Sender { get; set; }
        public int Priority { get; set; } = 1;

    }


}
