using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Web;
using System.Web.Services.Description;
using System.Web.Services;
using System.Web.Services.Protocols;

using HsrOrderApp.BusinessLayer.DTO;
using HsrOrderApp.BusinessLayer.Facade;

using Storm.Lib;

namespace HsrOrderApp.WebServiceInterface
{
	/// <summary>
	/// Summary description for ShopService.
	/// </summary>
    [WebService(Namespace = "http://dotnet.hsr.ch/HsrOrderApp_S4")]
    [WebServiceBinding(Name="ShopInterface", 
         Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4",
         Location="http://localhost/HsrOrderApp_S4/ShopInterface.wsdl")]
    [XmlInclude(typeof(Role[]))]
    [XmlInclude(typeof(Address[]))]
    [XmlInclude(typeof(VersionId[]))]
    [XmlInclude(typeof(OrderDetail[]))]
    [XmlInclude(typeof(Order[]))]
    [XmlInclude(typeof(UpdateOrder[]))]
    [XmlInclude(typeof(IdentResult[]))]
    [XmlInclude(typeof(System.Byte[][]))]
    [XmlInclude(typeof(UpdateOrderResult[]))]
    [XmlInclude(typeof(UpdatePerson[]))]
    [XmlInclude(typeof(Person[]))]
    [XmlInclude(typeof(UpdatePersonResult[]))]
    public class ShopService : WebService
	{
		public ShopService()
		{
			InitializeComponent();
			Registry.Instance.init(this, "localhost", "OrderApplication");
		}

    	#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

        }

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

        private int CalculateTotalLength(params object[][] arrays)
        {
            int length = 0;
            foreach(object[] array in arrays)
            {
                if(array != null)
                    length += array.Length;
            }
            return length;
        }

        private UpdateOrderResult UpdateOrderInt(UpdateOrder updateInfo, 
            OrderService orderService)
        {
            if(updateInfo.OrderData == null && 
                CalculateTotalLength(updateInfo.AddOrderDetails, 
                updateInfo.UpdateOrderDetails, updateInfo.RemoveOrderDetails) == 0)
                return null;

            UpdateOrderResult result = new UpdateOrderResult();
            result.IdentResult = new IdentResult();
            result.IdentResult.InputId = updateInfo.Id;
            result.IdentResult.ResultId = updateInfo.Id;
            
            int updateOrderDetailResultCount = 
                CalculateTotalLength(updateInfo.AddOrderDetails, updateInfo.UpdateOrderDetails);
            int updateOrderDetailResultIndex = 0;
            if(updateOrderDetailResultCount > 0)
            {
                result.UpdateOrderDetailResults = new byte[updateOrderDetailResultCount][];
            }
            
            if(updateInfo.OrderData != null)
            {
                orderService.UpdateOrderData(updateInfo.Id, updateInfo.OrderData.OrderDate,
                    updateInfo.OrderData.ShippedDate, updateInfo.Timestamp, 
                    new BindingInfo(result.IdentResult, "Timestamp")); 
            }
            if(updateInfo.AddOrderDetails != null)
            {
                foreach(OrderDetail detail in updateInfo.AddOrderDetails)
                {
                    orderService.AddOrderDetail(updateInfo.Id, detail, 
                        new BindingInfo(result.UpdateOrderDetailResults, 
                            updateOrderDetailResultIndex++));
                }
            }
            if(updateInfo.UpdateOrderDetails != null)
            {
                foreach(OrderDetail detail in updateInfo.UpdateOrderDetails)
                    orderService.UpdateOrderDetail(updateInfo.Id, detail,
                        new BindingInfo(result.UpdateOrderDetailResults,
                            updateOrderDetailResultIndex++));
            }
            if(updateInfo.RemoveOrderDetails != null)
            {
                foreach(VersionId versionId in updateInfo.RemoveOrderDetails)
                    orderService.RemoveOrderDetail(updateInfo.Id, versionId.Id, 
                        versionId.Timestamp);
            }
            return result;
        }

