namespace Cars.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class Dealer
    {
        public Dealer()
        {
            this.Cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar")]
        public string Name { get; set; }

        [JsonProperty("City")]
        [NotMapped]
        public string City { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}