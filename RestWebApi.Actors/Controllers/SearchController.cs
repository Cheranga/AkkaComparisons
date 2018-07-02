using System.Threading.Tasks;
using System.Web.Http;
using Akka.Actor;
using Api.Search;
using RestWebApi.Actors.Actors;
using RestWebApi.Actors.Messages;

namespace RestWebApi.Actors.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IActorRef _actor;

        public SearchController(IActorRef actor)
        {
            _actor = actor;
        }

        public async Task<IHttpActionResult> Get(string search)
        {
            var searchResult = await _actor.Ask<SearchResult>(new PlateSearchMessage(search));
            return Ok(searchResult);
        }
    }
}