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
using Storm.Lib;
using Storm.Attributes;
using NorthWind;

namespace NorthWind
{

	[DomainObjectImpl]
	public class EmployeeTerritoryImpl : EmployeeTerritory
	{
#region Factory Implementation
			public class FactoryImpl : IFactory
			{
			
			public DomainObject create()
			{
				return new EmployeeTerritoryImpl();
			}
			
			public DomainObject createFromParameters(
				Key id,
				Timestamp timestamp,
				params DictionaryEntry[] parameters)
			{
				return new EmployeeTerritoryImpl(id, timestamp, parameters);
			}
		}
#endregion

#region Finder Implementation
		public class FinderImpl : IFinder
		{
			public DomainObject findById(Key id)
			{
				return Registry.Instance.getMapper(typeof(EmployeeTerritory)).findById(id);
			}
			public IList find(QueryObject qo)
			{
				return Registry.Instance.getMapper(typeof(EmployeeTerritory)).find(qo);
			}
			public IList findAll()
			{
				return Registry.Instance.getMapper(typeof(EmployeeTerritory)).findAll();
			}
		}
#endregion

#region Static Attributes
		private static FactoryImpl m_FactoryImpl = new FactoryImpl();
		private static FinderImpl m_FinderImpl = new FinderImpl();
#endregion
		
#region Member Variables
		private ToOneRelation m_Employee = null;
		private ToOneRelation m_Territory = null;
#endregion

#region Constructors
		public EmployeeTerritoryImpl()
		{
			markNew();
			m_Employee = new ToOneRelation(typeof(Employee), "EmployeeID", null);
			m_Territory = new ToOneRelation(typeof(Territory), "TerritoryID", null);
		}
		

		internal EmployeeTerritoryImpl(
			Key id, 
			Timestamp timestamp, 
			params DictionaryEntry[] parameters)
		{ 
			markClean();
			m_id = id;
			m_timestamp = timestamp;
			FieldInfo fInfo;
			Type thisType = this.GetType();
			Type domainObjectType = typeof(EmployeeTerritory);
			
			IEnumerator enumerator = parameters.GetEnumerator();

			while(enumerator.MoveNext())
			{
				if(((DictionaryEntry)enumerator.Current).Value != null)
				{
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToOneRelation))
					{ 
						if((String)((DictionaryEntry)enumerator.Current).Key == "Employee")
						{ 
							m_Employee = (ToOneRelation)((DictionaryEntry)enumerator.Current).Value;
							continue;
						}
						if((String)((DictionaryEntry)enumerator.Current).Key == "Territory")
						{ 
							m_Territory = (ToOneRelation)((DictionaryEntry)enumerator.Current).Value;
							continue;
						}
					} 
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToManyRelation))
					{ 
					}
				} 
				if(this.GetType().GetProperty((String)((DictionaryEntry)enumerator.Current).Key) != null)
				{
					string variable = "m_" + (String)((DictionaryEntry)enumerator.Current).Key;
					if((fInfo = thisType.GetField(variable, BindingFlags.DeclaredOnly|BindingFlags.Public|BindingFlags.NonPublic|BindingFlags.Instance)) != null)
					{
							fInfo.SetValue(this, ((DictionaryEntry)enumerator.Current).Value);
					}
				}
			}
		}
#endregion

#region Methods
		
		public override void delete()
		{
			
			this.markRemoved();
		}
#endregion

#region Properties
		public override Employee Employee 
		{
			get
			{
				return (Employee)m_Employee.Object;
			}
			set
			{
				m_Employee.Object = value;
			}
		}
		public override Territory Territory 
		{
			get
			{
				return (Territory)m_Territory.Object;
			}
			set
			{
				m_Territory.Object = value;
			}
		}
				
		public static FactoryImpl Factory
		{
			get
			{
				return m_FactoryImpl;
			}
		}
		
		public static FinderImpl Finder
		{
			get
			{
				return m_FinderImpl;
			}
		}
		
		public override bool isNull(string propertyName)
		{
			switch(propertyName)
			{
				case "Employee":
					if(m_Employee.Object == null) return true;
					break;
				case "Territory":
					if(m_Territory.Object == null) return true;
					break;
				default:
					break;
			}
			return false;
		}
#endregion
	}

}
