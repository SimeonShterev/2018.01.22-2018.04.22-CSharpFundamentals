using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.Core.Commands
{
	public class AddCommand : Command
	{
		private IUnitFactory unitFactory;
		private IRepository repository;

		public AddCommand(string[] data, IUnitFactory unitFactory, IRepository repository) 
			: base(data)
		{
			this.UnitFactory = unitFactory;
			this.Repository = repository;
		}

		protected IUnitFactory UnitFactory
		{
			get { return this.unitFactory; }
			private set { this.unitFactory = value; }
		}

		protected IRepository Repository
		{
			get { return this.repository; }
			private set { this.repository = value; }
		}

		public override string Execute()
		{
			string unitType = this.Data[1];
			IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
			this.Repository.AddUnit(unitToAdd);
			string output = unitType + " added!";
			return output;
		}
	}
}
