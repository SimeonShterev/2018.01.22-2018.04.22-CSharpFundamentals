public class Program
{
    public static void Main(string[] args)
    {
		IEnergyRepository energyRepository = new EnergyRepository();
		IWriter writer = new ConsoleWriter();

		IHarvesterController harvesterController = new HarvesterController(energyRepository);
		IProviderController providerController = new ProviderController(energyRepository);

		ICommandInterpreter commandInterpreter = new CommandInterpreter(energyRepository, writer, harvesterController, providerController);

		Engine engine = new Engine(energyRepository, commandInterpreter, writer);
        engine.Run();
    }
}