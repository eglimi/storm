using System;
using System.Text;
using System.Collections;
using Storm.Attributes;
using Storm.Lib;

namespace NorthWind
{
	/// <summary>
	/// Summary description for Employee.
	/// </summary>
	[Table("Employees", true),
	VersionField("VersionId"),
	GenerateCode]
	public abstract class Employee : DomainObject
	{
		[Finder]
		public abstract class EmployeeFinder
		{
			public abstract IList findByName([ParameterDef("LastName")] string name);
		}
		
		[Factory]
		public abstract class EmployeeFactory
		{
		}

		[Column("EmployeeID"), PrimaryKey]
		public abstract int EmployeeId {get;}

		[Column("LastName")]
		public abstract string LastName {get;set;}

		[Column("FirstName")]
		public abstract string FirstName {get;set;}

		[Column("Title")]
		public abstract string Title {get;set;}

		[Column("BirthDate")]
		public abstract DateTime BirthDate {get;set;}

		[Column("City")]
		public abstract string City {get;set;}
 
		[Column("HireDate")]
		public abstract DateTime HireDate {get;set;}

		[Column("ReportsTo"),
		ToOne(typeof(Employee), "ReportsTo")]
		public abstract Employee ReportsTo {get; set;}

		[ToMany(typeof(Employee), "ReportsTo")]
		public abstract IList ReportedBy {get;}

		[Adder("ReportedBy", "ReportsTo")]
		public abstract void addReportedBy(Employee e);
			 
		[ToMany(typeof(EmployeeTerritory), "Employee")]
		public abstract IList EmployeeTerritories {get;}

		public string FullName
		{
			get
			{
				return FirstName + ", " + LastName;
			}
		}
	}
}
