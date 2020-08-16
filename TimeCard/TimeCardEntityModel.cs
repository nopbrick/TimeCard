namespace TimeCard
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TimeCardEntityModel : DbContext
    {
        public TimeCardEntityModel()
            : base("name=TimeCardEntityModel")
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<All_Sheets> All_Sheets { get; set; }
        public virtual DbSet<Employee_Activities> Employee_Activities { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .Property(e => e.ActivityName)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.ActivityCode)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .Property(e => e.ActivityDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Activity>()
                .HasMany(e => e.Employee_Activities)
                .WithRequired(e => e.Activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<All_Sheets>()
                .HasMany(e => e.Employee_Activities)
                .WithRequired(e => e.All_Sheets)
                .HasForeignKey(e => e.MasterSheetID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee_Activities>()
                .Property(e => e.ActivityComment)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee_Activities)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);
        }
    }
}
