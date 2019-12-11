using BetService.Repository.Entity;
using BetService.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace BetService.Api
{
    public class PlayersController : ApiController
    {
        private readonly IPlayersService playersService;

        public PlayersController(IPlayersService playersService)
        {
            this.playersService = playersService;
        }
        public IEnumerable<Players> Get()
        {
            return this.playersService.GetAll();
        }
    }
}
