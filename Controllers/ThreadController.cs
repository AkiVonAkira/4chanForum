using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;

namespace _4chanForum.Controllers
{
    public class ThreadController : Controller
    {
        private readonly DataContext _context;

        public ThreadController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int threadId)
        {
            var thread = _context.Threads.FirstOrDefault(t => t.Id == threadId);

            if (thread != null)
            {
                var topicId = thread.TopicId;
                var topic = _context.Topics.FirstOrDefault(t => t.Id == topicId);

                ViewData["ThreadId"] = threadId;
                ViewData["ThreadTitle"] = thread.Title;
                ViewData["TopicId"] = thread.TopicId;
                ViewData["TopicTitle"] = topic?.Title;

                IncrementViewCount(threadId);

                return View(new List<ThreadModel> { thread });
            }
            else
            {
                return View(new List<ThreadModel>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ReplyModel reply)
        {
            if (ModelState.IsValid)
            {
                reply.Date = DateTime.Now;
                _context.Replies.Add(reply);
                _context.SaveChanges();
                return RedirectToAction("Index", "Thread", new { threadId = reply.ThreadId });
            }

            var thread = _context.Threads.FirstOrDefault(t => t.Id == reply.ThreadId);

            ViewData["TopicId"] = thread.TopicId;
            ViewData["ThreadId"] = reply.ThreadId;
            ViewData["ThreadTitle"] = (thread != null) ? thread.Title : "Thread not found";

            var threads = _context.Threads.Where(t => t.Id == thread.Id).ToList();
            return View("Index", threads);
        }

        private void IncrementViewCount(int threadId)
        {
            var thread = _context.Threads.FirstOrDefault(t => t.Id == threadId);
            if (thread != null)
            {
                thread.ViewCount++;
                _context.SaveChanges();
            }
        }
    }
}