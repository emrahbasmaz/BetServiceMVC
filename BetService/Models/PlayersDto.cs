using System.Collections.Generic;
using System.Web.Mvc;

namespace BetService.Models
{
    public class PlayersDto
    {
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Credit { get; set; }
        public List<SelectListItem> players { get; set; }
    }
}