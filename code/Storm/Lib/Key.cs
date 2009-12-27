using System;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for Key.
	/// </summary>
    public class Key : ICollection
    {
        object[] m_keyItems;

        public Key(object[] items)
        {
            m_keyItems = items;
        }

        public object this[int index]
        {
            get{ return m_keyItems[index]; }
            set{ m_keyItems[index] = value; }
        }

        public override bool Equals(object obj)
        {
            if(obj is Key)
            {
                Key compKey = (Key)obj;
                if(compKey.Count != m_keyItems.Length)
                    return false;
                for(int i = 0; i < m_keyItems.Length; i++)
                {
                    if(m_keyItems[i].Equals(compKey[i]) == false)
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            foreach(object obj in m_keyItems)
            {
                hashCode ^= obj.GetHashCode();
            }
            return hashCode;
        }

        #region ICollection Members

            public bool IsSynchronized
            {
                get
                {
                    return m_keyItems.IsSynchronized;
                }
            }

        public int Count
        {
            get
            {
                return m_keyItems.Length;
            }
        }

        public void CopyTo(Array array, int index)
        {
            m_keyItems.CopyTo(array, index);
        }

        public object SyncRoot
        {
            get
            {
                return m_keyItems.SyncRoot;
            }
        }

        #endregion

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            return m_keyItems.GetEnumerator();
        }

        #endregion
    }
}
