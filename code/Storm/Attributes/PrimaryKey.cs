using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Summary description for PrimaryKey.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class PrimaryKeyAttribute : Attribute
	{
		public PrimaryKeyAttribute()
		{
		}
	}
}
