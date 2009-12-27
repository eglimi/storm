using System;
using System.Collections;
using System.Data.SqlClient;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for IMapper.
	/// </summary>
	public interface IMapper
	{
		void insert(DomainObject subject, SqlConnection connection, SqlTransaction transaction);
		void update(DomainObject subject, SqlConnection connection, SqlTransaction transaction);
		void delete(DomainObject subject, SqlConnection connection, SqlTransaction transaction);

		DomainObject findById(Key id);
		IList find(QueryObject qo);
		IList findAll();

		IList ResolveToManyRelation(Key id, String fieldName);
		DomainObject ResolveToOneRelation(Key id, String fieldName);
	}
}
