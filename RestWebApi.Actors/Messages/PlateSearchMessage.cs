namespace RestWebApi.Actors.Messages
{
    public class PlateSearchMessage
    {
        public string Search { get; }

        public PlateSearchMessage(string search)
        {
            Search = search;
        }
    }
}