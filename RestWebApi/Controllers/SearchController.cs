using System.Threading.Tasks;
using System.Web.Http;
using Api.Search;

namespace RestWebApi.Controllers
{
    public class SearchController : ApiController
    {
        private readonly IPlateRepository _search;

        public SearchController(IPlateRepository repository)
        {
            _search = repository;
        }

        public async Task<IHttpActionResult> Get(string search)
        {
            var searchResult = await _search.GetAsync(search);

            return Ok(searchResult);
        }
    }
}