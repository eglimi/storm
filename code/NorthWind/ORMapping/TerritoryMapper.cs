//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by CodeSmith.
//     Version: 2.2.7.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Storm.Lib;
using Storm.Attributes;
using NorthWind;

namespace NorthWind
{


	[MapperImpl(typeof(Territory))]
	public class TerritoryMapper : IMapper
	{		
#region Finder Methods
		public DomainObject findById(Key id)
		{
			try
			{
				SqlDataReader reader = null;
				SqlConnection connection = UnitOfWork.Instance.Connection;

				connection.Open();

				string sqlStmt = 
					"SELECT * from Territories WHERE TerritoryID = @TerritoryId";
				SqlCommand command = new SqlCommand(sqlStmt, connection);
				command.Parameters.Add("@TerritoryId", id[0]);

				reader = command.ExecuteReader();
				Territory territory = null;
				if(reader.Read())
				{
					territory = loadFields(reader);
				} 
				if(reader != null)
					reader.Close();
				connection.Close();

				return territory;
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
		}		

		public IList findAll()
		{
			try
			{
				ArrayList array = new ArrayList();
				SqlDataReader reader = null;
				SqlConnection connection = UnitOfWork.Instance.Connection;

				connection.Open();

				string sqlStmt = 
					"SELECT * from Territories";
				SqlCommand command = new SqlCommand(sqlStmt, connection);

				reader = command.ExecuteReader();
				while(reader.Read())
				{
					array.Add(loadFields(reader));
				} 
				if(reader != null)
					reader.Close();
				connection.Close();

				return array;
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
		}		

		public IList find(QueryObject qo)
		{
			try
			{
				ArrayList array = new ArrayList();
				SqlDataReader reader = null;
				SqlConnection connection = UnitOfWork.Instance.Connection;

				connection.Open();

				string sqlStmt = 
					"SELECT * from Territories WHERE " + qo.ToString();
				SqlCommand command = new SqlCommand(sqlStmt, connection);

				reader = command.ExecuteReader();
				while(reader.Read())
				{
					array.Add(loadFields(reader));
				} 
				if(reader != null)
					reader.Close();
				connection.Close();

				return array;
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
		}		
#endregion		
		
#region IMapper Members
		public void insert(DomainObject subject, SqlConnection connection, SqlTransaction transaction)
		{
			try
			{
				Territory territory = (Territory)subject;
				SqlCommand command = new SqlCommand(
					"INSERT INTO Territories (TerritoryDescription, TerritoryID, RegionID) VALUES (@TerritoryDescription, @TerritoryId, @Region) ; SELECT VersionId FROM Territories WHERE TerritoryID= @TerritoryId",
					connection, transaction);

				if(subject.isNull("TerritoryDescription"))
				{
					command.Parameters.Add("@TerritoryDescription", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@TerritoryDescription", territory.TerritoryDescription);
				}
				if(subject.isNull("TerritoryId"))
				{
					command.Parameters.Add("@TerritoryId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@TerritoryId", territory.TerritoryId);
				}
				if(subject.isNull("Region") || territory.Region.isNull("RegionId"))
				{
					command.Parameters.Add("@Region", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Region", territory.Region.RegionId);
				}
				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					territory.Timestamp = safeGetTimestamp(reader);
					subject.FireIdChanged();
					reader.Close();			
				}
				else
				{
					reader.Close();
					throw new ConcurrencyException();
				}
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
		}
		
		public void update(DomainObject subject, SqlConnection connection, SqlTransaction transaction)
		{
			try
			{
				Territory territory = (Territory)subject;
				SqlCommand command = new SqlCommand(
					"UPDATE Territories SET TerritoryDescription = @TerritoryDescription, RegionID = @Region WHERE TerritoryID = @TerritoryId AND VersionId = @VersionId IF @@ROWCOUNT > 0  BEGIN SELECT VersionId FROM Territories WHERE TerritoryID = @TerritoryId END",
					connection, transaction); 

				command.Parameters.Add("@VersionId", territory.Timestamp.Value);
				if(subject.isNull("TerritoryId"))
				{
					command.Parameters.Add("@TerritoryId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@TerritoryId", territory.TerritoryId);
				}
				if(subject.isNull("TerritoryDescription"))
				{
					command.Parameters.Add("@TerritoryDescription", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@TerritoryDescription", territory.TerritoryDescription);
				}
				if(subject.isNull("Region") || territory.Region.isNull("RegionId"))
				{
					command.Parameters.Add("@Region", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Region", territory.Region.Id[0]);
				}

				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					territory.Timestamp = safeGetTimestamp(reader);
					reader.Close();
				}
				else
				{
					reader.Close();
					throw new ConcurrencyException();
				}
				subject.FireIdChanged();

			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
		}
		
		public void delete(DomainObject subject, SqlConnection connection, SqlTransaction transaction)
		{
			try
			{
				Territory territory = (Territory)subject;
				
				SqlCommand command = new SqlCommand(
					"DELETE FROM Territories WHERE TerritoryID = @TerritoryId AND VersionId = @VersionId",
					connection, transaction);

				command.Parameters.Add("@VersionId", territory.Timestamp.Value);
				if(subject.isNull("TerritoryId"))
				{
					command.Parameters.Add("@TerritoryId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@TerritoryId", territory.TerritoryId);
				}
				if(command.ExecuteNonQuery() <= 0)
				{
					throw new ConcurrencyException();
				}
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
		}
		
		public DomainObject ResolveToOneRelation(Key id, String fieldName)
		{
			SqlDataReader reader = null;
			SqlConnection connection = UnitOfWork.Instance.Connection;
			
			connection.Open();

			try
			{
				String selectStmt = "SELECT * FROM Territories WHERE " + fieldName + " = @FK";
				SqlCommand command = new SqlCommand(selectStmt, connection);
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				Territory territory = null;
				
				if(reader.Read())
				{
					territory = loadFields(reader);
				}
				if(reader != null)
				{
					reader.Close();
				}
				connection.Close();
				
				return territory;
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
			finally
			{
				connection.Close();
			}
		}
		
		public IList ResolveToManyRelation(Key id, String fieldName)
		{
			SqlDataReader reader = null;
			ArrayList array = new ArrayList();
			SqlConnection connection = UnitOfWork.Instance.Connection;
			SqlCommand command;
			connection.Open();
			
			try
			{
				command = new SqlCommand(
					"SELECT TerritoryID, VersionId FROM Territories WHERE " + fieldName + " = @FK", connection);
					
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				ArrayList keys = new ArrayList();
				Timestamp timestamp;
				while(reader.Read())
				{ 
					object territoryid = safeGetValue(reader, "TerritoryID");
					
					timestamp = safeGetTimestamp(reader);
					
					Key currentKey = new Key(new object[]{territoryid});
					DomainObject domobj = UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(
						typeof(Territory), currentKey);
					
					if(domobj == null)
					{
						keys.Add(currentKey);
					}
					else if(!domobj.Timestamp.Equals(timestamp))
					{
						UnitOfWork.Instance.IdentityMap.unregisterDomainObject(domobj);
						keys.Add(currentKey);
					}
					else
					{
						array.Add(domobj);
					}
				}
				reader.Close();

				if(keys.Count > 0)
				{
					int primKeysCount = 1;
					ArrayList primKeys = new ArrayList();
					primKeys.Add("TerritoryID");
					StringBuilder selectAdStmt = new StringBuilder();
					selectAdStmt.Append("SELECT * FROM ");
					selectAdStmt.Append("Territories");
					selectAdStmt.Append(" WHERE ");
					StringBuilder whereStmt;
					String[] andStmts = new String[keys.Count];
					for(int i = 0; i < keys.Count; i++)
					{
						String[] primKeyCriterias = new String[primKeysCount];
						for(int j = 0; j < primKeysCount; j++)
						{
							primKeyCriterias[j] = primKeys[j] + " = @key" + i +j;
						}
						whereStmt = new StringBuilder();
						whereStmt.Append("(");
						whereStmt.Append(String.Join(" AND ", primKeyCriterias));
						whereStmt.Append(")");
						andStmts[i] = whereStmt.ToString();
					}
					selectAdStmt.Append(String.Join(" OR ", andStmts));
					
					command = new SqlCommand(
						selectAdStmt.ToString(), connection);
					for(int i = 0; i < keys.Count; i++)
					{
						for(int j = 0; j < primKeysCount; j++)
						{
							String keyParam = "@key" + i + j;
							command.Parameters.Add(keyParam, ((Key)keys[i])[j]);
						}
					}
					
					reader = command.ExecuteReader();
					
					while(reader.Read())
					{
						Territory territory = loadFields(reader);
						array.Add(territory);
					}
					reader.Close();
				} 
			}
			catch(SqlException sqle)
			{
				throw new ApplicationException(sqle.Message);
			}
			catch(Exception e)
			{
				throw new ApplicationException(e.Message);
			}
			finally
			{
				connection.Close();
			}
			return array;
		}
#endregion		

#region Helper Methods
		public Territory loadFields(SqlDataReader reader)
		{
			Timestamp m_timestamp = safeGetTimestamp(reader);
			Key m_key = new Key(new object[]{
				safeGetValue(reader, "TerritoryID")
			});

			object m_TerritoryId = safeGetString(reader, "TerritoryID");
			object m_TerritoryDescription = safeGetString(reader, "TerritoryDescription");
		
			Territory territory = 
				(Territory)UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(typeof(Territory), m_key);
			
			if(territory == null)
			{
				territory = 
					(Territory)Registry.Instance.getFactory(typeof(Territory)).createFromParameters(
						m_key,
						m_timestamp,
						new DictionaryEntry("TerritoryId", m_TerritoryId),
						new DictionaryEntry("TerritoryDescription", m_TerritoryDescription),
						new DictionaryEntry("Region", new ToOneRelation(typeof(Region), "RegionID", new Key(new object[] { safeGetValue(reader, "RegionID")}))),
						new DictionaryEntry("EmployeeTerritories", new ToManyRelation(typeof(EmployeeTerritory), "TerritoryID", m_key, false)));
				
				UnitOfWork.Instance.IdentityMap.registerDomainObject(territory);
			}
			return territory;
		}

		protected Timestamp safeGetTimestamp(SqlDataReader reader)
		{
			byte[] m_buffer = new byte[8];
			reader.GetBytes(reader.GetOrdinal("VersionId"), 0, m_buffer, 0, 8);
			return new Timestamp(m_buffer);
		}
		
		protected object safeGetString(SqlDataReader reader, string columnName)
		{
			int ordinal = reader.GetOrdinal(columnName);
			return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal).Trim();
		}
		
		protected object safeGetDouble(SqlDataReader reader, string columnName)
		{
			int ordinal = reader.GetOrdinal(columnName);
			return reader.IsDBNull(ordinal) ? null : (object)reader.GetDouble(ordinal);
		}
		
		protected object safeGetInt32(SqlDataReader reader, string columnName)
		{
			int ordinal = reader.GetOrdinal(columnName);
			return reader.IsDBNull(ordinal) ? null : (object)reader.GetInt32(ordinal);
		}
		
		protected object safeGetDateTime(SqlDataReader reader, string columnName)
		{
			int ordinal = reader.GetOrdinal(columnName);
			return reader.IsDBNull(ordinal) ? null : (object)reader.GetDateTime(ordinal);
		}

		protected object safeGetValue(SqlDataReader reader, string columnName)
		{
			int ordinal = reader.GetOrdinal(columnName);
			return reader.IsDBNull(ordinal) ? null : (object)reader.GetValue(ordinal);
		}
#endregion

	}
}
