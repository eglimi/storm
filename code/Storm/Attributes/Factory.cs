using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Applies to Classes.
	/// It is used to generate constructors in the implementation class.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class FactoryAttribute : Attribute
	{
		public FactoryAttribute()
		{
		}
	}
}
