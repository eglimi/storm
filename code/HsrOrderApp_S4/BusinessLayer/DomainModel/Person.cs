using System;
using System.Text;
using System.Collections;
using Storm.Attributes;
using Storm.Lib;

namespace HsrOrderApp.BusinessLayer.DomainModel
{
	/// <summary>
	/// Abstract Person class. Used to genereate Code.
	/// </summary>
	[Table("Persons", true),
	VersionField("chTimestamp"),
	GenerateCode]
	public abstract class Person : DomainObject
	{
		[Factory]
		public abstract class PersonFactory
		{
			public abstract Person createPerson(
				[ParameterDef("Name")] string name,
				[ParameterDef("Password")] string password);
		}

		[Finder]
		public abstract class PersonFinder
		{
			public abstract IList findByName([ParameterDef("Name")] string name);
			public abstract IList findByNameAndPassword(
				[ParameterDef("Name")] string name,
				[ParameterDef("Password")] string password);
		}

		#region Abstract Properties

		[Column("PersonID"),
		PrimaryKey]
		public abstract int PersonId {get;}

		[Column("Name")]
		public abstract string Name {get; set;}

		[Column("Password")]
		public abstract string Password {get; set;}
		
		[ToMany(typeof(Address), "Person")]
		public abstract IList Addresses {get;}

		[ToMany(typeof(Order), "Person")]
		public abstract IList Orders {get;}

		[Adder("Addresses", "Person")]
		public abstract void addAddress(Address a);

		[Adder("Orders", "Person")]
		public abstract void addOrder(Order o);

		#endregion

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			output.AppendFormat("Person({0}): {1}, {2}, {3}",
				GetHashCode(), PersonId, Name, Password);
			return output.ToString();
		}

//		public Address AddAddress(string street, string city, string postalCode, 
//			string email, string phone)
//		{
//			Address address = new Address(this, street, city, postalCode, email, phone);
//			Addresses.Add(address);
//			return address;
//		}

		public Address findAddress(int addressId)
		{
			foreach(Address address in Addresses)
			{
				if((int)address.Id[0] == addressId)
					return address;
			}
			return null;
		}

		public void removeAddress(Address address)
		{
			Addresses.Remove(address);
			address.delete();
		}

//		public Order AddOrder(DateTime orderDate)
//		{
//			Order order = new Order(orderDate, DateTime.MaxValue, this);
//			m_orders.Add(order);
//			return order;
//		}

		public void removeOrder(Order order)
		{
			Orders.Remove(order);
			order.delete();
		}

		public IList findOrderedBetween(DateTime startDate, DateTime endDate)
		{
			ArrayList matches = new ArrayList();
			foreach(Order order in Orders)
			{
				if(order.IsOrderedBetween(startDate, endDate))
					matches.Add(order);
			}
			return matches;        
		}

		public IList findShippedBetween(DateTime startDate, DateTime endDate)
		{
			ArrayList matches = new ArrayList();
			foreach(Order order in Orders)
			{
				if(order.IsShippedBetween(startDate, endDate))
					matches.Add(order);
			}
			return matches;        
		}
	}
}
