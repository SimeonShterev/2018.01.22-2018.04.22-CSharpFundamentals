 namespace P01_HarvestingFields
{
    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;

	public class HarvestingFieldsTest
    {
        public static void Main()
        {
			Type type = typeof(HarvestingFields);
			HarvestingFields harvestingFields = (HarvestingFields)Activator.CreateInstance(type);
			string command;
			while ((command = Console.ReadLine())!="HARVEST")
			{
				FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
				switch(command)
				{
					case "private":
						fields = fields.Where(f => f.IsPrivate == true).ToArray();
						break;
					case "public":
						fields = fields.Where(f => f.IsPublic == true).ToArray();
						break;
					case "protected":
						fields = fields.Where(f => f.IsFamily == true).ToArray();
						break;
					case "all":
						break;
				}

				foreach (FieldInfo field in fields)
				{
					Print(field);
				}
			}
        }

		private static void Print(FieldInfo field)
		{
			string access = field.Attributes.ToString().ToLower();
			if(field.Attributes == FieldAttributes.Family)
			{
				access = "protected";
			}
			string output = $"{access} {field.FieldType.Name} {field.Name}";
			Console.WriteLine(output);
			return;
		}
	}
}
