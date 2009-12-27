using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Defines a one to many relation.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class ToManyAttribute : Attribute
	{
		private Type m_relationTo = null;
		private String m_relationName;

		public ToManyAttribute(Type relationTo, String relationName)
		{
			m_relationTo = relationTo;
			m_relationName = relationName;
		}

		public Type RelationTo
		{
			get{return m_relationTo;}
		}

		public String RelationName
		{
			get{return m_relationName;}
		}
	}
}
