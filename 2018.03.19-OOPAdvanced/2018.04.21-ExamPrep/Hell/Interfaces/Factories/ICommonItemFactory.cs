using System.Collections.Generic;

public interface ICommonItemFactory
{
	IItem GenetareCommonItem(IList<string> args);
}