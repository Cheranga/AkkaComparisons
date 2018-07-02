using System.Threading.Tasks;
using System.Web.Http;
using Akka.Actor;
using Api.Search;
using RestWebApi.Actors.Messages;

namespace RestWebApi.Actors.Controllers
{
    public class SearchController : ApiController
    {
        public async Task<IHttpActionResult> Get(string search)
        {
            var searchResult = await PlateActorSystem.SearchActor.Ask<SearchResult>(new PlateSearchMessage(search));
            return Ok(searchResult);
        }
    }
}