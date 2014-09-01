namespace EFPerformanceModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkHour
    {
        [Key]
        public int WorkHourEntryID { get; set; }

        [Column(TypeName = "date")]
        public DateTime EntryDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Task { get; set; }

        public int EntryHours { get; set; }

        [StringLength(200)]
        public string EntryComments { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
