using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_BarraksWars.Core.Commands
{
	public class FightCommand : Command
	{
		public FightCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
			: base(data)
		{
		}

		public override string Execute()
		{
			Environment.Exit(0);
			return null;
		}
	}
}
