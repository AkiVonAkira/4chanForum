using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace _4chanForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly DataContext _context;
        public ForumController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int topicId)
        {
            var thread = _context.Threads.Where(t => t.TopicId == topicId).ToList();
            ViewData["TopicId"] = topicId;
            if (thread.Any()) { return View(thread); }
            else { return View(new List<ThreadModel>()); }
        }
    }
}
