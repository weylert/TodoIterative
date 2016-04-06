using System.Data.Entity;

namespace ToDoListIterative.Models
{
    public class ToDoListIterativeContext : DbContext
    {
        public DbSet<Atividade> Atividades { get; set; }
    }
}
