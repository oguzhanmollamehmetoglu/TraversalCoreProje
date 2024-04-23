namespace TraversalCoreProje.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByİdQuery
    {
        public GetDestinationByİdQuery(int id)
        {
            İd = id;
        }

        public int İd { get; set; }
    }
}