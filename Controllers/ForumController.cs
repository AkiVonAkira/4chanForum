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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Topics()
        {
            var topics = _context.Topics.ToList();
            return View(topics);
        }
    }
}
