using System;

namespace Storm.Attributes
{
	/// <summary>
	/// If used, code will be generated, otherwise code generation is omitted.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class GenerateCodeAttribute : Attribute
	{
		public GenerateCodeAttribute()
		{
		}
	}
}
