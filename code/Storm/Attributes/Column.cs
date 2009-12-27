using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Applies to Properties.
	/// Defines the mapping between an in-memory object attribute and a database column.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class ColumnAttribute : Attribute
	{
		private string m_dbColumn = String.Empty;

		public ColumnAttribute(string dbColumn)
		{
			m_dbColumn = dbColumn;
		}

		/// <summary>
		/// The Name of the corresponding column in the database.
		/// </summary>
		public string DbColumn
		{
			get{return m_dbColumn;}
		}
	}
}
