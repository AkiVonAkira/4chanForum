using System.ComponentModel.DataAnnotations;

namespace _4chanForum.Models
{
    public class ThreadModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a message")]
        public string Text { get; set; }

        public int TopicId { get; set; }
        public bool isPinned { get; set; } = false;
    }
}
