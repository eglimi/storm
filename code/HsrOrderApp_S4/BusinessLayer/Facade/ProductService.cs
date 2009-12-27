using System;
using System.Collections;

using HsrOrderApp;
using HsrOrderApp.BusinessLayer;
using HsrOrderApp.BusinessLayer.DomainModel;
using HsrOrderApp.BusinessLayer.DataMapper;
using Storm.Lib;

namespace HsrOrderApp.BusinessLayer.Facade
{
	/// <summary>
	/// Summary description for ProductService.
	/// </summary>
	public class ProductService
	{
		public ProductService()
		{
		}

        internal static DomainModel.Product LoadProduct(int productId)
        {
            return (DomainModel.Product)UnitOfWork.Instance.IdentityMap.getDomainObject(
				new Key(new object[] {productId}), typeof(DomainModel.Product));
        }

//        private DomainModel.IProductFinder GetProductFinder()
//        {
//            return (DomainModel.IProductFinder)
//                UnitOfWork.Instance.MapperRegistry.GetFinder(typeof(DomainModel.IProductFinder));
//        }
		internal static Product.ProductFinder GetProductFinder()
		{
			return (Product.ProductFinder)Registry.Instance.getFinder(typeof(Product));
		}

        public DomainModel.Product AddProduct(DTO.Product dto, BindingInfo bindingInfo)
        {
//            DomainModel.Product product = new DomainModel.Product(
//                dto.Name, dto.QuantityPerUnit, dto.UnitPrice, dto.Category);
			Product product = ((Product.ProductFactory)Registry.Instance.getFactory(typeof(Product)))
				.createProduct(dto.Name, dto.QuantityPerUnit, dto.UnitPrice, dto.Category);

			new TimestampIdBinding(product, bindingInfo);
            return product;
        }

        public void RemoveProduct(int productId, byte[] timestamp)
        {
            DomainModel.Product product = LoadProduct(productId);
            if(product != null)
            {
                if(product.Timestamp.Equals(new Timestamp(timestamp)) == false)
                    throw new ApplicationException("ConcurrencyException");
                product.delete();
            }
        }

        public DTO.Product GetProduct(int productId)
        {
            return DTO.DTOAssembler.AssembleProduct(LoadProduct(productId));
        }

        public void UpdateProduct(DTO.Product dto, BindingInfo bindingInfo)
        {
            DomainModel.Product product = LoadProduct(dto.Id);
            if(product != null)
            {
                if(product.Timestamp.Equals(new Timestamp(dto.Timestamp)) == false)
                    throw new ApplicationException("ConcurrencyException");
                product.ProductName = dto.Name;
                product.QuantityPerUnit = dto.QuantityPerUnit;
                product.UnitPrice = dto.UnitPrice;
                new TimestampIdBinding(product, bindingInfo);
            }
        }

        private DTO.Product[] MakeProductArray(IList productList)
        {
            if(productList != null)
            {
                DTO.Product[] products = new DTO.Product[productList.Count];
                IEnumerator prodEnum = productList.GetEnumerator();
                for(int i = 0; i < productList.Count; i++)
                {
                    prodEnum.MoveNext();
                    products[i] = DTO.DTOAssembler.AssembleProduct((DomainModel.Product)prodEnum.Current);
                }
                return products;
            }
            return null;
        }
        
        public DTO.Product[] FindAll()
        {
            IList list = Registry.Instance.getFinder(typeof(Product)).findAll();
            return MakeProductArray(list);
        }

        public DTO.Product[] FindByName(string name)
        {
            IList list = GetProductFinder().findByName(name);
            return MakeProductArray(list);
        }

        public DTO.Product[] FindByCategory(string category)
        {
            IList list = GetProductFinder().findByCategory(category);
            return MakeProductArray(list);
        }
    }
}