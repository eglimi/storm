using System;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for QueryObject.
	/// </summary>
	public class QueryObject
	{
		ArrayList m_criterias;

		public QueryObject()
		{
            m_criterias = new ArrayList();		
		}

		public void addCriteria(Criteria criteria)
		{
			m_criterias.Add(criteria);
		}

		public override string ToString()
		{
			string[] criterias = new string[m_criterias.Count];
			
			for(int i = 0; i < ((ArrayList)m_criterias).Count; i++)
			{
				criterias[i] = ((ArrayList)m_criterias)[i].ToString();
			}
			return String.Join(" AND ", criterias);
		}

	}
}
