using System;
using System.Collections.Generic;
using System.Text;

public abstract class Nation : IManipulateBendersList, IManipulateMonumentList
{
	private ICollection<IBender> benderList;
	private ICollection<IMonuments> monumentsList;

	public Nation()
	{
		this.benderList = new List<IBender>();
		this.monumentsList = new List<IMonuments>();
	}

	public IReadOnlyCollection<IBender> ReadBenders
	{
		get
		{
			return (IReadOnlyCollection<IBender>)this.benderList;
		}
	}

	public IReadOnlyCollection<IMonuments> ReadMonuments
	{
		get
		{
			return (IReadOnlyCollection<IMonuments>)this.monumentsList;
		}
	}

	public void AddBenders(IBender bender)
	{
		this.benderList.Add(bender);
	}

	public void AddMonument(IMonuments monument)
	{
		this.monumentsList.Add(monument);
	}

	internal void Clear()
	{
		this.monumentsList.Clear();
		this.benderList.Clear();
	}
}