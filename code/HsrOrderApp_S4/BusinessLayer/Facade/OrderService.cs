using System;
using System.Collections;

using HsrOrderApp;
using HsrOrderApp.BusinessLayer;
using HsrOrderApp.BusinessLayer.DomainModel;
using Storm.Lib;

namespace HsrOrderApp.BusinessLayer.Facade
{
	/// <summary>
	/// Summary description for OrderService.
	/// </summary>
	public class OrderService
	{
		public OrderService()
		{
		}

        internal static DomainModel.Order LoadOrder(int orderId)
        {
            return (DomainModel.Order)
                UnitOfWork.Instance.IdentityMap.getDomainObject(
				new Key(new object[] {orderId}), typeof(DomainModel.Order));
        }

//        internal static DomainModel.IOrderFinder GetOrderFinder()
//        {
//            return (DomainModel.IOrderFinder)
//                UnitOfWork.Instance.MapperRegistry.GetFinder(
//                    typeof(DomainModel.IOrderFinder));
//        }

		internal static Order.OrderFinder GetOrderFinder()
		{
			return (Order.OrderFinder)Registry.Instance.getFinder(typeof(Order));
		}

        private DTO.Order[] MakeOrderDTOArray(IList orders)
        {
            if(orders == null)
                return null;
            DTO.Order[] dtos = new DTO.Order[orders.Count];
            IEnumerator ordersEnum = orders.GetEnumerator();
            for(int i = 0; i < orders.Count; i++)
            {
                ordersEnum.MoveNext();
                dtos[i] = 
                    DTO.DTOAssembler.AssembleOrder((DomainModel.Order)ordersEnum.Current);
            }
            return dtos;
        }

        public DTO.Order[] FindOrderedBetween(DateTime startDate, DateTime endDate)
        {
            IList orders = GetOrderFinder().findOrderedBetween(startDate, endDate);
            return MakeOrderDTOArray(orders);
        }

        public DTO.Order[] FindShippedBetween(DateTime startDate, DateTime endDate)
        {
            IList orders = GetOrderFinder().findShippedBetween(startDate, endDate);
            return MakeOrderDTOArray(orders);
        }

        public DTO.Order[] FindOrderedBetweenBy(int personId, DateTime startDate, 
            DateTime endDate)
        {
            DomainModel.Person person = PersonService.LoadPerson(personId);
            if(person == null)
                return null;
            IList orders = person.findOrderedBetween(startDate, endDate);
            return MakeOrderDTOArray(orders);
        }

        public DTO.Order[] FindShippedBetweenBy(int personId, DateTime startDate, 
            DateTime endDate)
        {
            DomainModel.Person person = PersonService.LoadPerson(personId);
            if(person == null)
                return null;
            IList orders = person.findShippedBetween(startDate, endDate);
            return MakeOrderDTOArray(orders);
        }

        public DomainModel.Order AddOrder(int personId, DTO.Order dto, 
            BindingInfo orderBinding, BindingInfo[] orderDetailBindings)
        {
            DomainModel.Person person = PersonService.LoadPerson(personId);
			DomainModel.Order order = ((Order.OrderFactory)Registry.Instance.getFactory(typeof(Order)))
				.createOrder(person, dto.OrderDate, DateTime.MaxValue, "");
			person.addOrder(order);
//            DomainModel.Order order = person.AddOrder(dto.OrderDate);
            new TimestampIdBinding(order, orderBinding);
                       
            for(int i = 0; i < dto.OrderDetails.Length; i++)
            {
                DTO.OrderDetail dtoDetail = dto.OrderDetails[i];
                DomainModel.Product product = 
                    ProductService.LoadProduct(dtoDetail.ProductId);
                if(product != null)
                {
                    DomainModel.OrderDetail orderDetail =
                        order.AddOrderDetail(product, product.UnitPrice, dtoDetail.Quantity);
                    new TimestampIdBinding(orderDetail, orderDetailBindings[i]);
                }
            }
            return order;            
        }

        public void RemoveOrder(int orderId, byte[] timestamp)
        {
            DomainModel.Order order = LoadOrder(orderId);
            if(order != null)
            {
                if(order.Timestamp.Equals(new Timestamp(timestamp)) == false)
                    throw new ApplicationException("ConcurrencyException");
                order.Person.removeOrder(order);
            }
        }

        public void UpdateOrderData(int orderId, DateTime orderDate, 
            DateTime shippedDate, byte[] timestamp, BindingInfo bindingInfo)
        {
            DomainModel.Order order = LoadOrder(orderId);
            if(order != null)
            {
                if(order.Timestamp.Equals(new Timestamp(timestamp)) == false)
                    throw new ApplicationException("ConcurrencyException");
                order.OrderDate = orderDate;
                order.ShippedDate = shippedDate;
                if(bindingInfo != null)
                    new TimestampIdBinding(order, bindingInfo);
            }
        }

        public void AddOrderDetail(int orderId, DTO.OrderDetail dto, 
            BindingInfo bindingInfo)
        {
            DomainModel.Order order = LoadOrder(orderId);
            if(order != null)
            {
                DomainModel.Product product = ProductService.LoadProduct(dto.ProductId);
                DomainModel.OrderDetail detail = 
                    order.AddOrderDetail(product, dto.UnitPrice, dto.Quantity);
                new TimestampIdBinding(detail, bindingInfo);
            }
        }

        public void RemoveOrderDetail(int orderId, int productId, byte[] timestamp)
        {
            DomainModel.Order order = LoadOrder(orderId);
            if(order != null)
            {
                DomainModel.OrderDetail detail = order[productId];
                if(detail != null)
                {
                    if(detail.Timestamp.Equals(new Timestamp(timestamp)) == false)
                        throw new ApplicationException("ConcurrencyException");
                    order.RemoveOrderDetail(detail);
                }
            }
        }

        public void UpdateOrderDetail(int orderId, DTO.OrderDetail dto,
            BindingInfo bindingInfo)
        {
            DomainModel.Order order = LoadOrder(orderId);
            if(order != null)
            {
                DomainModel.OrderDetail detail = order[dto.ProductId];
                if(detail != null)
                {
                    if(detail.Timestamp.Equals(new Timestamp(dto.Timestamp)) == false)
                        throw new ApplicationException("ConcurrencyException");
                    detail.Quantity = dto.Quantity;
                    detail.UnitPrice = dto.UnitPrice;
                    new TimestampIdBinding(detail, bindingInfo);
                }
            }
        }
    }
}