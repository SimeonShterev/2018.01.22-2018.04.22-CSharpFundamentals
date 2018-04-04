using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
	public string StealFieldInfo(string classToInvestigate, params string[] fieldNames)
	{
		StringBuilder sb = new StringBuilder($"Class under investigation: {classToInvestigate}\r\n");
		var fields = Type.GetType(classToInvestigate).GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
		Object classInstance = Activator.CreateInstance(Type.GetType(classToInvestigate));
		foreach (var field in fields)
		{
			if (fieldNames.Contains(field.Name))
				sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
		}
		return sb.ToString().Trim();
	}

	public string AnalyzeAccessModifiers(string className)
	{
		Type type = Type.GetType(className);
		FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
		PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
		Object classInstance = Activator.CreateInstance(type);
		StringBuilder sb = new StringBuilder();
		foreach (var field in fields)
		{
			sb.AppendLine($"{field.Name} must be private!");
		}
		foreach (var prop in props)
		{
			if(!prop.GetMethod?.IsPublic == true)
			{
				sb.AppendLine($"{prop.GetMethod.Name} have to be public!");
			}
		}
		foreach (var prop in props)
		{
			if (!prop.SetMethod?.IsPrivate == true)
			{
				sb.AppendLine($"{prop.SetMethod.Name} have to be private!");
			}
		}
		return sb.ToString().Trim();
	}

	public string RevealPrivateMethods(string className)
	{
		Type type = Type.GetType(className);
		MethodInfo[] privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
		StringBuilder sb = new StringBuilder();

		sb.AppendLine($"All Private Methods of Class: {className}");
		string baseClassName = type.BaseType.Name;
		sb.AppendLine($"Base Class: {baseClassName}");

		foreach (var method in privateMethods)
		{
			sb.AppendLine(method.Name);
		}
		return sb.ToString().Trim();
	}

	public string CollectGettersAndSetters(string className)
	{
		Type type = Type.GetType(className);
		PropertyInfo[] methods = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
		StringBuilder sb = new StringBuilder();

		foreach (var getMethod in methods)
		{
			if (getMethod.GetMethod != null)
				sb.AppendLine($"{getMethod.GetMethod.Name} will return {getMethod.PropertyType}");
		}
		foreach (var setMethod in methods)
		{
			if (setMethod.SetMethod != null)
				sb.AppendLine($"{setMethod.SetMethod.Name} will set field of {setMethod.SetMethod.GetParameters().First().ParameterType}");
		}
		return sb.ToString().Trim();
	}
}