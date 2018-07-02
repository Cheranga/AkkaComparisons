using System.Threading.Tasks;

namespace Api.Search
{
    public interface IPlateRepository
    {
        Task<SearchResult> GetAsync(string search);
    }
}