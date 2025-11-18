using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
            {
                new Command { Id = 0, HowTo = "1st", Line = "1st line", Platform = "1st platform" },
                new Command { Id = 1, HowTo = "2", Line = "2nd line", Platform = "2nd platform" },
                new Command { Id = 2, HowTo = "3rd", Line = "3rd line", Platform = "3rd platform" },
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "1st", Line = "1st line", Platform = "1st platform" };
        }

        public bool saveChanges()
        {
            throw new NotImplementedException();
        }
    }

}