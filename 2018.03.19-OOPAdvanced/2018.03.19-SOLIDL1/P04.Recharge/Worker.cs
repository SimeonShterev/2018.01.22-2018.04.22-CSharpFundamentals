namespace P04.Recharge
{
    public abstract class Worker
    {
        private int workingHours;

        public Worker(string id)
        {
            this.Id = id;
        }

		public string Id { get; }

		public virtual void Work(int hours)
        {
            this.workingHours += hours;
        }
    }
}