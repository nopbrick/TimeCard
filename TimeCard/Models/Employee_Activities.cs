namespace TimeCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [NotMapped] 
    public partial class TempEmployeeActivities : Employee_Activities {} 
    public partial class Employee_Activities
    {
        [Key]
        public int EmployeeActivityID { get; set; }

        public int ActivityID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime ActivityDate { get; set; }

        public int ActivityTime { get; set; }

        public int MasterSheetID { get; set; }

        [StringLength(200)]
        public string ActivityComment { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual All_Sheets All_Sheets { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
