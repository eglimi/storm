using System;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for UnitOfWork.
	/// </summary>
	public class UnitOfWork
	{
		IdentityMap m_identityMap;

		string m_hostname;
		string m_database;

		IList m_newObjects = new ArrayList();
		IList m_dirtyObjects = new ArrayList();
		IList m_removedObjects = new ArrayList();

		static LocalDataStoreSlot m_threadSlot = Thread.AllocateDataSlot();

		public UnitOfWork()
		{
//			m_mapperRegistry = new MapperRegistry();
			m_identityMap = new IdentityMap();
		}

		public static UnitOfWork Instance
		{
			get 
			{
				UnitOfWork unitOfWork = (UnitOfWork)Thread.GetData(m_threadSlot);

				if(unitOfWork == null)
				{
					unitOfWork = new UnitOfWork();
					Thread.SetData(m_threadSlot, unitOfWork);
				}
				return unitOfWork;
			}
		}

//		public MapperRegistry MapperRegistry
//		{
//			get { return m_mapperRegistry; }
//		}

		public SqlConnection Connection
		{
			get 
			{
				StringBuilder connectionString = new StringBuilder();
				connectionString.AppendFormat("Initial Catalog={0};Data Source={1};Workstation ID={1};Integrated Security=SSPI",
					m_database, m_hostname);
				return new SqlConnection(connectionString.ToString());
			}
		}
        
		public void registerNew(DomainObject domainObject)
		{
			if(domainObject.State == DomainObject.ObjectState.Detached)
			{
				m_newObjects.Add(domainObject);
				domainObject.State = DomainObject.ObjectState.Added;
			}
			else
			{
				Debug.Assert(false);
			}
		}

		public void registerDirty(DomainObject domainObject)
		{
			switch(domainObject.State)
			{
				case DomainObject.ObjectState.Added:
					break;
				case DomainObject.ObjectState.Deleted:
					break;
				case DomainObject.ObjectState.Modified:
					break;
				case DomainObject.ObjectState.Unchanged:
					domainObject.State = DomainObject.ObjectState.Modified;
					m_dirtyObjects.Add(domainObject);
					break;
			}
		}

		public void registerClean(DomainObject domainObject)
		{
			Debug.Assert(domainObject.State == DomainObject.ObjectState.Detached
				|| domainObject.State == DomainObject.ObjectState.Added);
//			m_identityMap.registerDomainObject(domainObject);
			domainObject.State = DomainObject.ObjectState.Unchanged;
		}

		public void registerDeleted(DomainObject domainObject)
		{
			switch(domainObject.State)
			{
				case DomainObject.ObjectState.Added:
					m_newObjects.Remove(domainObject);
//					m_identityMap.UnregisterDomainObject(domainObject);
					domainObject.State = DomainObject.ObjectState.Detached;
					break;
				case DomainObject.ObjectState.Modified:
					break;
				case DomainObject.ObjectState.Unchanged:
//					m_identityMap.UnregisterDomainObject(domainObject);
					domainObject.State = DomainObject.ObjectState.Deleted;
					m_removedObjects.Add(domainObject);
					break;
				case DomainObject.ObjectState.Detached:
					break;
				case DomainObject.ObjectState.Deleted:
					Debug.Assert(false);
					break;
			} 
		}

		public void commit()
		{
			SqlConnection connection = Connection;
			if(connection.State != ConnectionState.Open)
				connection.Open();
			SqlTransaction transaction = connection.BeginTransaction();;
			try
			{
				foreach(DomainObject subject in m_newObjects)
				{
					//					subject.Mapper.insert(subject);
					Registry.Instance.getMapper(subject.GetType().BaseType)
						.insert(subject, connection, transaction);
					registerClean(subject);
				}
				m_newObjects.Clear();
				foreach(DomainObject subject in m_dirtyObjects)
				{
					//					subject.Mapper.update(subject, connection, transaction);
					Registry.Instance.getMapper(subject.GetType().BaseType)
						.update(subject, connection, transaction);
					subject.State = DomainObject.ObjectState.Unchanged;
				}
				m_dirtyObjects.Clear();
				foreach(DomainObject subject in m_removedObjects)
				{
					//					subject.Mapper.delete(subject);
					Registry.Instance.getMapper(subject.GetType().BaseType)
						.delete(subject, connection, transaction);
					subject.State = DomainObject.ObjectState.Detached;
				}
				m_removedObjects.Clear();
				transaction.Commit();
			}
			catch(SqlException sqle)
			{
				m_newObjects.Clear();
				m_dirtyObjects.Clear();
				m_removedObjects.Clear();
				transaction.Rollback();
			}
			finally
			{
				transaction = null;
				connection.Close();
			}
		}

		public IdentityMap IdentityMap
		{
			get { return m_identityMap; }
		}

		public string Hostname
		{
			get{return m_hostname;}
			set{m_hostname = value;}
		}

		public string Database
		{
			get{return m_database;}
			set{m_database = value;}
		}

	}
}
