using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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

            if (threads.Any()) { return View(threads); }
            else { return View(new List<ThreadModel>()); }
        }

        public IActionResult CreateThread(int topicId)
        {
            var thread = _context.Threads.FirstOrDefault(t => t.TopicId == topicId);

            if (thread != null)
            {
                ViewData["TopicId"] = topicId;
                ViewData["ThreadId"] = thread.Id;
                ViewData["ThreadTitle"] = thread.Title;

                return View();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateThread(ThreadModel thread)
        {
            if (ModelState.IsValid)
            {
                thread.Date = DateTime.Now;
                _context.Threads.Add(thread);
                _context.SaveChanges();
                return RedirectToAction("Index", "Forum", new { topicId = thread.TopicId });
            }
            return View("ThreadForm", thread);
        }
    }
}
