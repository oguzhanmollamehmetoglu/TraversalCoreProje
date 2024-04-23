using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Commands.GuideCommands;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                InstagramUrl = request.InstagramUrl,
                TwitterUrl = request.TwitterUrl,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}