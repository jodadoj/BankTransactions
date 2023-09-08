using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTransactions.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "varchar(12)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage ="Please input an Account Number.")]
        [MaxLength(12, ErrorMessage ="Maximum input is 12 characters.")]
        public string AccountNumber { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Beneficiary Name")]
        [Required(ErrorMessage = "Please input an Beneficiary Name.")]
        [MaxLength(100, ErrorMessage ="Maximum input is 100 characters.")]
        public string BeneficiaryName { get; set; }
        [Column(TypeName = "varchar(100)")]
        [DisplayName("Bank Name")]
        [Required(ErrorMessage = "Please input an Bank Name.")]
        [MaxLength(100, ErrorMessage ="Maximum input is 100 characters.")]
        public string BankName { get; set; }
        [Column(TypeName = "varchar(11)")]
        [DisplayName("SWIFT Code")]
        [Required(ErrorMessage = "Please input an SWIFT Code.")]
        [MaxLength(11, ErrorMessage ="Maximum input is 11 characters.")]
        public string SWIFTCode { get; set; }
        [Required]
        public int Amount { get; set; }
        public DateTime Date { get; set; }

    }
}
