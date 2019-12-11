using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetService.Repository.Entity
{
    public class Events
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long EventId { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime KickOff { get; set; }
        public decimal HomeTeamOdds { get; set; }
        public decimal AwayTeamOdds { get; set; }
        public decimal DrawOdds { get; set; }
        [Required]
        public string Result { get; set; }
    }
}
