using System;
using System.Collections.Generic;
using System.Text;

public interface IWeapon
{
	void AddGem(int socketIndex, Gem gem);

	void RemoveGem(int socketIndex);
}

