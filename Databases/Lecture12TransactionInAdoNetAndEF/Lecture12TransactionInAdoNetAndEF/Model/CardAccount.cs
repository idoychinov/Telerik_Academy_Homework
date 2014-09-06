namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "char")]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        [Column(TypeName = "char")]
        public string CardPin { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal CardCash { get; set; }
    }
}
