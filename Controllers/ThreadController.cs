using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
                ViewData["TopicId"] = thread.TopicId;
                ViewData["TopicTitle"] = topic?.Title;

                return View(new List<ThreadModel> { thread }); 
            }
            else { return View(new List<ThreadModel>()); }
        }

        public IActionResult CreateThread(int topicId)
        {
            ViewData["TopicId"] = topicId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateThread(ThreadModel thread)
        {
            if (ModelState.IsValid)
            {
                _context.Threads.Add(thread);
                _context.SaveChanges();
                return RedirectToAction("Index", "Forum", new { topicId = thread.TopicId });
            }
            return View(thread);
        }

        public IActionResult Reply(int threadId)
        {
            ViewData["threadId"] = threadId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reply(ReplyModel reply)
        {
            if (ModelState.IsValid)
            {
                _context.Replies.Add(reply);
                _context.SaveChanges();
                return RedirectToAction("ViewThread", new { threadId = reply.ThreadId });
            }
            return View(reply);
        }
    }
}