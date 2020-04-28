using System;
using Microsoft.EntityFrameworkCore;

namespace GoHorseClassLibrary
{
    class ConnectionDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = ExemploDB; Integrated Security = True;
                                Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; 
                                ApplicationIntent = ReadWrite; MultiSubnetFailover = False"
                );
        }
    }
}