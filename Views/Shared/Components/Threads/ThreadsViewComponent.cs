using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ThreadsViewComponent : ViewComponent
{
    private readonly DataContext _context;

    public ThreadsViewComponent(DataContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(int topicId)
    {
        var threadsExists = await _context.Threads.AnyAsync(t => t.TopicId == topicId);

        if (threadsExists)
        {
            var threads = await _context.Threads.Where(t => t.TopicId == topicId).ToListAsync();
            return View(threads);
        }
        else
        {
            return View(new List<ThreadModel>());
        }
    }
}