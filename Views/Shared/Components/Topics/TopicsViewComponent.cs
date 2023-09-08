using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class TopicsViewComponent : ViewComponent
{
    private readonly DataContext _context;

    public TopicsViewComponent(DataContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var topics = await _context.Topics.ToListAsync();
        return View(topics);
    }
}