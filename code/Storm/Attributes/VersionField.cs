using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Attribute to manage a version field.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class 
	| AttributeTargets.Field, 
	AllowMultiple = true)]
	public class VersionFieldAttribute : Attribute
	{
		private string m_fieldName = String.Empty;

		public VersionFieldAttribute(string fieldName)
		{
			m_fieldName = fieldName;
		}

		public string FieldName
		{
			get{return m_fieldName;}
			set{m_fieldName = value;}
		}
	}
}
