using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.GuideCommands;
using TraversalCoreProje.CQRS.Queries.GuideQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/GuideMediatR")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        [Route("GetGuides/{id}")]
        public async Task<IActionResult> GetGuides(int id)
        {
            var values = await _mediator.Send(new GetGuideByİdQuery(id));
            return View(values);
        }

        [HttpGet]
        [Route("AddGuides")]
        public IActionResult AddGuides()
        {
            return View();
        }

        [HttpPost]
        [Route("AddGuides")]
        public async Task<IActionResult> AddGuides(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Admin");
        }
    }
}