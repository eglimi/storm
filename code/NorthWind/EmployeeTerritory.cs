using System;
using System.Text;
using System.Collections;
using Storm.Attributes;
using Storm.Lib;

namespace NorthWind
{
	/// <summary>
	/// Summary description for EmployeeTerritory.
	/// </summary>
	[Table("EmployeeTerritories", false),
	VersionField("VersionId"),
	GenerateCode]
	public abstract class EmployeeTerritory : DomainObject
	{
		[Column("EmployeeID"), PrimaryKey,
		 ToOne(typeof(Employee), "EmployeeId")]
		public abstract Employee Employee {get; set;}

		[Column("TerritoryID"), PrimaryKey,
		 ToOne(typeof(Territory), "TerritoryId")]
		public abstract Territory Territory {get; set;}
	}
}
