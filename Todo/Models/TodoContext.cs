using System.Data.Entity;

namespace Todo.Models
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoList> TodoList { get; set; }
    }
}