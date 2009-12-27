using System;
using System.Text;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for Timestamp.
	/// </summary>
	public class Timestamp
	{
		byte[] m_timestamp;

		public Timestamp(byte[] timestamp)
		{
			if(timestamp == null || timestamp.Length != 8)
				throw new ApplicationException("Sorry, Timestamps needs a byte array of length 8");
			m_timestamp = timestamp;
		}

		public byte[] Value
		{
			get { return m_timestamp; }
		}

		public override bool Equals(object obj)
		{
			if(obj is Timestamp)
			{
				Timestamp rValue = (Timestamp)obj;
				for(int i = 0; i < 8; i++)
				{
					if(m_timestamp[i] != rValue.m_timestamp[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int result = 0;
			foreach(byte value in m_timestamp)
			{
				result ^= value;
			}
			return result;
		}
	}
}
