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

        [JsonProperty("Model")]
        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar")]
        public string Model { get; set; }

        [JsonProperty("TransmissionType")]
        [Required]
        public TransmitionTypes TransmitionType { get; set; }

        [JsonProperty("Year")]
        [Required]
        public int Year { get; set; }

        [JsonProperty("Price")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }


        [JsonProperty("ManufacturerName")]
        public string ManufacturerName { get; set; }

        [Required]
        public int DealerId { get; set; }

        [JsonProperty("Dealer")]
        public virtual Dealer Dealer { get; set; }


    }
}
