using MediatR;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Queries.GuideQueries
{
    public class GetGuideByİdQuery : IRequest<GetGuideByİdQueryResult>
    {
        public GetGuideByİdQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}