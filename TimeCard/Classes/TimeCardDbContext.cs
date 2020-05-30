using System.Data.Entity;

namespace TimeCard.Classes
{
    public class TimeCardDbContext : DbContext
    {
        public TimeCardDbContext()
            : base("mssql")
        {
            
        }
    }
}