namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
			Worker robot = new Robot("robotaPesho", 100);
			Worker employee = new Employee("rabotnika Gosho");
			((Robot)robot).Recharge();
			robot.Work(40);
			employee.Work(45);
			Console.WriteLine(((Robot)robot).CurrentPower);
			((Robot)robot).Recharge();
			Console.WriteLine(((Robot)robot).CurrentPower);

		}
	}
}
