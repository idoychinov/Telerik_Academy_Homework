namespace EFPerformanceModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkHoursLog
    {
        [Key]
        public int LogID { get; set; }

        public int? WorkHourEntryIDOld { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EntryDateOld { get; set; }

        [StringLength(100)]
        public string TaskOld { get; set; }

        public int? EntryHoursOld { get; set; }

        [StringLength(200)]
        public string EntryCommentsOld { get; set; }

        public int? EmployeeIDOld { get; set; }

        public int? WorkHourEntryIDNew { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EntryDateNew { get; set; }

        [StringLength(100)]
        public string TaskNew { get; set; }

        public int? EntryHoursNew { get; set; }

        [StringLength(200)]
        public string EntryCommentsNew { get; set; }

        public int? EmployeeIDNew { get; set; }

        [StringLength(10)]
        public string CommandType { get; set; }
    }
}
