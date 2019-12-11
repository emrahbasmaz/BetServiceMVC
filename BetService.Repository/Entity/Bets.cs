using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetService.Repository.Entity
{
    public class Bets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BetId { get; set; }
        [Required]
        public long EventId { get; set; }
        [Required]
        public long PlayerId { get; set; }
        public decimal Amount { get; set; }
        public string BetType { get; set; }
    }
}
