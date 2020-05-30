namespace TimeCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class All_Sheets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public All_Sheets()
        {
            Employee_Activities = new HashSet<Employee_Activities>();
        }

        [Key]
        public int SheetID { get; set; }

        [Column(TypeName = "date")]
        public DateTime SheetDate { get; set; }

        public int? TotalHours { get; set; }

        public int EmployeeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Activities> Employee_Activities { get; set; }
    }
}
