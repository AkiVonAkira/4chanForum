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
            var threads = _context.Threads.Where(t => t.TopicId == topicId).ToList();
            var topic = _context.Topics.FirstOrDefault(t => t.Id == topicId);

            ViewData["TopicId"] = topicId;
            ViewData["TopicTitle"] = (topic != null) ? topic.Title : "Topic not found";
            ViewData["TopicDescription"] = (topic != null) ? topic.Description : "Description not found";

            if (threads.Any()) { return View(threads); }
            else { return View(new List<ThreadModel>()); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ThreadModel thread)
        {
            if (ModelState.IsValid)
            {
                thread.Date = DateTime.Now;
                _context.Threads.Add(thread);
                _context.SaveChanges();
                return RedirectToAction("Index", "Forum", new { topicId = thread.TopicId });
            }

            var topic = _context.Topics.FirstOrDefault(t => t.Id == thread.TopicId);
            ViewData["TopicId"] = thread.TopicId;
            ViewData["TopicTitle"] = (topic != null) ? topic.Title : "Topic not found";
            ViewData["TopicDescription"] = (topic != null) ? topic.Description : "Description not found";

            var threads = _context.Threads.Where(t => t.TopicId == thread.TopicId).ToList();
            return View("Index", threads);
        }
    }
}
