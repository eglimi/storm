using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Summary description for MapperImpl.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class MapperImplAttribute : Attribute
	{
		private Type m_type = null;

		public MapperImplAttribute(Type type)
		{
			m_type = type;
		}

		public Type Type
		{
			get{return m_type;}
		}
	}
}
