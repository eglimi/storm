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


	[MapperImpl(typeof(Employee))]
	public class EmployeeMapper : IMapper
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
					"SELECT * from Employees WHERE EmployeeID = @EmployeeId";
				SqlCommand command = new SqlCommand(sqlStmt, connection);
				command.Parameters.Add("@EmployeeId", id[0]);

				reader = command.ExecuteReader();
				Employee employee = null;
				if(reader.Read())
				{
					employee = loadFields(reader);
				} 
				if(reader != null)
					reader.Close();
				connection.Close();

				return employee;
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
					"SELECT * from Employees";
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
					"SELECT * from Employees WHERE " + qo.ToString();
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
				Employee employee = (Employee)subject;
				SqlCommand command = new SqlCommand(
					"INSERT INTO Employees (Title, FirstName, BirthDate, ReportsTo, City, LastName, HireDate) VALUES (@Title, @FirstName, @BirthDate, @ReportsTo, @City, @LastName, @HireDate) ; SELECT EmployeeID, VersionId FROM Employees WHERE EmployeeID = SCOPE_IDENTITY()",
					connection, transaction);

				if(subject.isNull("Title"))
				{
					command.Parameters.Add("@Title", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Title", employee.Title);
				}
				if(subject.isNull("FirstName"))
				{
					command.Parameters.Add("@FirstName", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@FirstName", employee.FirstName);
				}
				if(subject.isNull("BirthDate"))
				{
					command.Parameters.Add("@BirthDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@BirthDate", employee.BirthDate);
				}
				if(subject.isNull("ReportsTo") || employee.ReportsTo.isNull("ReportsTo"))
				{
					command.Parameters.Add("@ReportsTo", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ReportsTo", employee.ReportsTo.ReportsTo);
				}
				if(subject.isNull("City"))
				{
					command.Parameters.Add("@City", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@City", employee.City);
				}
				if(subject.isNull("LastName"))
				{
					command.Parameters.Add("@LastName", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@LastName", employee.LastName);
				}
				if(subject.isNull("HireDate"))
				{
					command.Parameters.Add("@HireDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@HireDate", employee.HireDate);
				}
				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					employee.Id = new Key(new object[] {
						safeGetInt32(reader, "EmployeeID")});
					employee.Timestamp = safeGetTimestamp(reader);
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
				Employee employee = (Employee)subject;
				SqlCommand command = new SqlCommand(
					"UPDATE Employees SET Title = @Title, FirstName = @FirstName, BirthDate = @BirthDate, ReportsTo = @ReportsTo, City = @City, LastName = @LastName, HireDate = @HireDate WHERE EmployeeID = @EmployeeId AND VersionId = @VersionId IF @@ROWCOUNT > 0  BEGIN SELECT VersionId FROM Employees WHERE EmployeeID = @EmployeeId END",
					connection, transaction); 

				command.Parameters.Add("@VersionId", employee.Timestamp.Value);
				if(subject.isNull("EmployeeId"))
				{
					command.Parameters.Add("@EmployeeId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@EmployeeId", employee.EmployeeId);
				}
				if(subject.isNull("Title"))
				{
					command.Parameters.Add("@Title", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Title", employee.Title);
				}
				if(subject.isNull("FirstName"))
				{
					command.Parameters.Add("@FirstName", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@FirstName", employee.FirstName);
				}
				if(subject.isNull("BirthDate"))
				{
					command.Parameters.Add("@BirthDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@BirthDate", employee.BirthDate);
				}
				if(subject.isNull("ReportsTo") || employee.ReportsTo.isNull("ReportsTo"))
				{
					command.Parameters.Add("@ReportsTo", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ReportsTo", employee.ReportsTo.Id[0]);
				}
				if(subject.isNull("City"))
				{
					command.Parameters.Add("@City", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@City", employee.City);
				}
				if(subject.isNull("LastName"))
				{
					command.Parameters.Add("@LastName", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@LastName", employee.LastName);
				}
				if(subject.isNull("HireDate"))
				{
					command.Parameters.Add("@HireDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@HireDate", employee.HireDate);
				}

				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					employee.Timestamp = safeGetTimestamp(reader);
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
				Employee employee = (Employee)subject;
				
				SqlCommand command = new SqlCommand(
					"DELETE FROM Employees WHERE EmployeeID = @EmployeeId AND VersionId = @VersionId",
					connection, transaction);

				command.Parameters.Add("@VersionId", employee.Timestamp.Value);
				if(subject.isNull("EmployeeId"))
				{
					command.Parameters.Add("@EmployeeId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@EmployeeId", employee.EmployeeId);
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
				String selectStmt = "SELECT * FROM Employees WHERE " + fieldName + " = @FK";
				SqlCommand command = new SqlCommand(selectStmt, connection);
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				Employee employee = null;
				
				if(reader.Read())
				{
					employee = loadFields(reader);
				}
				if(reader != null)
				{
					reader.Close();
				}
				connection.Close();
				
				return employee;
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
					"SELECT EmployeeID, VersionId FROM Employees WHERE " + fieldName + " = @FK", connection);
					
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				ArrayList keys = new ArrayList();
				Timestamp timestamp;
				while(reader.Read())
				{ 
					object employeeid = safeGetValue(reader, "EmployeeID");
					
					timestamp = safeGetTimestamp(reader);
					
					Key currentKey = new Key(new object[]{employeeid});
					DomainObject domobj = UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(
						typeof(Employee), currentKey);
					
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
					primKeys.Add("EmployeeID");
					StringBuilder selectAdStmt = new StringBuilder();
					selectAdStmt.Append("SELECT * FROM ");
					selectAdStmt.Append("Employees");
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
						Employee employee = loadFields(reader);
						array.Add(employee);
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
		public Employee loadFields(SqlDataReader reader)
		{
			Timestamp m_timestamp = safeGetTimestamp(reader);
			Key m_key = new Key(new object[]{
				safeGetValue(reader, "EmployeeID")
			});

			object m_LastName = safeGetString(reader, "LastName");
			object m_FirstName = safeGetString(reader, "FirstName");
			object m_Title = safeGetString(reader, "Title");
			object m_BirthDate = safeGetDateTime(reader, "BirthDate");
			object m_City = safeGetString(reader, "City");
			object m_HireDate = safeGetDateTime(reader, "HireDate");
		
			Employee employee = 
				(Employee)UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(typeof(Employee), m_key);
			
			if(employee == null)
			{
				employee = 
					(Employee)Registry.Instance.getFactory(typeof(Employee)).createFromParameters(
						m_key,
						m_timestamp,
						new DictionaryEntry("LastName", m_LastName),
						new DictionaryEntry("FirstName", m_FirstName),
						new DictionaryEntry("Title", m_Title),
						new DictionaryEntry("BirthDate", m_BirthDate),
						new DictionaryEntry("City", m_City),
						new DictionaryEntry("HireDate", m_HireDate),
						new DictionaryEntry("ReportsTo", new ToOneRelation(typeof(Employee), "ReportsTo", new Key(new object[] { safeGetValue(reader, "ReportsTo")}))),
						new DictionaryEntry("ReportedBy", new ToManyRelation(typeof(Employee), "ReportsTo", m_key, false)),
						new DictionaryEntry("EmployeeTerritories", new ToManyRelation(typeof(EmployeeTerritory), "EmployeeID", m_key, false)));
				
				UnitOfWork.Instance.IdentityMap.registerDomainObject(employee);
			}
			return employee;
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
