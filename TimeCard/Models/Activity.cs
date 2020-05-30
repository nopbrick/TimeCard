namespace TimeCard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            Employee_Activities = new HashSet<Employee_Activities>();
        }

        public int ActivityID { get; set; }

        [Required]
        [StringLength(100)]
        public string ActivityName { get; set; }

        [Required]
        [StringLength(10)]
        public string ActivityCode { get; set; }

        [StringLength(200)]
        public string ActivityDescription { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee_Activities> Employee_Activities { get; set; }
    }
}
