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
	[Table("OrderDetails", false),
	VersionField("chTimestamp"),
	GenerateCode]
	public abstract class OrderDetail : DomainObject
	{
		[Factory]
		public abstract class OrderDetailFactory
		{
			public abstract OrderDetail createOrderDetail(
				[ParameterDef("Order")] Order order,
				[ParameterDef("Product")] Product product,
				[ParameterDef("UnitPrice")] double unitPrice,
				[ParameterDef("Quantity")] int quantity);
		}

		[Finder]
		public abstract class OrderDetailsFinder
		{
		}

		#region Abstract Properties

		[Column("OrderID"),
		ToOne(typeof(Order), "OrderId"),
		PrimaryKey]
		public abstract Order Order {get; set;}

		[Column("ProductID"),
		ToOne(typeof(Product), "ProductId"),
		PrimaryKey]
		public abstract Product Product {get; set;}

		[Column("UnitPrice")]
		public abstract double UnitPrice {get; set;}

		[Column("Quantity")]
		public abstract int Quantity {get; set;}
		

		#endregion

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			return output.ToString();
		}
	}
}
