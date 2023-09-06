using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace _4chanForum.Controllers
{
    
    public class ThreadController : Controller
    {

        private readonly DataContext _context;

        public ThreadController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index(int topicId)
        {
            var threads = _context.Threads.Where(t => t.TopicId == topicId).ToList();
            ViewData["TopicId"] = topicId;
            return View(threads);
        }
        
        public IActionResult ViewThread(int threadId)
        {
            var thread = _context.Threads.Where(t => t.Id == threadId).ToList();
             
            return View(thread);
        }
        
        

        //public IActionResult Details(int threadId)
        //{

        //    var threads = _context.Threads.Where(t => t.Id == threadId).ToList();

        //    if (threads == null)
        //    {

        //        return NotFound();

        //    }

        //    return View();
        //}

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
                return RedirectToAction("Index", new { topicId = thread.TopicId });
            }
            return View(thread);

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






        /*
       public ActionResult Edit(int threadId)
       {
           return View();
       }



        public IActionResult Edit(int threadId)
        {
            var threads = _context.Threads.Where(t => t.Id == threadId).ToList();

            if (threads == null)
            {
                return NotFound();
            }


            return View(threads);
        }

        */



    }
}