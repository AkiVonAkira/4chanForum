namespace _4chanForum.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool isPinned { get; set; } = false;
    }
}
