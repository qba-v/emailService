using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DAL.Entities
{
    public class Recipient
    {
        public int Id { get; set; }
        public int EmailId { get; set; }
        public string Address { get; set; }
    }
}
