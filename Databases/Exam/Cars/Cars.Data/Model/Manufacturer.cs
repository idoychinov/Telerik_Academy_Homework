namespace Cars.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar")]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

    }
}
