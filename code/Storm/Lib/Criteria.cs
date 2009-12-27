using System;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for Criteria.
	/// </summary>
	public class Criteria
	{
		public enum Operator { Equal, GreaterOrEqual, LessOrEqual, Greater, Less, NotEqual, In }

		private Operator m_op;
		private string m_fieldName;
		private object m_value;

		public Criteria(Operator op, string fieldName, object value)
		{
			m_op = op;
			m_fieldName = fieldName;
			m_value = value;
		}

		public override string ToString()
		{
			string value = m_value.ToString();
			string op = "";

			if(m_value is string)
			{
				value = "'" + value + "'";
			}

			switch(m_op)
			{
				case Operator.Equal:
					op = " = ";
					break;
				case Operator.GreaterOrEqual:
					op = " >= ";
					break;
				case Operator.LessOrEqual:
					op = " <= ";
					break;
				case Operator.Greater:
					op = " > ";
					break;
				case Operator.Less:
					op = " < ";
					break;
				case Operator.NotEqual:
					op = " <> ";
					break;
				case Operator.In:
					if(!(m_value is ArrayList))
					{
						throw new ApplicationException();
					}
					string[] list = new string[((ArrayList)m_value).Count];
					string delim;
					op = " IN ";
					for(int i = 0; i < ((ArrayList)m_value).Count; i++)
					{
						delim = (((ArrayList)m_value)[i] is string) ? "'" : "";
						list[i] = delim + ((ArrayList)m_value)[i].ToString() + delim;
					}
					value = "(" + String.Join(", ", list) + ")";
					break;
			}

			return m_fieldName + op + value;
		}

	}
}
