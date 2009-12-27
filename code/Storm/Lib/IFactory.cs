using System;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for IFactory.
	/// </summary>
	public interface IFactory
	{
		DomainObject create();
		DomainObject createFromParameters(Key id, Timestamp timestamp, params DictionaryEntry[] parameters);
	}
}
