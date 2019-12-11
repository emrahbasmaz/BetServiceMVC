using BetService.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetService.Models
{
    public class BetViewModel
    {
        public IEnumerable<Bets> Bets { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}