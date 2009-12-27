using System;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for IFactory.
	/// </summary>
	public interface IFinder
	{
		IList find(QueryObject qo);
		IList findAll();
		DomainObject findById(Key id);
	}
}
