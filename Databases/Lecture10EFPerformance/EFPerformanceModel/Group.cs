namespace EFPerformanceModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Group
    {
        public Group()
        {
            Users = new HashSet<User>();
        }

        public int GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
