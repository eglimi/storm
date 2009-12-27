using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Summary description for ParameterDef.
	/// </summary>
	public class ParameterDefAttribute : Attribute
	{
		private string m_propertyName;

		public ParameterDefAttribute(string propertyName)
		{
			m_propertyName = propertyName;
		}

		public string PropertyName
		{
			get
			{
				return m_propertyName;
			}
		}
	}
}
