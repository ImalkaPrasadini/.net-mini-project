using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class CommanderContext: DbContext

    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        { 
        
        }

        public DbSet<Command> Commands { get; set; }
    }
}