        private UpdatePersonResult UpdatePersonInt(UpdatePerson updateInfo,
            PersonService personService, OrderService orderService)
        {
            UpdatePersonResult result = new UpdatePersonResult();
            IdentResult identResult = new IdentResult();
            identResult.InputId = updateInfo.Id;
            identResult.ResultId = updateInfo.Id;
            BindingInfo personTBinding = new BindingInfo(identResult, "Timestamp");


            if(updateInfo.UpdatePersonData != null)
            {
                personService.UpdatePersonData(updateInfo.Id,
                    updateInfo.UpdatePersonData.Name,
                    updateInfo.UpdatePersonData.Password,
                    updateInfo.Timestamp, personTBinding);
                result.IdentResult = identResult;
            }
//            if(updateInfo.AddRoles != null)
//            {
//                foreach(Role role in updateInfo.AddRoles)
//                    personService.AddRole(updateInfo.Id, role, personTBinding);
//                result.IdentResult = identResult;
//            }
//            if(updateInfo.RemoveRoles != null)
//            {
//                foreach(Role role in updateInfo.RemoveRoles)
//                    personService.RemoveRole(updateInfo.Id, role, personTBinding);
//                result.IdentResult = identResult;
//            }

            int updateAddressResultCount = 
                CalculateTotalLength(updateInfo.AddAddresses, updateInfo.UpdateAddresses);
            int updateAddressResultIndex = 0;
            result.UpdateAddressResults = new IdentResult[updateAddressResultCount];

            if(updateInfo.AddAddresses != null)
            {
                foreach(Address address in updateInfo.AddAddresses)
                {
                    IdentResult addrResult = new IdentResult();
                    addrResult.InputId = address.Id;
                    personService.AddAddress(updateInfo.Id, address, 
                        new BindingInfo(addrResult, "ResultId", "Timestamp"));
                    result.UpdateAddressResults[updateAddressResultIndex++] = addrResult;
                }
            }
            if(updateInfo.UpdateAddresses != null)
            {
                foreach(Address address in updateInfo.UpdateAddresses)
                {
                    IdentResult addrResult = new IdentResult();
                    addrResult.InputId = address.Id;
                    addrResult.ResultId = address.Id;
                    personService.UpdateAddress(updateInfo.Id, address, 
                        new BindingInfo(addrResult, "Timestamp"));
                    result.UpdateAddressResults[updateAddressResultIndex++] = addrResult;
                }
            }
            if(updateInfo.RemoveAddresses != null)
            {
                foreach(VersionId addressVers in updateInfo.RemoveAddresses)
                    personService.RemoveAddress(updateInfo.Id, addressVers.Id,
                        addressVers.Timestamp);
            }
            int updateOrderResultCount = CalculateTotalLength(updateInfo.AddOrders, 
                updateInfo.UpdateOrders);
            int updateOrderResultIndex = 0;
            result.UpdateOrderResults = new UpdateOrderResult[updateOrderResultCount];
            if(updateInfo.AddOrders != null)
            {
                foreach(Order order in updateInfo.AddOrders)
                {
                    UpdateOrderResult updateOrderResult = new UpdateOrderResult();
                    updateOrderResult.IdentResult = new IdentResult();
                    updateOrderResult.IdentResult.InputId = order.Id;
                    BindingInfo[] detailBindings;
                    if(CalculateTotalLength(order.OrderDetails) != 0)
                    {
                        updateOrderResult.UpdateOrderDetailResults = 
                            new byte[order.OrderDetails.Length][];
                        detailBindings = new BindingInfo[order.OrderDetails.Length];
                        for(int i = 0; i < detailBindings.Length; i++)
                        {
                            detailBindings[i] = 
                                new BindingInfo(updateOrderResult.UpdateOrderDetailResults, i);
                        }
                        orderService.AddOrder(updateInfo.Id, order, 
                            new BindingInfo(updateOrderResult.IdentResult, "ResultId", "Timestamp"),
                            detailBindings);
                    }
                    result.UpdateOrderResults[updateOrderResultIndex++] = updateOrderResult;
                }
            }
            if(updateInfo.UpdateOrders != null)
            {
                foreach(UpdateOrder updateOrder in updateInfo.UpdateOrders)
                {
                    result.UpdateOrderResults[updateOrderResultIndex++] =
                        UpdateOrderInt(updateOrder, orderService);
                }
            }
            if(updateInfo.RemoveOrders != null)
            {
                foreach(VersionId orderVers in updateInfo.RemoveOrders)
                    orderService.RemoveOrder(orderVers.Id, orderVers.Timestamp);    
            }
            return result;
        }

