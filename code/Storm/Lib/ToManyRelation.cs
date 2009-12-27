using System;
//using System.Reflection;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for ToManyRelation.
	/// </summary>
	public class ToManyRelation : IList
	{
		Type m_relation;
		String m_fieldName;
		Key m_parentId;
		ArrayList m_children = new ArrayList();
		bool m_isParentNew = false;

		public ToManyRelation(Type relation, String fieldName, Key parentId, bool isParentNew)
		{
			m_relation = relation;
			m_fieldName = fieldName;
			m_parentId = parentId;
			m_isParentNew = isParentNew;
		}

		private void LoadChildren()
		{
			if(m_isParentNew == true)
			{
				return;
			}

			IMapper mapper = Registry.Instance.getMapper(m_relation);
			m_children = (ArrayList)mapper.ResolveToManyRelation(m_parentId, m_fieldName);
		}

		#region IList Members

		public bool IsReadOnly
		{
			get
			{
				return m_children.IsReadOnly;
			}
		}

		public object this[int index]
		{
			get
			{
				LoadChildren();
				return m_children[index];
			}
			set
			{
				m_children[index] = value;
			}
		}

		public void RemoveAt(int index)
		{
			//            if(m_isLoaded)
			m_children.RemoveAt(index);
		}

		public void Insert(int index, object value)
		{
			m_children.Insert(index, value);
		}

		public void Remove(object value)
		{
			//            if(m_isLoaded)
			m_children.Remove(value);
		}

		public bool Contains(object value)
		{
			LoadChildren();
			return m_children.Contains(value);
		}

		public void Clear()
		{
			m_children.Clear();
		}

		public int IndexOf(object value)
		{
			LoadChildren();
			return m_children.IndexOf(value);
		}

		public int Add(object value)
		{
			return m_children.Add(value);
		}

		public bool IsFixedSize
		{
			get
			{
				return m_children.IsFixedSize;
			}
		}

		#endregion

		#region ICollection Members

		public bool IsSynchronized
		{
			get
			{
				return m_children.IsSynchronized;
			}
		}

		public int Count
		{
			get
			{
				LoadChildren();
				return m_children.Count;
			}
		}

		public void CopyTo(Array array, int index)
		{
			LoadChildren();
			m_children.CopyTo(array, index);
		}

		public object SyncRoot
		{
			get
			{
				return m_children.SyncRoot;
			}
		}

		#endregion

		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			LoadChildren();
			return m_children.GetEnumerator();
		}

		#endregion
	}
}
