using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Search
{
    public class LocalPlateRepository : IPlateRepository
    {
        private static IEnumerable<string> _plates;

        private static LocalPlateRepository _instance;

        private LocalPlateRepository()
        {
        }

        public static LocalPlateRepository Instance
        {
            get
            {
                _plates = Enumerable.Range(1, 1000).Select(x => $"abc{x}");

                return _instance = _instance ?? new LocalPlateRepository();
            }
        }

        public Task<SearchResult> GetAsync(string search)
        {
            ////await Task.Delay(TimeSpan.FromMilliseconds(100)).ConfigureAwait(false);
            //////
            ////// Do a synchronous operation
            //////
            //Enumerable.Range(1, 10000).ToList().ForEach(x =>
            //{
            //    //
            //    // Do some operation
            //    Console.WriteLine("Doing something important...");
            //});

            var plate = _plates.FirstOrDefault(x => string.Equals(x, search, StringComparison.OrdinalIgnoreCase));
            var result = string.IsNullOrEmpty(plate) ? new SearchResult("No plates found") : new SearchResult($"Found {search}!");

            return Task.FromResult(result);
        }
    }
}