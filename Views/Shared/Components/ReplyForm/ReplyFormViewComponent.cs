using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;

public class ReplyFormViewComponent : ViewComponent
{
    private readonly DataContext _context;

    public ReplyFormViewComponent(DataContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(int threadId)
    {
        var replyModel = new ReplyModel { ThreadId = threadId };
        return View(replyModel);
    }
}