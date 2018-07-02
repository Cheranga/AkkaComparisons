using System.Threading.Tasks;
using Akka.Actor;
using Api.Search;
using RestWebApi.Actors.Messages;

namespace RestWebApi.Actors.Actors
{
    public class SearchActor : ReceiveActor
    {
        private readonly IPlateRepository _search;

        public SearchActor()
        {
            _search = LocalPlateRepository.Instance;
            ReceiveAsync<PlateSearchMessage>(m => SearchPlateAsync(m).PipeTo(Sender));
        }

        private Task<SearchResult> SearchPlateAsync(PlateSearchMessage message)
        {
            return _search.GetAsync(message.Search);
        }
    }
}