using Microsoft.AspNetCore.Mvc;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;
using TraversalCoreProje.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/DestinationCqrs")]
    public class DestinationCqrsController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByİdQueryHandler _getDestinationByİdQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCqrsController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByİdQueryHandler getDestinationByİdQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, DeleteDestinationCommandHandler deleteDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByİdQueryHandler = getDestinationByİdQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _deleteDestinationCommandHandler = deleteDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        [Route("GetDestination/{id}")]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByİdQueryHandler.Handle(new GetDestinationByİdQuery(id));
            return View(values);
        }

        [HttpPost]
        [Route("GetDestination")]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("AddDestination")]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        [Route("AddDestination")]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            _deleteDestinationCommandHandler.Handle(new DeleteDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}