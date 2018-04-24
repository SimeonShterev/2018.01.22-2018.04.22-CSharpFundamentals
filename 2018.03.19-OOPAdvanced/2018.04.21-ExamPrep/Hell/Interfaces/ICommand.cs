using System.Collections.Generic;

public interface ICommand
{
	IManager Manager { get; }

	string Execute();
}