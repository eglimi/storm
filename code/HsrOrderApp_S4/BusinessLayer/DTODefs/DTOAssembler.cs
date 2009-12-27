using System;
using System.Collections;

using HsrOrderApp.BusinessLayer;

namespace HsrOrderApp.BusinessLayer.DTO
{
	/// <summary>
	/// Summary description for AddressAssembler.
	/// </summary>
	public class DTOAssembler
	{
        public static Person AssemblePerson(DomainModel.Person person)
        {
            Person dto = new Person();
            dto.Id = (int)person.Id[0];
            dto.Name = person.Name;
            dto.Password = person.Password;
            dto.Timestamp = person.Timestamp.Value;

            ICollection addresses = person.Addresses;
            if(addresses != null && addresses.Count > 0)
            {
                int addrCount = addresses.Count;
                dto.Addresses = new Address[addrCount];
                IEnumerator addrEnum = addresses.GetEnumerator();
                for(int i = 0; i < addrCount; i++)
                {
                    addrEnum.MoveNext();
                    dto.Addresses[i] = AssembleAddress((DomainModel.Address)addrEnum.Current);
                }
            }
            
//            ICollection roles = person.Roles;
//            if(roles != null && roles.Count > 0)
//            {
//                dto.Roles = new Role[roles.Count];
//                IEnumerator roleEnum = roles.GetEnumerator();
//                for(int i = 0; i < roles.Count; i++)
//                {
//                    roleEnum.MoveNext();
//                    dto.Roles[i] = AssembleRole((DomainModel.Person.PersonRole)roleEnum.Current);
//                }
//            }

            return dto;
        }

        public static Address AssembleAddress(DomainModel.Address address)
        {
            Address dto = new Address();
            dto.Id = (int)(address.Id[0]);
            dto.Street = address.Street;
            dto.City = address.City;
            dto.Email = address.Email;
            dto.Postalcode = address.PostalCode;
            dto.Phone = address.Phone;
            dto.Timestamp = address.Timestamp.Value;
            return dto;
        }

//        public static Role AssembleRole(DomainModel.Person.PersonRole role)
//        {
//            return (Role)Enum.Parse(typeof(Role), role.ToString(), true);
//        }

        public static Order AssembleOrder(DomainModel.Order order)
        {
            Order dto = new Order();
            dto.OrderDate = order.OrderDate;
            dto.ShippedDate = order.ShippedDate;
            dto.Timestamp = order.Timestamp.Value;
            ICollection orderDetails = order.OrderDetails;
            dto.OrderDetails = new OrderDetail[orderDetails.Count];
            IEnumerator detailEnum = orderDetails.GetEnumerator();
            for(int i = 0; i < orderDetails.Count; i++)
            {
                detailEnum.MoveNext();
                dto.OrderDetails[i] = 
                    AssembleOrderDetail((DomainModel.OrderDetail)detailEnum.Current);
            }
            return dto;
        }

        public static OrderDetail AssembleOrderDetail(DomainModel.OrderDetail detail)
        {
            OrderDetail dto = new OrderDetail();
            dto.ProductId = (int)detail.Product.Id[0];
            dto.Quantity = detail.Quantity;
            dto.UnitPrice = detail.UnitPrice;
            dto.Timestamp = detail.Timestamp.Value;
            return dto;
        }

        public static Product AssembleProduct(DomainModel.Product product)
        {
            Product dto = new Product();
            dto.Id = (int)product.Id[0];
            dto.Category = product.Category;
            dto.Name = product.ProductName;
            dto.QuantityPerUnit = product.QuantityPerUnit;
            dto.UnitPrice = product.UnitPrice;
            dto.Timestamp = product.Timestamp.Value;
            return dto;
        }
    }
}
