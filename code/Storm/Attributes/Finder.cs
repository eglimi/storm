using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Applies to Classes.
	/// It is used to generate find methods in the implementation class.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class FinderAttribute : Attribute
	{
		public FinderAttribute()
		{
		}
	}
}
