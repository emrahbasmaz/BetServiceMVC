using BetService.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetService.Models
{
    public class PlayerViewModel
    {
        public IEnumerable<Players> Players { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}