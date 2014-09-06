namespace Lecture12TransactionInAdoNetAndEF
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class TransactionsHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName = "char")]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
