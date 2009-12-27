using System;
using System.Text;
using System.Collections;
using Storm.Attributes;
using Storm.Lib;

namespace NorthWind
{
	/// <summary>
	/// Summary description for Region.
	/// </summary>
	[Table("Region", true),
	VersionField("VersionId"),
	GenerateCode]
	public abstract class Region : DomainObject
	{
		[Column("RegionID"), PrimaryKey]
		public abstract int RegionId {get;}

		[Column("RegionDescription")]
		public abstract string Description {get;}

		[ToMany(typeof(Territory), "Region")]
		public abstract IList Territories {get;}

		[Adder("Territories", "Region")]
		public abstract void addTerritory(Territory t);
	}
}
