namespace P02_BlackBoxInteger
{
	using System;
	using System.Reflection;

	public class BlackBoxIntegerTests
	{
		public static void Main()
		{
			Type type = typeof(BlackBoxInteger);
			FieldInfo field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
			BlackBoxInteger blackBoxInteger = (BlackBoxInteger)Activator.CreateInstance(type, true);
			string input;
			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split('_');
				string command = commandArgs[0];
				int value = int.Parse(commandArgs[1]);

				MethodInfo method = type.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);
				method.Invoke(blackBoxInteger, new object[] { value });

				Console.WriteLine(field.GetValue(blackBoxInteger));
			}
		}
	}
}
