using System.ComponentModel.DataAnnotations;

namespace _4chanForum.Models
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [Required(ErrorMessage = "Text is required.")]
        public string? Text { get; set; }
        public int ThreadId { get; set; }
        public bool isPinned { get; set; } = false;
    }
}
