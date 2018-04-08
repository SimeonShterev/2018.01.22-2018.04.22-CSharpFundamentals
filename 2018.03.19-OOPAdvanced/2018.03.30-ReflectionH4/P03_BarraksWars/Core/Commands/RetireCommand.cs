using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Commands
{
	public class RetireCommand : Command
	{
		private IRepository repository;

		public RetireCommand(string[] data, IRepository repository)
			: base(data)
		{
			this.Repository = repository;
		}

		protected IRepository Repository
		{
			get { return this.repository; }
			private set { this.repository = value; }
		}

		public override string Execute()
		{
			string unit = this.Data[1];
			try
			{
				this.Repository.RemoveUnit(unit);
				return $"{unit} retired!";
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException("No such units in repository.", ex);
			}
		}
	}
}
