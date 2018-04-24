namespace FestivalManager.Entities.Factories
{
	using System;
	using System.Linq;
	using System.Reflection;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
			//Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);
			Assembly assembly = Assembly.GetCallingAssembly();
			Type instrumentType = assembly.GetTypes().FirstOrDefault(i => i.Name == type);

			IInstrument instrument = (IInstrument)Activator.CreateInstance(instrumentType);
			return instrument;
		}
	}
}