namespace _4chanForum.Models
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set;}
    }
}
