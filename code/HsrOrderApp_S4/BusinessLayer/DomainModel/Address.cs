using System;
using System.Text;
using System.Collections;
using Storm.Attributes;
using Storm.Lib;
namespace HsrOrderApp.BusinessLayer.DomainModel
{
	/// <summary>
	/// Abstract Address class. Used to genereate Code.
	/// </summary>
	[Table("Addresses", true),
	VersionField("chTimeStamp"),
	GenerateCode]
	public abstract class Address : DomainObject
	{
		[Factory]
		public abstract class AddressFactory
		{
			public abstract Address createAddress(
			[ParameterDef("Person")] Person person,
			[ParameterDef("City")] string city,
			[ParameterDef("Street")] string street,
			[ParameterDef("PostalCode")] string postalCode,
			[ParameterDef("Phone")] string phone,
			[ParameterDef("Email")] string email);
		}

		[Finder]
		public abstract class AddressFinder
		{
			public abstract IList findByPlz([ParameterDef("PostalCode")] string name);
		}

		[Column("AddressID"),
		PrimaryKey]
		public abstract int AddressId {get;}

		[Column("PersonID"),
		ToOne(typeof(Person), "PersonId")]
		public abstract Person Person {get; set;}

		[Column("City")]
		public abstract string City {get; set;}

		[Column("Street")]
		public abstract string Street {get; set;}

		[Column("PostalCode")]
		public abstract string PostalCode {get; set;}

		[Column("Phone")]
		public abstract string Phone {get; set;}

		[Column("Email")]
		public abstract string Email {get; set;}

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			output.AppendFormat("Address({0}): {1}, {2}, {3}, {4}, {5}, {6}",
				GetHashCode(), AddressId, Street, PostalCode, City, Phone, Email);
			return output.ToString();
		}
	}
}
