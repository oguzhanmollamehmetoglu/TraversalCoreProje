using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _Testimonial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _commentService.TGetListCommentWithDestinationAndAppUser();
            return View(values);
        }
    }
}