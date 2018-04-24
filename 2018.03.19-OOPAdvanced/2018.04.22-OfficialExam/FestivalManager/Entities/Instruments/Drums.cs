namespace FestivalManager.Entities.Instruments
{
	public class Drums : Instrument
	{
		private const int DefaultRapairAmount = 20;

		protected override int RepairAmount => DefaultRapairAmount;
	}
}
