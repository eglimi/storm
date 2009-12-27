using System;
using System.Text;
using System.Collections;
using Storm.Attributes;
using Storm.Lib;

namespace NorthWind
{
	/// <summary>
	/// Summary description for Territory.
	/// </summary>
	[Table("Territories", false),
	VersionField("VersionId"),
	GenerateCode]
	public abstract class Territory : DomainObject
	{
		[Column("TerritoryID"), PrimaryKey]
		public abstract string TerritoryId {get; set;}

		[Column("TerritoryDescription")]
		public abstract string TerritoryDescription {get; set;}

		[Column("RegionID"),
		ToOne(typeof(Region), "RegionId")]
		public abstract Region Region {get; set;}

		[ToMany(typeof(EmployeeTerritory), "Territory")]
		public abstract IList EmployeeTerritories {get; }		

		[Adder("EmployeeTerritories", "Territory")]
		public abstract void addTerritory(EmployeeTerritory et);
	}
}
