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
	public class ProductImpl : Product
	{
#region Factory Implementation
		public class FactoryImpl : ProductFactory, IFactory
		{ 
			public override Product createProduct(String productName, Double quantityPerUnit, Double unitPrice, String category)
			{
				return new ProductImpl(productName, quantityPerUnit, unitPrice, category);
			}
			
			public DomainObject create()
			{
				return new ProductImpl();
			}
			
			public DomainObject createFromParameters(
				Key id,
				Timestamp timestamp,
				params DictionaryEntry[] parameters)
			{
				return new ProductImpl(id, timestamp, parameters);
			}
		}
#endregion

#region Finder Implementation
		public class FinderImpl : ProductFinder, IFinder
		{
			public override IList findByName(String name)
			{
				QueryObject qo = new QueryObject();
				qo.addCriteria(new Criteria(Criteria.Operator.Equal, "ProductName", name));

				return Registry.Instance.getMapper(typeof(Product)).find(qo);
			}
			public override IList findByCategory(String category)
			{
				QueryObject qo = new QueryObject();
				qo.addCriteria(new Criteria(Criteria.Operator.Equal, "Category", category));

				return Registry.Instance.getMapper(typeof(Product)).find(qo);
			}
			public DomainObject findById(Key id)
			{
				return Registry.Instance.getMapper(typeof(Product)).findById(id);
			}
			public IList find(QueryObject qo)
			{
				return Registry.Instance.getMapper(typeof(Product)).find(qo);
			}
			public IList findAll()
			{
				return Registry.Instance.getMapper(typeof(Product)).findAll();
			}
		}
#endregion

#region Static Attributes
		private static FactoryImpl m_FactoryImpl = new FactoryImpl();
		private static FinderImpl m_FinderImpl = new FinderImpl();
#endregion
		
#region Member Variables
		private object m_ProductName = null;
		private object m_QuantityPerUnit = null;
		private object m_UnitPrice = null;
		private object m_Category = null;
		private ToManyRelation m_OrderDetails = null;
#endregion

#region Constructors
		public ProductImpl()
		{
		}
		
		public ProductImpl(String productName, Double quantityPerUnit, Double unitPrice, String category)
		{
			markNew();
			m_OrderDetails = new ToManyRelation(typeof(OrderDetail), "ProductID", null, true);
			m_UnitPrice = unitPrice;
			m_Category = category;
			m_ProductName = productName;
			m_QuantityPerUnit = quantityPerUnit;
		}

		internal ProductImpl(
			Key id, 
			Timestamp timestamp, 
			params DictionaryEntry[] parameters)
		{ 
			markClean();
			m_id = id;
			m_timestamp = timestamp;
			FieldInfo fInfo;
			Type thisType = this.GetType();
			Type domainObjectType = typeof(Product);
			
			IEnumerator enumerator = parameters.GetEnumerator();

			while(enumerator.MoveNext())
			{
				if(((DictionaryEntry)enumerator.Current).Value != null)
				{
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToOneRelation))
					{ 
					} 
					if(((DictionaryEntry)enumerator.Current).Value.GetType() == typeof(ToManyRelation))
					{ 
						if((String)((DictionaryEntry)enumerator.Current).Key == "OrderDetails")
						{ 
							m_OrderDetails = (ToManyRelation)((DictionaryEntry)enumerator.Current).Value;
							continue;
						}
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
		public override void addOrderDetail(OrderDetail od)
		{
			if(od != null)
			{
				od.Product = this;
				m_OrderDetails.Add(od);
			}
			else
			{
				throw new ApplicationException();
			}
		}
		
		public override void delete()
		{
			foreach(OrderDetail orderdetail in OrderDetails)
			{
				orderdetail.delete();
			}
			
			this.markRemoved();
		}
#endregion

#region Properties
		public override Int32 ProductId 
		{
			get
			{
				if(m_id == null)
					return 0;			
				return (Int32)m_id[0];
			}
		}
		public override String ProductName 
		{
			get
			{
				if(m_ProductName == null)
					return String.Empty;			
				return (String)m_ProductName;
			}
			set
			{
				m_ProductName = value;
				markDirty();
			}
		}
		public override Double QuantityPerUnit 
		{
			get
			{
				if(m_QuantityPerUnit == null)
					return 0.0;			
				return (Double)m_QuantityPerUnit;
			}
			set
			{
				m_QuantityPerUnit = value;
				markDirty();
			}
		}
		public override Double UnitPrice 
		{
			get
			{
				if(m_UnitPrice == null)
					return 0.0;			
				return (Double)m_UnitPrice;
			}
			set
			{
				m_UnitPrice = value;
				markDirty();
			}
		}
		public override String Category 
		{
			get
			{
				if(m_Category == null)
					return String.Empty;			
				return (String)m_Category;
			}
			set
			{
				m_Category = value;
				markDirty();
			}
		}
		public override IList OrderDetails 
		{
			get
			{
				return (IList)m_OrderDetails;
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
				case "ProductName":
					if(m_ProductName == null) return true;
					break;
				case "QuantityPerUnit":
					if(m_QuantityPerUnit == null) return true;
					break;
				case "UnitPrice":
					if(m_UnitPrice == null) return true;
					break;
				case "Category":
					if(m_Category == null) return true;
					break;
				default:
					break;
			}
			return false;
		}
#endregion
	}

}
