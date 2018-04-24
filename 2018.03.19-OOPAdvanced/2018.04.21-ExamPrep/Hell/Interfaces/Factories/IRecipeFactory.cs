using System.Collections.Generic;

public interface IRecipeFactory
{
	IRecipe GenerateRecipe(IList<string> args);
}