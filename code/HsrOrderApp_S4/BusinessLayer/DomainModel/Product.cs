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
	[Table("Products", true),
	VersionField("chTimestamp"),
	GenerateCode]
	public abstract class Product : DomainObject
	{
		[Factory]
		public abstract class ProductFactory
		{
			public abstract Product createProduct(
				[ParameterDef("ProductName")] string productName,
				[ParameterDef("QuantityPerUnit")] double quantityPerUnit,
				[ParameterDef("UnitPrice")] double unitPrice,
				[ParameterDef("Category")] string category);
			}

		[Finder]
		public abstract class ProductFinder
		{
			public abstract IList findByCategory([ParameterDef("Category")] string category);
			public abstract IList findByName([ParameterDef("ProductName")] string name);
		}

		#region Abstract Properties

		[Column("ProductID"),
		PrimaryKey]
		public abstract int ProductId {get;}

		[Column("ProductName")]
		public abstract string ProductName {get; set;}

		[Column("QuantityPerUnit")]
		public abstract double QuantityPerUnit {get; set;}
		
		[Column("UnitPrice")]
		public abstract double UnitPrice {get; set;}

		[Column("Category")]
		public abstract string Category {get; set;}

		[ToMany(typeof(OrderDetail), "Product")]
		public abstract IList OrderDetails {get;}

		[Adder("OrderDetails", "Product")]
		public abstract void addOrderDetail(OrderDetail od);

		#endregion

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			return output.ToString();
		}
	}
}
