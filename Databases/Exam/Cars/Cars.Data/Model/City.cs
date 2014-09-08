namespace Cars.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Newtonsoft.Json;

    public class City
    {
        public City()
        {
            this.Dealers = new HashSet<Dealer>();
        }

        public int Id { get; set; }

        [JsonProperty("City")]
        [Required]
        [MaxLength(10)]
        [Column(TypeName = "nvarchar")]
        [Index(IsUnique=true)]
        public string Name { get; set; }

        public virtual ICollection<Dealer> Dealers { get; set; }

    }
}
