using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByİdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByİdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByİdQueryResult Handle(GetDestinationByİdQuery query)
        {
            var values = _context.Destinations.Find(query.İd);
            return new GetDestinationByİdQueryResult
            {
                Destinationİd = values.DestiantionID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
                Capacity = values.Capacity
            };
        }
    }
}