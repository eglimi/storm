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
using HsrOrderApp.BusinessLayer.DomainModel;

namespace HsrOrderApp.BusinessLayer.DomainModelImpl
{

	[DomainObjectImpl]
	public class AddressImpl : Address
	{
#region Factory Implementation
		public class FactoryImpl : AddressFactory, IFactory
		{ 
			public override Address createAddress(Person person, String city, String street, String postalCode, String phone, String email)
			{
				return new AddressImpl(person, city, street, postalCode, phone, email);
			}
			
			public DomainObject create()
			{
				return new AddressImpl();
			}
			
			public DomainObject createFromParameters(
				Key id,
				Timestamp timestamp,
				params DictionaryEntry[] parameters)
			{
				return new AddressImpl(id, timestamp, parameters);
			}
		}
#endregion

#region Finder Implementation
		public class FinderImpl : AddressFinder, IFinder
		{
			public override IList findByPlz(String name)
			{
				QueryObject qo = new QueryObject();
				qo.addCriteria(new Criteria(Criteria.Operator.Equal, "PostalCode", name));

				return Registry.Instance.getMapper(typeof(Address)).find(qo);
			}
			public DomainObject findById(Key id)
			{
				return Registry.Instance.getMapper(typeof(Address)).findById(id);
			}
			public IList find(QueryObject qo)
			{
				return Registry.Instance.getMapper(typeof(Address)).find(qo);
			}
			public IList findAll()
			{
				return Registry.Instance.getMapper(typeof(Address)).findAll();
			}
		}
#endregion

#region Static Attributes
		private static FactoryImpl m_FactoryImpl = new FactoryImpl();
		private static FinderImpl m_FinderImpl = new FinderImpl();
#endregion
		
#region Member Variables
		private ToOneRelation m_Person = null;
		private object m_City = null;
		private object m_Street = null;
		private object m_PostalCode = null;
		private object m_Phone = null;
		private object m_Email = null;
#endregion

#region Constructors
		public AddressImpl()
		{
		}
		
		public AddressImpl(Person person, String city, String street, String postalCode, String phone, String email)
		{
			markNew();
			m_Person = new ToOneRelation(typeof(Person), "PersonID", null);
			m_Email = email;
			m_Street = street;
			m_City = city;
			m_Phone = phone;
			m_Person.Object = person;
			m_PostalCode = postalCode;
		}

		internal AddressImpl(
			Key id, 
			Timestamp timestamp, 
			params DictionaryEntry[] parameters)
		{ 
			markClean();
			m_id = id;
			m_timestamp = timestamp;
			FieldInfo fInfo;
			Type thisType = this.GetType();
			Type domainObjectType = typeof(Address);
			
			IEnumerator enumerator = parameters.GetEnumerator();

			while(enumerator.MoveNext())
			{
				if(((DictionaryEntry)enumerator.Current).Value != null)
				{
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToOneRelation))
					{ 
						if((String)((DictionaryEntry)enumerator.Current).Key == "Person")
						{ 
							m_Person = (ToOneRelation)((DictionaryEntry)enumerator.Current).Value;
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
		public override Int32 AddressId 
		{
			get
			{
				if(m_id == null)
					return 0;			
				return (Int32)m_id[0];
			}
		}
		public override Person Person 
		{
			get
			{
				return (Person)m_Person.Object;
			}
			set
			{
				m_Person.Object = value;
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
		public override String Street 
		{
			get
			{
				if(m_Street == null)
					return String.Empty;			
				return (String)m_Street;
			}
			set
			{
				m_Street = value;
				markDirty();
			}
		}
		public override String PostalCode 
		{
			get
			{
				if(m_PostalCode == null)
					return String.Empty;			
				return (String)m_PostalCode;
			}
			set
			{
				m_PostalCode = value;
				markDirty();
			}
		}
		public override String Phone 
		{
			get
			{
				if(m_Phone == null)
					return String.Empty;			
				return (String)m_Phone;
			}
			set
			{
				m_Phone = value;
				markDirty();
			}
		}
		public override String Email 
		{
			get
			{
				if(m_Email == null)
					return String.Empty;			
				return (String)m_Email;
			}
			set
			{
				m_Email = value;
				markDirty();
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
				case "Person":
					if(m_Person.Object == null) return true;
					break;
				case "City":
					if(m_City == null) return true;
					break;
				case "Street":
					if(m_Street == null) return true;
					break;
				case "PostalCode":
					if(m_PostalCode == null) return true;
					break;
				case "Phone":
					if(m_Phone == null) return true;
					break;
				case "Email":
					if(m_Email == null) return true;
					break;
				default:
					break;
			}
			return false;
		}
#endregion
	}

}
