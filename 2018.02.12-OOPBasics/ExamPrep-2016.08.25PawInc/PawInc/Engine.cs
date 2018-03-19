using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
	private StringBuilder output;
	List<AdoptionCenter> adoptionCentersList;
	List<CleansingCenter> cleansingCentersList;
	List<CastrationCenter> castrationCentersList;

	public Engine()
	{
		this.output = new StringBuilder();
		adoptionCentersList = new List<AdoptionCenter>();
		cleansingCentersList = new List<CleansingCenter>();
		castrationCentersList = new List<CastrationCenter>();
	}

	public void RegisterAdoptionCenter(string name)
	{
		AdoptionCenter adoptionCenter = new AdoptionCenter(name);
	}
	public void RegisterCleansingCenter(string name)
	{
		CleansingCenter cleasingCenter = new CleansingCenter(name);
	}
	public void RegisterCastrationCenter(string name)
	{
		CastrationCenter castrationCenter = new CastrationCenter(name);
	}
	public void RegisterDog(List<string> dogArgs)
	{
		string name = dogArgs[0];
		int age = int.Parse(dogArgs[1]);
		int commandsKnown = int.Parse(dogArgs[2]);
		Animal dog = new Dog(name, age, commandsKnown);
		string adoptionCenterName = dogArgs[3];
		dog.AddToAdoptionCenter(adoptionCenterName);
	}
	public void RegisterCat(List<string> catArgs)
	{
		string name = catArgs[0];
		int age = int.Parse(catArgs[1]);
		int inteliggence = int.Parse(catArgs[2]);
		Animal cat = new Cat(name, age, inteliggence);
		string adoptionCenterName = catArgs[3];
		cat.AddToAdoptionCenter(adoptionCenterName);
	}
	public void SendForCleasing(List<string> commandArgs)
	{
		string adoptionCenterName = commandArgs[0];
		string cleansingCenterName = commandArgs[1];
		
	}
	public void Cleanse(string name)
	{

	}
	public void SendForCastration(List<string> commandArgs)
	{

	}
	public void Castrate(string name)
	{

	}
	public void Adopt(string name)
	{

	}
}