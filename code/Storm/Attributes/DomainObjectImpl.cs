using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Applies to Classes and is used by STORM only.
	/// Defines that a generated class is an implementation of an abstract class and 
	/// should be registered in the registry.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class DomainObjectImplAttribute : Attribute
	{
		public DomainObjectImplAttribute()
		{
		}
	}
}
