using StorageMaster.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
	public class Engine
	{
		private StorageMaster master;

		public Engine()
		{
			this.master = new StorageMaster();

		}

		public void Run()
		{
			string input = null;
			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split();// be careful with new lines;
				try
				{
					string output = ProcessCommand(commandArgs);
					Console.WriteLine(output);
				}
				catch (InvalidOperationException ex)
				{
					Console.WriteLine(string.Format(Consts.Error, ex.Message));
				}
			}

			Console.WriteLine(this.master.GetSummary());
		}

		private string ProcessCommand(string[] commandArgs)
		{
			string command = commandArgs[0];
			string output = null;
			switch (command)
			{
				case "AddProduct":
					{
						string type = commandArgs[1];
						double price = double.Parse(commandArgs[2]);
						output = this.master.AddProduct(type, price);
						break;
					}
				case "RegisterStorage":
					{
						string type = commandArgs[1];
						string name = commandArgs[2];
						output = this.master.RegisterStorage(type, name);
						break;
					}
				case "SelectVehicle":
					{
						string storageName = commandArgs[1];
						int garageSlot = int.Parse(commandArgs[2]);
						output = this.master.SelectVehicle(storageName, garageSlot);
						break;
					}
				case "LoadVehicle":
					{
						IEnumerable<string> productNames = commandArgs.Skip(1);
						output = this.master.LoadVehicle(productNames);
						break;
					}
				case "SendVehicleTo":
					{
						string sourceName = commandArgs[1];
						string destName = commandArgs[3];
						int sourceGarageSlot = int.Parse(commandArgs[2]);
						output = this.master.SendVehicleTo(sourceName, sourceGarageSlot, destName);
						break;
					}
				case "UnloadVehicle":
					{
						string storageName = commandArgs[1];
						int garageSlot = int.Parse(commandArgs[2]);
						output = this.master.UnloadVehicle(storageName, garageSlot);
						break;
					}
				case "GetStorageStatus":
					{
						string storageName = commandArgs[1];
						output = this.master.GetStorageStatus(storageName);
						break;
					}
			}
			return output;
		}
	}
}
