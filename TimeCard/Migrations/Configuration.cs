
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace TimeCard.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TimeCard.Classes.TimeCardDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    } 
}