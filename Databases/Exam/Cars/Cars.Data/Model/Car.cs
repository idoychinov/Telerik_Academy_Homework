using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cars.Data.Model
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar")]
        public string Model { get; set; }

        [Required]
        public TransmitionTypes TransmitionType { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }


        [Required]
        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }


    }
}