        [WebMethod]
        [SoapDocumentMethod("GetPerson",
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal,
             ParameterStyle = SoapParameterStyle.Bare)]
        [return: XmlElement("PersonInfo", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public Person GetPerson(
            [XmlElement("PersonId", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] int personId)
        {
            PersonService personService = new PersonService();
            return personService.GetPerson(personId);
        }

        [WebMethod]
        [SoapDocumentMethod("GetPersonByName", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArrayAttribute("Persons", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItemAttribute(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Person[] GetPersonByName([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] string personName)
        {
            PersonService personService = new PersonService();
            return personService.GetPersonsByName(personName);
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetPersons", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Persons", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Person[] GetPersons()
        {
            PersonService personService = new PersonService();
            return personService.GetPersons();
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetProduct", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlElement("Product", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public Product GetProduct([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] int productId)
        {
            ProductService productService = new ProductService();
            return productService.GetProduct(productId);
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetProductsByCategory", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Products", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Product[] GetProductsByCategory([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] string category)
        {
            ProductService productService = new ProductService();
            return productService.FindByCategory(category);
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetProducts", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Products", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Product[] GetProducts()
        {
            ProductService productService = new ProductService();
            return productService.FindAll();
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetOrderedBetween", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetOrderedBetween([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRange dateRange)
        {
            OrderService orderService = new OrderService();
            return orderService.FindOrderedBetween(dateRange.StartDate, dateRange.EndDate);
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetShippedBetween", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetShippedBetween([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRange dateRange)
        {
            OrderService orderService = new OrderService();
            return orderService.FindShippedBetween(dateRange.StartDate, dateRange.EndDate);
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetOrderedBetweenBy", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetOrderedBetweenBy([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRangeBy dateRangeBy)
        {
            OrderService orderService = new OrderService();
            return orderService.FindOrderedBetweenBy(
                dateRangeBy.PersonId, dateRangeBy.DateRange.StartDate, dateRangeBy.DateRange.EndDate);
        }
    
        /// <remarks/>
        [WebMethod]
        [SoapDocumentMethod("GetShippedBetweenBy", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem(Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetShippedBetweenBy([XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRangeBy dateRangeBy)
        {
            OrderService orderService = new OrderService();
            return orderService.FindShippedBetweenBy(
                dateRangeBy.PersonId, dateRangeBy.DateRange.StartDate, dateRangeBy.DateRange.EndDate);
        }

        [WebMethod]
        [SoapDocumentMethod("UpdatePerson",
            Binding="ShopInterface",
             Use=SoapBindingUse.Literal,
             ParameterStyle= SoapParameterStyle.Bare)]
        [return: XmlElement(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public UpdatePersonResult UpdatePerson(
            [XmlElement("UpdatePerson", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
            UpdatePerson updatePerson)
        {
            PersonService personService = new PersonService();
            OrderService orderService = new OrderService();
            UpdatePersonResult result = 
                UpdatePersonInt(updatePerson, personService, orderService);
            UnitOfWork.Instance.commit();
            return result;
        }

        [WebMethod]
        [SoapDocumentMethod("ChangePersons",
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal,
             ParameterStyle= SoapParameterStyle.Bare)]
        [return: XmlElement("ChangePersonResults", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public ChangePersonResults ChangePersons(
            [XmlElement("ChangePersons", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
            ChangePersons changesInfo)
        {
            ChangePersonResults result = new ChangePersonResults();
            int personResultCount = 
                CalculateTotalLength(changesInfo.InsertPersons, changesInfo.UpdatePersons);
            if(personResultCount > 0)
                result.UpdatePersonResults = new UpdatePersonResult[personResultCount];
            int personResultIndex = 0;

            PersonService personService = new PersonService();
            OrderService orderService = new OrderService();
            if(changesInfo.InsertPersons != null)
            {
                foreach(Person person in changesInfo.InsertPersons)
                {
                    UpdatePersonResult persResult = new UpdatePersonResult();
                    persResult.IdentResult = new IdentResult();
                    persResult.IdentResult.InputId = person.Id;
                    int addressCount = CalculateTotalLength(person.Addresses);
                    if(addressCount > 0)
                        persResult.UpdateAddressResults = new IdentResult[addressCount];
                    BindingInfo[] addressBindings = new BindingInfo[addressCount];
                    for(int i = 0; i < addressCount; i++)
                    {
                        persResult.UpdateAddressResults[i] = new IdentResult();
                        persResult.UpdateAddressResults[i].InputId = person.Addresses[i].Id;
                        addressBindings[i] = new BindingInfo(persResult.UpdateAddressResults[i],
                            "ResultId", "Timestamp");
                    }
                    personService.AddPerson(person, 
                        new BindingInfo(persResult.IdentResult, "ResultId", "Timestamp"), 
                        addressBindings);
                    result.UpdatePersonResults[personResultIndex++] = persResult;
                }
            }
            if(changesInfo.UpdatePersons != null)
            {
                foreach(UpdatePerson updateInfo in changesInfo.UpdatePersons)
                {
                    result.UpdatePersonResults[personResultIndex++] =
                        UpdatePersonInt(updateInfo, personService, orderService);
                }
            }
            if(changesInfo.DeletePersons != null)
            {
                foreach(VersionId versionId in changesInfo.DeletePersons)
                {
                    personService.RemovePerson(versionId.Id,  versionId.Timestamp);
                }
            }
            UnitOfWork.Instance.commit();
            return result;
        }

        [WebMethod]
        [SoapDocumentMethod("ChangeProducts", 
             Binding="ShopInterface",
             Use=SoapBindingUse.Literal, 
             ParameterStyle=SoapParameterStyle.Bare)]
        [return: XmlArray("ChangeProductResults", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: XmlArrayItem("Results", Form=XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public IdentResult[] ChangeProducts([XmlElement("ChangeProducts", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] ChangeProducts changeProducts)
        {
            int productResultCount = CalculateTotalLength(changeProducts.InsertProducts, changeProducts.UpdateProducts);
            ProductService service = new ProductService();
            IdentResult[] results = null;
            int resultIndex = 0;
            if(productResultCount > 0)
            {
                results = new IdentResult[productResultCount];
            }
            if(CalculateTotalLength(changeProducts.InsertProducts) > 0)
            {
                foreach(Product product in changeProducts.InsertProducts)
                {
                    IdentResult addResult = new IdentResult();
                    addResult.InputId = product.Id;
                    service.AddProduct(product, new BindingInfo(addResult, "ResultId", "Timestamp"));
                    results[resultIndex++] = addResult;
                }
            }
            if(CalculateTotalLength(changeProducts.UpdateProducts) > 0)
            {
                foreach(Product product in changeProducts.UpdateProducts)
                {
                    IdentResult updateResult = new IdentResult();
                    updateResult.InputId = product.Id;
                    updateResult.ResultId = product.Id;
                    service.UpdateProduct(product, new BindingInfo(updateResult, "Timestamp"));
                    results[resultIndex++] = updateResult;
                }
            }
            if(CalculateTotalLength(changeProducts.DeleteProducts) > 0)
            {
                foreach(VersionId versionId in changeProducts.DeleteProducts)
                {
                    service.RemoveProduct(versionId.Id, versionId.Timestamp);
                }
            }
            UnitOfWork.Instance.commit();
            return results;
        }
    }
}
