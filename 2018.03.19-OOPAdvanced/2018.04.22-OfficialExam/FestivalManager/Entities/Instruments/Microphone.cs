namespace FestivalManager.Entities.Instruments
{
    public class Microphone : Instrument
    {
		private const int DefaultRapairAmount = 80;

		protected override int RepairAmount => DefaultRapairAmount;
    }
}
