public class StartUp
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        IManager manager = new HeroManager();

		ICommandInterpreter commandInterpreter = new CommandInterpreter(manager);

        Engine engine = new Engine(reader, writer, manager, commandInterpreter);
        engine.Run();
    }
}