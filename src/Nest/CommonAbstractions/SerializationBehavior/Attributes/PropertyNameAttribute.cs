using System;

namespace Nest6
{
	[AttributeUsage(AttributeTargets.Property)]
	public class PropertyNameAttribute : Attribute
	{
		public PropertyNameAttribute(string name) => Name = name;

		public string Name { get; set; }
	}
}
