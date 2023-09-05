using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            
            return View();
        }

        public IActionResult Thredas()
        {
            var threads = _context.Topics.ToList();
            return View(threads);
        }

        public IActionResult Create ()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }
    }
}

