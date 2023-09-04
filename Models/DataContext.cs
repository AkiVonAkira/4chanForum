using Microsoft.EntityFrameworkCore;

namespace _4chanForum.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<ThreadModel> Threads { get; set; } 
        public DbSet<ReplyModel> Replies { get; set; }
    }
}
