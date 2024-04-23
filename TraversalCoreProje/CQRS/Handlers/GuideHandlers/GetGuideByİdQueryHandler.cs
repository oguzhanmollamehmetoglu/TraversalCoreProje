using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByİdQueryHandler : IRequestHandler<GetGuideByİdQuery, GetGuideByİdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByİdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByİdQueryResult> Handle(GetGuideByİdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.guides.FindAsync(request.id);
            return new GetGuideByİdQueryResult
            {
                GuideID = values.GuideID,
                Description = values.Description,
                Image = values.Image,
                InstagramUrl = values.InstagramUrl,
                Name = values.Name,
                TwitterUrl = values.TwitterUrl
            };
        }
    }
}