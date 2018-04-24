namespace FestivalManager.Entities.Instruments
{
    public class Guitar : Instrument
    {
		private const int DefaultRapairAmount = 60;

		protected override int RepairAmount => DefaultRapairAmount;
    }
}
