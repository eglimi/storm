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
	[Table("Orders", true),
	VersionField("chTimestamp"),
	GenerateCode]
	public abstract class Order : DomainObject
	{
		#region Factory
		[Factory]
		public abstract class OrderFactory
		{
			public abstract Order createOrder(
				[ParameterDef("Person")] Person person,
				[ParameterDef("OrderDate")] DateTime orderDate,
				[ParameterDef("ShippedDate")] DateTime shippedDate,
				[ParameterDef("OrderState")] String orderState);
		}
		#endregion

		#region Finder
		[Finder]
		public abstract class OrderFinder
		{
			public abstract IList findByOrderDate([ParameterDef("OrderDate")] DateTime orderDate);
			public IList findOrderedBetween(DateTime startDate, DateTime endDate)
			{
				return new ArrayList();
			}
			public IList findShippedBetween(DateTime startDate, DateTime endDate)
			{
				return new ArrayList();
			}
		}
		#endregion

		#region Abstract Properties

		[Column("OrderID"),
		PrimaryKey]
		public abstract int OrderId {get;}

		[Column("PersonID"),
		ToOne(typeof(Person), "PersonId")]
		public abstract Person Person {get; set;}

		[Column("OrderDate")]
		public abstract DateTime OrderDate {get; set;}
		
		[Column("ShippedDate")]
		public abstract DateTime ShippedDate {get; set;}
		
		[Column("OrderState")]
		public abstract string OrderState {get; set;}

		[ToMany(typeof(OrderDetail), "Order")]
		public abstract IList OrderDetails {get;}
		
		[Adder("OrderDetails", "Order")]
		public abstract void addOrderDetail(OrderDetail od);

		#endregion

		#region Ugly Copy/Paste from HsrOrderApp_S4
		public OrderDetail AddOrderDetail(Product product, double unitPrice, int quantity)
		{
			foreach(OrderDetail detail in OrderDetails)
			{
				if(detail.Product == product)
					return null;
			}
			OrderDetail orderDetail = (OrderDetail)
				((OrderDetail.OrderDetailFactory)Registry.Instance.getFactory(typeof(OrderDetail))).createOrderDetail(this, product, unitPrice, quantity);
//				new OrderDetail(this, product, unitPrice, quantity);
			OrderDetails.Add(orderDetail);
			return orderDetail;
		}

		public void RemoveOrderDetail(OrderDetail detail)
		{
			OrderDetails.Remove(detail);
			detail.delete();
		}
		public void CalculateSummary(out double price, out double tax, 
			out double shippingCost, out double total)
		{
			price = 0.0;
			foreach(OrderDetail detail in OrderDetails)
			{
				price += detail.Quantity * detail.UnitPrice;
			}
			tax = CalculateTax(price);
			shippingCost = CalculateShippingCost(price);
			total = price + tax + shippingCost;
		}

		public static double CalculateTax(double price)
		{
			return price * 0.07f;
		}

		public static double CalculateShippingCost(double price)
		{
			if(price > 25.0f)
				return 0.0f;
			else
				return 5.25f;
		}

		public OrderDetail this[int productId]
		{
			get
			{
				return (OrderDetail) UnitOfWork.Instance.IdentityMap.getDomainObject(
					new Key(new object[] {Id[0], productId}), typeof(OrderDetail));
			}
		}

		public OrderDetail this[Product product]
		{
			get
			{
				return this[(int)product.Id[0]];
			}
		}

		public bool IsOrderedBetween(DateTime startDate, DateTime endDate)
		{
			return OrderDate >= startDate && OrderDate < endDate;
		}

		public bool IsShippedBetween(DateTime startDate, DateTime endDate)
		{
			return ShippedDate >= startDate && ShippedDate < endDate;
		}
		#endregion

		public override string ToString()
		{
			StringBuilder output = new StringBuilder();
			output.AppendFormat("Order({0}): {1}, {2}, {3}, {4}",
				GetHashCode(), OrderId, OrderDate.ToShortDateString(), ShippedDate.ToShortDateString(), OrderState);
			return output.ToString();
		}
	}
}
