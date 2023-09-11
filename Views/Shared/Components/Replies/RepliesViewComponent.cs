using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RepliesViewComponent : ViewComponent
{
    private readonly DataContext _context;

    public RepliesViewComponent(DataContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(int threadId)
    {
        var repliesExist = await _context.Replies.AnyAsync(r => r.ThreadId == threadId);

        if (repliesExist)
        {
            var replies = await _context.Replies.Where(r => r.ThreadId == threadId).ToListAsync();
            return View(replies);
        }
        else
        {
            return View(new List<ReplyModel>());
        }
    }
}