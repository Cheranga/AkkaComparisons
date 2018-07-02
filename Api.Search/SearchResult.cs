using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Search
{
    public class SearchResult
    {
        public string Message { get; }

        public SearchResult(string message)
        {
            Message = message;
        }
    }
}
