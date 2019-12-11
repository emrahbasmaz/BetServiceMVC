using BetService.Repository.Entity;
using System;
using System.Collections.Generic;

namespace BetService.Models
{
    public class EventViewModel
    {
        public IEnumerable<Events> Events { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
    }
}