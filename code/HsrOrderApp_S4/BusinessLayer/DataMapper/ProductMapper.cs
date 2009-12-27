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


	[MapperImpl(typeof(Product))]
	public class ProductMapper : IMapper
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
					"SELECT * from Products WHERE ProductID = @ProductId";
				SqlCommand command = new SqlCommand(sqlStmt, connection);
				command.Parameters.Add("@ProductId", id[0]);

				reader = command.ExecuteReader();
				Product product = null;
				if(reader.Read())
				{
					product = loadFields(reader);
				} 
				if(reader != null)
					reader.Close();
				connection.Close();

				return product;
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
					"SELECT * from Products";
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
					"SELECT * from Products WHERE " + qo.ToString();
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
				Product product = (Product)subject;
				SqlCommand command = new SqlCommand(
					"INSERT INTO Products (UnitPrice, Category, ProductName, QuantityPerUnit) VALUES (@UnitPrice, @Category, @ProductName, @QuantityPerUnit) ; SELECT ProductID, chTimestamp FROM Products WHERE ProductID = SCOPE_IDENTITY()",
					connection, transaction);

				if(subject.isNull("UnitPrice"))
				{
					command.Parameters.Add("@UnitPrice", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@UnitPrice", product.UnitPrice);
				}
				if(subject.isNull("Category"))
				{
					command.Parameters.Add("@Category", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Category", product.Category);
				}
				if(subject.isNull("ProductName"))
				{
					command.Parameters.Add("@ProductName", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ProductName", product.ProductName);
				}
				if(subject.isNull("QuantityPerUnit"))
				{
					command.Parameters.Add("@QuantityPerUnit", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@QuantityPerUnit", product.QuantityPerUnit);
				}
				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					product.Id = new Key(new object[] {
						safeGetInt32(reader, "ProductID")});
					product.Timestamp = safeGetTimestamp(reader);
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
				Product product = (Product)subject;
				SqlCommand command = new SqlCommand(
					"UPDATE Products SET UnitPrice = @UnitPrice, Category = @Category, ProductName = @ProductName, QuantityPerUnit = @QuantityPerUnit WHERE ProductID = @ProductId AND chTimestamp = @chTimestamp IF @@ROWCOUNT > 0  BEGIN SELECT chTimestamp FROM Products WHERE ProductID = @ProductId END",
					connection, transaction); 

				command.Parameters.Add("@chTimestamp", product.Timestamp.Value);
				if(subject.isNull("ProductId"))
				{
					command.Parameters.Add("@ProductId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ProductId", product.ProductId);
				}
				if(subject.isNull("UnitPrice"))
				{
					command.Parameters.Add("@UnitPrice", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@UnitPrice", product.UnitPrice);
				}
				if(subject.isNull("Category"))
				{
					command.Parameters.Add("@Category", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@Category", product.Category);
				}
				if(subject.isNull("ProductName"))
				{
					command.Parameters.Add("@ProductName", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ProductName", product.ProductName);
				}
				if(subject.isNull("QuantityPerUnit"))
				{
					command.Parameters.Add("@QuantityPerUnit", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@QuantityPerUnit", product.QuantityPerUnit);
				}

				SqlDataReader reader = command.ExecuteReader();
				if(reader.Read())
				{
					product.Timestamp = safeGetTimestamp(reader);
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
				Product product = (Product)subject;
				
				SqlCommand command = new SqlCommand(
					"DELETE FROM Products WHERE ProductID = @ProductId AND chTimestamp = @chTimestamp",
					connection, transaction);

				command.Parameters.Add("@chTimestamp", product.Timestamp.Value);
				if(subject.isNull("ProductId"))
				{
					command.Parameters.Add("@ProductId", DBNull.Value );
				}
				else
				{
					command.Parameters.Add("@ProductId", product.ProductId);
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
				String selectStmt = "SELECT * FROM Products WHERE " + fieldName + " = @FK";
				SqlCommand command = new SqlCommand(selectStmt, connection);
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				Product product = null;
				
				if(reader.Read())
				{
					product = loadFields(reader);
				}
				if(reader != null)
				{
					reader.Close();
				}
				connection.Close();
				
				return product;
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
					"SELECT ProductID, chTimestamp FROM Products WHERE " + fieldName + " = @FK", connection);
					
				command.Parameters.Add("@FK", id[0]);
				
				reader = command.ExecuteReader();
				ArrayList keys = new ArrayList();
				Timestamp timestamp;
				while(reader.Read())
				{ 
					object productid = safeGetValue(reader, "ProductID");
					
					timestamp = safeGetTimestamp(reader);
					
					Key currentKey = new Key(new object[]{productid});
					DomainObject domobj = UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(
						typeof(Product), currentKey);
					
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
					primKeys.Add("ProductID");
					StringBuilder selectAdStmt = new StringBuilder();
					selectAdStmt.Append("SELECT * FROM ");
					selectAdStmt.Append("Products");
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
						Product product = loadFields(reader);
						array.Add(product);
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
		public Product loadFields(SqlDataReader reader)
		{
			Timestamp m_timestamp = safeGetTimestamp(reader);
			Key m_key = new Key(new object[]{
				safeGetValue(reader, "ProductID")
			});
		
			object m_ProductName = safeGetString(reader, "ProductName");
			object m_QuantityPerUnit = safeGetDouble(reader, "QuantityPerUnit");
			object m_UnitPrice = safeGetDouble(reader, "UnitPrice");
			object m_Category = safeGetString(reader, "Category");
		
			Product product = 
				(Product)UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(typeof(Product), m_key);
			
			if(product == null)
			{
				product = 
					(Product)Registry.Instance.getFactory(typeof(Product)).createFromParameters(
						m_key,
						m_timestamp,
						new DictionaryEntry("ProductName", m_ProductName),
						new DictionaryEntry("QuantityPerUnit", m_QuantityPerUnit),
						new DictionaryEntry("UnitPrice", m_UnitPrice),
						new DictionaryEntry("Category", m_Category),
						new DictionaryEntry("OrderDetails", new ToManyRelation(typeof(OrderDetail), "ProductID", m_key, false)));
				
				UnitOfWork.Instance.IdentityMap.registerDomainObject(product);
			}
			return product;
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
