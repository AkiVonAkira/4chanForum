using _4chanForum.Models;
using Microsoft.AspNetCore.Mvc;

public class ThreadFormViewComponent : ViewComponent
{
    private readonly DataContext _context;

    public ThreadFormViewComponent(DataContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(int topicId)
    {
        var thread = new ThreadModel { TopicId = topicId };
        return View(thread);
    }
}
