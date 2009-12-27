﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
// 
namespace testproxy.localhost {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ShopInterface", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
//    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Role[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Address[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(OrderDetail[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(VersionId[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Order[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UpdateOrder[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(IdentResult[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(System.Byte[][]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UpdateOrderResult[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UpdatePerson[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Person[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(UpdatePersonResult[]))]
    public class ShopInterface : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public ShopInterface() {
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetPerson", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("PersonInfo", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public Person GetPerson([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] int PersonId) {
            object[] results = this.Invoke("GetPerson", new object[] {
                        PersonId});
            return ((Person)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetPerson(int PersonId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetPerson", new object[] {
                        PersonId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Person EndGetPerson(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Person)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetPersonByName", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Persons", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Person[] GetPersonByName([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] string PersonName) {
            object[] results = this.Invoke("GetPersonByName", new object[] {
                        PersonName});
            return ((Person[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetPersonByName(string PersonName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetPersonByName", new object[] {
                        PersonName}, callback, asyncState);
        }
        
        /// <remarks/>
        public Person[] EndGetPersonByName(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Person[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetPersons", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Persons", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Person[] GetPersons() {
            object[] results = this.Invoke("GetPersons", new object[0]);
            return ((Person[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetPersons(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetPersons", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public Person[] EndGetPersons(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Person[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetProduct", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("Product", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public Product GetProduct([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] int ProductId) {
            object[] results = this.Invoke("GetProduct", new object[] {
                        ProductId});
            return ((Product)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetProduct(int ProductId, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetProduct", new object[] {
                        ProductId}, callback, asyncState);
        }
        
        /// <remarks/>
        public Product EndGetProduct(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Product)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetProductsByCategory", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Products", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Product[] GetProductsByCategory([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] string Category) {
            object[] results = this.Invoke("GetProductsByCategory", new object[] {
                        Category});
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetProductsByCategory(string Category, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetProductsByCategory", new object[] {
                        Category}, callback, asyncState);
        }
        
        /// <remarks/>
        public Product[] EndGetProductsByCategory(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetProducts", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Products", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Product[] GetProducts() {
            object[] results = this.Invoke("GetProducts", new object[0]);
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetProducts(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetProducts", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public Product[] EndGetProducts(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Product[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetOrderedBetween", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetOrderedBetween([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRange DateRange) {
            object[] results = this.Invoke("GetOrderedBetween", new object[] {
                        DateRange});
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetOrderedBetween(DateRange DateRange, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetOrderedBetween", new object[] {
                        DateRange}, callback, asyncState);
        }
        
        /// <remarks/>
        public Order[] EndGetOrderedBetween(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetShippedBetween", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetShippedBetween([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRange DateRange) {
            object[] results = this.Invoke("GetShippedBetween", new object[] {
                        DateRange});
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetShippedBetween(DateRange DateRange, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetShippedBetween", new object[] {
                        DateRange}, callback, asyncState);
        }
        
        /// <remarks/>
        public Order[] EndGetShippedBetween(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetOrderedBetweenBy", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetOrderedBetweenBy([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRangeBy DateRangeBy) {
            object[] results = this.Invoke("GetOrderedBetweenBy", new object[] {
                        DateRangeBy});
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetOrderedBetweenBy(DateRangeBy DateRangeBy, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetOrderedBetweenBy", new object[] {
                        DateRangeBy}, callback, asyncState);
        }
        
        /// <remarks/>
        public Order[] EndGetOrderedBetweenBy(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("GetShippedBetweenBy", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlArrayAttribute("Orders", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4", IsNullable=false)]
        public Order[] GetShippedBetweenBy([System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] DateRangeBy DateRangeBy) {
            object[] results = this.Invoke("GetShippedBetweenBy", new object[] {
                        DateRangeBy});
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetShippedBetweenBy(DateRangeBy DateRangeBy, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetShippedBetweenBy", new object[] {
                        DateRangeBy}, callback, asyncState);
        }
        
        /// <remarks/>
        public Order[] EndGetShippedBetweenBy(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Order[])(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("UpdatePerson", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public UpdatePersonResult UpdatePerson([System.Xml.Serialization.XmlElementAttribute("UpdatePerson", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] UpdatePerson UpdatePerson1) {
            object[] results = this.Invoke("UpdatePerson", new object[] {
                        UpdatePerson1});
            return ((UpdatePersonResult)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginUpdatePerson(UpdatePerson UpdatePerson1, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("UpdatePerson", new object[] {
                        UpdatePerson1}, callback, asyncState);
        }
        
        /// <remarks/>
        public UpdatePersonResult EndUpdatePerson(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((UpdatePersonResult)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("ChangePersons", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("ChangePersonResults", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
        public ChangePersonResults ChangePersons([System.Xml.Serialization.XmlElementAttribute("ChangePersons", Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")] ChangePersons ChangePersons1) {
            object[] results = this.Invoke("ChangePersons", new object[] {
                        ChangePersons1});
            return ((ChangePersonResults)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginChangePersons(ChangePersons ChangePersons1, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ChangePersons", new object[] {
                        ChangePersons1}, callback, asyncState);
        }
        
        /// <remarks/>
        public ChangePersonResults EndChangePersons(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((ChangePersonResults)(results[0]));
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class Person {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Password;
        
        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
//        public Role[] Roles;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Address[] Addresses;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
//    public enum Role {
//        
//        /// <remarks/>
//        BrowseUsers,
//        
//        /// <remarks/>
//        BrowseProducts,
//        
//        /// <remarks/>
//        BrowseProductsExt,
//        
//        /// <remarks/>
//        BrowseOrders,
//        
//        /// <remarks/>
//        BrowseOwnOrders,
//        
//        /// <remarks/>
//        MakeOrders,
//        
//        /// <remarks/>
//        ChangeProductData,
//        
//        /// <remarks/>
//        ChangeOrders,
//        
//        /// <remarks/>
//        ChangeUsers,
//    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class Address {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Street;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string City;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Postalcode;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Phone;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Email;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class ChangePersonResults {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public UpdatePersonResult[] UpdatePersonResults;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class UpdatePersonResult {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public IdentResult IdentResult;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UpdateAddressResult", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public IdentResult[] UpdateAddressResults;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public UpdateOrderResult[] UpdateOrderResults;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class IdentResult {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int InputId;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ResultId;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class UpdateOrderResult {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public IdentResult IdentResult;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UpdateOrderDetailResult", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false, NestingLevel=1)]
        public System.Byte[][] UpdateOrderDetailResults;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class ChangePersons {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public UpdatePerson[] UpdatePersons;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DeletePerson", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public VersionId[] DeletePersons;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Person[] InsertPersons;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class UpdatePerson {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UpdatePersonUpdatePersonData UpdatePersonData;
        
        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
//        public Role[] AddRoles;
        
        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
//        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
//        public Role[] RemoveRoles;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Address[] UpdateAddresses;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Address[] AddAddresses;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Address", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public VersionId[] RemoveAddresses;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public Order[] AddOrders;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public UpdateOrder[] UpdateOrders;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("Order", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public VersionId[] RemoveOrders;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class UpdatePersonUpdatePersonData {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Password;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class VersionId {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class Order {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime OrderDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime ShippedDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public OrderDetail[] OrderDetails;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class OrderDetail {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ProductId;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Double UnitPrice;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Quantity;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class UpdateOrder {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public OrderDetail[] AddOrderDetails;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("RemoveOrderDetail", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public VersionId[] RemoveOrderDetails;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public OrderDetail[] UpdateOrderDetails;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public UpdateOrderOrderData OrderData;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class UpdateOrderOrderData {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime OrderDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime ShippedDate;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class DateRangeBy {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int PersonId;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public DateRange DateRange;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class DateRange {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime StartDate;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.DateTime EndDate;
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://dotnet.hsr.ch/HsrOrderApp_S4")]
    public class Product {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Id;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Double QuantityPerUnit;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Double UnitPrice;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Category;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=true)]
        [System.Xml.Serialization.XmlArrayItemAttribute("part", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public System.Byte[] Timestamp;
    }
}
