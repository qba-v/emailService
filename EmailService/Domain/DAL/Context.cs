using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
               : base(options)
        {
        }

        public DbSet<Email> Email { get; set; }

    }
}
