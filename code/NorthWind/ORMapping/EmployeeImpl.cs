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
	public class EmployeeImpl : Employee
	{
#region Factory Implementation
		public class FactoryImpl : EmployeeFactory, IFactory
		{ 			
			public DomainObject create()
			{
				return new EmployeeImpl();
			}
			
			public DomainObject createFromParameters(
				Key id,
				Timestamp timestamp,
				params DictionaryEntry[] parameters)
			{
				return new EmployeeImpl(id, timestamp, parameters);
			}
		}
#endregion

#region Finder Implementation
		public class FinderImpl : EmployeeFinder, IFinder
		{
			public override IList findByName(String name)
			{
				QueryObject qo = new QueryObject();
				qo.addCriteria(new Criteria(Criteria.Operator.Equal, "LastName", name));

				return Registry.Instance.getMapper(typeof(Employee)).find(qo);
			}
			public DomainObject findById(Key id)
			{
				return Registry.Instance.getMapper(typeof(Employee)).findById(id);
			}
			public IList find(QueryObject qo)
			{
				return Registry.Instance.getMapper(typeof(Employee)).find(qo);
			}
			public IList findAll()
			{
				return Registry.Instance.getMapper(typeof(Employee)).findAll();
			}
		}
#endregion

#region Static Attributes
		private static FactoryImpl m_FactoryImpl = new FactoryImpl();
		private static FinderImpl m_FinderImpl = new FinderImpl();
#endregion
		
#region Member Variables
		private object m_LastName = null;
		private object m_FirstName = null;
		private object m_Title = null;
		private object m_BirthDate = null;
		private object m_City = null;
		private object m_HireDate = null;
		private ToOneRelation m_ReportsTo = null;
		private ToManyRelation m_ReportedBy = null;
		private ToManyRelation m_EmployeeTerritories = null;
#endregion

#region Constructors
		public EmployeeImpl()
		{
			markNew();
			m_ReportsTo = new ToOneRelation(typeof(Employee), "ReportsTo", null);
		}
		

		internal EmployeeImpl(
			Key id, 
			Timestamp timestamp, 
			params DictionaryEntry[] parameters)
		{ 
			markClean();
			m_id = id;
			m_timestamp = timestamp;
			FieldInfo fInfo;
			Type thisType = this.GetType();
			Type domainObjectType = typeof(Employee);
			
			IEnumerator enumerator = parameters.GetEnumerator();

			while(enumerator.MoveNext())
			{
				if(((DictionaryEntry)enumerator.Current).Value != null)
				{
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToOneRelation))
					{ 
						if((String)((DictionaryEntry)enumerator.Current).Key == "ReportsTo")
						{ 
							m_ReportsTo = (ToOneRelation)((DictionaryEntry)enumerator.Current).Value;
							continue;
						}
					} 
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToManyRelation))
					{ 
						if((String)((DictionaryEntry)enumerator.Current).Key == "ReportedBy")
						{ 
							m_ReportedBy = (ToManyRelation)((DictionaryEntry)enumerator.Current).Value;
							continue;
						}
						if((String)((DictionaryEntry)enumerator.Current).Key == "EmployeeTerritories")
						{ 
							m_EmployeeTerritories = (ToManyRelation)((DictionaryEntry)enumerator.Current).Value;
							continue;
						}
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
		public override void addReportedBy(Employee e)
		{
			if(e != null)
			{
				e.ReportsTo = this;
				m_ReportedBy.Add(e);
				this.markDirty();
			}
			else
			{
				throw new ApplicationException();
			}
		}
		
		public override void delete()
		{
			foreach(Employee employee in ReportedBy)
			{
				employee.delete();
			}
			foreach(EmployeeTerritory employeeterritory in EmployeeTerritories)
			{
				employeeterritory.delete();
			}
			
			this.markRemoved();
		}
#endregion

#region Properties
		public override Int32 EmployeeId 
		{
			get
			{
				if(m_id == null)
					return 0;			
				return (Int32)m_id[0];
			}
		}
		public override String LastName 
		{
			get
			{
				if(m_LastName == null)
					return String.Empty;			
				return (String)m_LastName;
			}
			set
			{
				m_LastName = value;
				markDirty();
			}
		}
		public override String FirstName 
		{
			get
			{
				if(m_FirstName == null)
					return String.Empty;			
				return (String)m_FirstName;
			}
			set
			{
				m_FirstName = value;
				markDirty();
			}
		}
		public override String Title 
		{
			get
			{
				if(m_Title == null)
					return String.Empty;			
				return (String)m_Title;
			}
			set
			{
				m_Title = value;
				markDirty();
			}
		}
		public override DateTime BirthDate 
		{
			get
			{
				if(m_BirthDate == null)
					return new DateTime(0);			
				return (DateTime)m_BirthDate;
			}
			set
			{
				m_BirthDate = value;
				markDirty();
			}
		}
		public override String City 
		{
			get
			{
				if(m_City == null)
					return String.Empty;			
				return (String)m_City;
			}
			set
			{
				m_City = value;
				markDirty();
			}
		}
		public override DateTime HireDate 
		{
			get
			{
				if(m_HireDate == null)
					return new DateTime(0);			
				return (DateTime)m_HireDate;
			}
			set
			{
				m_HireDate = value;
				markDirty();
			}
		}
		public override Employee ReportsTo 
		{
			get
			{
				return (Employee)m_ReportsTo.Object;
			}
			set
			{
				m_ReportsTo.Object = value;
			}
		}
		public override IList ReportedBy 
		{
			get
			{
				return (IList)m_ReportedBy;
			}
		}
		public override IList EmployeeTerritories 
		{
			get
			{
				return (IList)m_EmployeeTerritories;
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
				case "LastName":
					if(m_LastName == null) return true;
					break;
				case "FirstName":
					if(m_FirstName == null) return true;
					break;
				case "Title":
					if(m_Title == null) return true;
					break;
				case "BirthDate":
					if(m_BirthDate == null) return true;
					break;
				case "City":
					if(m_City == null) return true;
					break;
				case "HireDate":
					if(m_HireDate == null) return true;
					break;
				case "ReportsTo":
					if(m_ReportsTo.Object == null) return true;
					break;
				default:
					break;
			}
			return false;
		}
#endregion
	}

}
