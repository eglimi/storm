using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Holds all Custom Attributes.
	/// </summary>

	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
	public class TableAttribute : Attribute
	{
		private string m_tableName = String.Empty;
		private bool m_keyIsSurrogate;

		public TableAttribute(string tableName, bool keyIsSurrogate)
		{
			m_tableName = tableName;
			m_keyIsSurrogate = keyIsSurrogate;
		}

		public string TableName
		{
			get{return m_tableName;}
		}

		public bool KeyIsSurrogate
		{
			get{return m_keyIsSurrogate;}
		}
	}
}
