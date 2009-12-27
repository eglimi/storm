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
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using Storm.Lib;
using Storm.Attributes;
using HsrOrderApp.BusinessLayer.DomainModel;

namespace HsrOrderApp.BusinessLayer.DataMapper
{


	[MapperImpl(typeof(Order))]
	public class OrderMapper : IMapper
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
					"SELECT * from Orders WHERE OrderID = @OrderId";
				SqlCommand command = new SqlCommand(sqlStmt, connection);
				command.Parameters.Add("@OrderId", id[0]);

				reader = command.ExecuteReader();
				Order order = null;
				if(reader.Read())
				{
					order = loadFields(reader);
				} 
				if(reader != null)
					reader.Close();
				connection.Close();

				return order;
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
					"SELECT * from Orders";
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
					"SELECT * from Orders WHERE " + qo.ToString();
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
				Order order = (Order)subject;
				SqlCommand command = new SqlCommand(
					"INSERT INTO Orders (ShippedDate, OrderDate, PersonID, OrderState) VALUES (@ShippedDate, @OrderDate, @Person, @OrderState) ; SELECT OrderID, chTimestamp FROM Orders WHERE OrderID = SCOPE_IDENTITY()",
					connection, transaction);

				if(subject.isNull("ShippedDate"))
				{
					command.Parameters.Add("@ShippedDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ShippedDate", order.ShippedDate);
				}
				if(subject.isNull("OrderDate"))
				{
					command.Parameters.Add("@OrderDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@OrderDate", order.OrderDate);
				}
				if(subject.isNull("Person") || order.Person.isNull("PersonId"))
				{
					command.Parameters.Add("@Person", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Person", order.Person.PersonId);
				}
				if(subject.isNull("OrderState"))
				{
					command.Parameters.Add("@OrderState", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@OrderState", order.OrderState);
				}
				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					order.Id = new Key(new object[] {
						safeGetInt32(reader, "OrderID")});
					order.Timestamp = safeGetTimestamp(reader);
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
				Order order = (Order)subject;
				SqlCommand command = new SqlCommand(
					"UPDATE Orders SET ShippedDate = @ShippedDate, OrderDate = @OrderDate, PersonID = @Person, OrderState = @OrderState WHERE OrderID = @OrderId AND chTimestamp = @chTimestamp IF @@ROWCOUNT > 0  BEGIN SELECT chTimestamp FROM Orders WHERE OrderID = @OrderId END",
					connection, transaction); 

				command.Parameters.Add("@chTimestamp", order.Timestamp.Value);
				if(subject.isNull("OrderId"))
				{
					command.Parameters.Add("@OrderId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@OrderId", order.OrderId);
				}
				if(subject.isNull("ShippedDate"))
				{
					command.Parameters.Add("@ShippedDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ShippedDate", order.ShippedDate);
				}
				if(subject.isNull("OrderDate"))
				{
					command.Parameters.Add("@OrderDate", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@OrderDate", order.OrderDate);
				}
				if(subject.isNull("Person") || order.Person.isNull("PersonId"))
				{
					command.Parameters.Add("@Person", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Person", order.Person.Id[0]);
				}
				if(subject.isNull("OrderState"))
				{
					command.Parameters.Add("@OrderState", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@OrderState", order.OrderState);
				}

				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					order.Timestamp = safeGetTimestamp(reader);
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
				Order order = (Order)subject;
				
				SqlCommand command = new SqlCommand(
					"DELETE FROM Orders WHERE OrderID = @OrderId AND chTimestamp = @chTimestamp",
					connection, transaction);

				command.Parameters.Add("@chTimestamp", order.Timestamp.Value);
				if(subject.isNull("OrderId"))
				{
					command.Parameters.Add("@OrderId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@OrderId", order.OrderId);
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
				String selectStmt = "SELECT * FROM Orders WHERE " + fieldName + " = @FK";
				SqlCommand command = new SqlCommand(selectStmt, connection);
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				Order order = null;
				
				if(reader.Read())
				{
					order = loadFields(reader);
				}
				if(reader != null)
				{
					reader.Close();
				}
				connection.Close();
				
				return order;
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
					"SELECT OrderID, chTimestamp FROM Orders WHERE " + fieldName + " = @FK", connection);
					
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				ArrayList keys = new ArrayList();
				Timestamp timestamp;
				while(reader.Read())
				{ 
					object orderid = safeGetValue(reader, "OrderID");
					
					timestamp = safeGetTimestamp(reader);
					
					Key currentKey = new Key(new object[]{orderid});
					DomainObject domobj = UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(
						typeof(Order), currentKey);
					
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
					primKeys.Add("OrderID");
					StringBuilder selectAdStmt = new StringBuilder();
					selectAdStmt.Append("SELECT * FROM ");
					selectAdStmt.Append("Orders");
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
						Order order = loadFields(reader);
						array.Add(order);
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
		public Order loadFields(SqlDataReader reader)
		{
			Timestamp m_timestamp = safeGetTimestamp(reader);
			Key m_key = new Key(new object[]{
				safeGetValue(reader, "OrderID")
			});
		
			object m_OrderDate = safeGetDateTime(reader, "OrderDate");
			object m_ShippedDate = safeGetDateTime(reader, "ShippedDate");
			object m_OrderState = safeGetString(reader, "OrderState");
		
			Order order = 
				(Order)UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(typeof(Order), m_key);
			
			if(order == null)
			{
				order = 
					(Order)Registry.Instance.getFactory(typeof(Order)).createFromParameters(
						m_key,
						m_timestamp,
						new DictionaryEntry("Person", new ToOneRelation(typeof(Person), "PersonID", new Key(new object[] { safeGetValue(reader, "PersonID")}))),
						new DictionaryEntry("OrderDate", m_OrderDate),
						new DictionaryEntry("ShippedDate", m_ShippedDate),
						new DictionaryEntry("OrderState", m_OrderState),
						new DictionaryEntry("OrderDetails", new ToManyRelation(typeof(OrderDetail), "OrderID", m_key, false)));
				
				UnitOfWork.Instance.IdentityMap.registerDomainObject(order);
			}
			return order;
		}

		protected Timestamp safeGetTimestamp(SqlDataReader reader)
		{
			byte[] m_buffer = new byte[8];
			reader.GetBytes(reader.GetOrdinal("chTimestamp"), 0, m_buffer, 0, 8);
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
