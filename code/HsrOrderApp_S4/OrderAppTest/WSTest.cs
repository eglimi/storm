using System;
using System.Collections;
using System.Diagnostics;

//using OrderAppTest.localhost;
using HsrOrderApp.WebServiceInterface;
using HsrOrderApp.BusinessLayer.DTO;

namespace OrderAppTest
{
	/// <summary>
	/// Summary description for WSTest.
	/// </summary>
	public class WSTest
	{
        ShopService m_service = new ShopService();
		
        public WSTest()
		{
//            m_service.Url = "http://localhost/HsrOrderApp_S4/ShopService.asmx";
		}

        public Person InitPerson(int id, string name, string password)
        {
            Person p = new Person();
            p.Id = id;
            p.Name = name;
            p.Password = password;
            return p;
        }

        public Address InitAddress(int id, string email, string city, string phone, string postalcode, string street)
        {
            Address address = new Address();
            address.Id = id;
            address.Email = email;
            address.City = city;
            address.Phone = phone;
            address.Postalcode = postalcode;
            address.Street = street;            
            return address;
        }

        public Address[] InitAddresses(params Address[] addresses)
        {
            return addresses;
        }

        public Role[] AddRoles(params Role[] roles)
        {
            return roles;
        }

        public void RunPersonTests()
        {
            foreach(string pers in new string[] {"TestYOneQ", "TestYTwoQ", "TestYThreeQ"})
            {
                Person[] persons =  m_service.GetPersonByName(pers);
                if(persons != null && persons.Length > 0)
                {
                    foreach(Person person in persons)
                    {
                        ChangePersons cPdel = new ChangePersons();
                        cPdel.DeletePersons = new VersionId[] { new VersionId() };
                        cPdel.DeletePersons[0].Id = person.Id;
                        cPdel.DeletePersons[0].Timestamp = person.Timestamp;
                        m_service.ChangePersons(cPdel);
                    }
                }
            }

            ChangePersons changePersons = new ChangePersons();
            changePersons.InsertPersons = new Person[3];
            changePersons.InsertPersons[0] = InitPerson(-1, "TestYOne", "Pwd1");
            changePersons.InsertPersons[0].Addresses = InitAddresses(
                InitAddress(-1, "T1_1@test.com", "T1City1", "T1Phone1", "T1PC1", "T1Street1"),
                InitAddress(-2, "T1_2@test.com", "T1City2", "T1Phone2", "T1PCde2", "T1Street2"));
//            changePersons.InsertPersons[0].Roles = AddRoles(Role.BrowseOrders, Role.BrowseOwnOrders);
            changePersons.InsertPersons[1] = InitPerson(-2, "TestYTwo", "Pwd2");
            changePersons.InsertPersons[1].Addresses = InitAddresses(
                InitAddress(-1, "T2_1@test.com", "T2City1", "T2Phone1", "T2PC1", "T2Street1"),
                InitAddress(-2, "T2_2@test.com", "T2City2", "T2Phone2", "T2PC2", "T2Street2"));
//            changePersons.InsertPersons[1].Roles = AddRoles(Role.BrowseOrders, Role.BrowseOwnOrders);
            changePersons.InsertPersons[2] = InitPerson(-3, "TestYThree", "Pwd3");
            changePersons.InsertPersons[2].Addresses = InitAddresses(
                InitAddress(-1, "T3_1@test.com", "T3City1", "T3Phone1", "T3PC1", "T3Street1"),
                InitAddress(-2, "T3_2@test.com", "T3City2", "T3Phone2", "T3PC2", "T3Street2"));
//            changePersons.InsertPersons[2].Roles = AddRoles(Role.BrowseOrders, Role.BrowseOwnOrders);
            ChangePersonResults result = m_service.ChangePersons(changePersons);
            
            int i = 0;
            ChangePersons chPersVer = new ChangePersons();
            chPersVer.UpdatePersons = new UpdatePerson[3];
            foreach(UpdatePersonResult persResult in result.UpdatePersonResults)
            {
                Debug.Assert(persResult.IdentResult.InputId == changePersons.InsertPersons[i].Id); 
               
                chPersVer.UpdatePersons[i] = new UpdatePerson();
                chPersVer.UpdatePersons[i].Id = persResult.IdentResult.ResultId;
                chPersVer.UpdatePersons[i].Timestamp = persResult.IdentResult.Timestamp;
//                chPersVer.UpdatePersons[i].RemoveRoles = AddRoles(Role.BrowseOrders);
//                chPersVer.UpdatePersons[i].AddRoles = AddRoles(Role.MakeOrders);
                chPersVer.UpdatePersons[i].UpdateAddresses = new Address[2];
                chPersVer.UpdatePersons[i].UpdatePersonData = new UpdatePersonUpdatePersonData();
                chPersVer.UpdatePersons[i].UpdatePersonData.Name = changePersons.InsertPersons[i].Name + "Q";
                chPersVer.UpdatePersons[i].UpdatePersonData.Password = changePersons.InsertPersons[i].Password + "Q";

                int ii = 0;
                foreach(IdentResult addrResult in persResult.UpdateAddressResults)
                {
                    Debug.Assert(addrResult.InputId == changePersons.InsertPersons[i].Addresses[ii].Id);
                    Address oldAdr = changePersons.InsertPersons[i].Addresses[ii];
                    chPersVer.UpdatePersons[i].UpdateAddresses[ii] = InitAddress(
                        addrResult.ResultId, oldAdr.Email + "d", oldAdr.City + "d", oldAdr.Phone + "d", oldAdr.Postalcode + "d", oldAdr.Street + "d");
                    chPersVer.UpdatePersons[i].UpdateAddresses[ii].Timestamp = addrResult.Timestamp;
                    ii++;
                }

                chPersVer.UpdatePersons[i].AddAddresses = InitAddresses(
                    InitAddress(-1, "new", "new", "new", "new", "new"));

                i++;
            }
            m_service.ChangePersons(chPersVer);
        }

        private Product InitProduct(int id, string name, double quantityPerUnit, double price, string category,
            byte[] timestamp)
        {
            Product p = new Product();
            p.Id = id;
            p.Name = name;
            p.QuantityPerUnit = quantityPerUnit;
            p.UnitPrice = price;
            p.Category = category;
            p.Timestamp = timestamp;
            return p;
        }

        public Product[] InitProducts(params Product[] products)
        {
            return products;
        }
        
        public void RunProductTests()
        {
            int i = 0;
            ArrayList delProducts = new ArrayList();
            foreach(string category in new string[]{"CatA", "CatB", "CatC", "DeleteCat"})
            {
                Product[] products = m_service.GetProductsByCategory(category);
                if(products != null)
                    delProducts.AddRange(products);
            }
            ChangeProducts deletes = new ChangeProducts();
            deletes.DeleteProducts = new VersionId[delProducts.Count];
            foreach(Product p in delProducts)
            {
                VersionId versionId = new VersionId();
                versionId.Id = p.Id;
                versionId.Timestamp = p.Timestamp;
                deletes.DeleteProducts[i++] = versionId;
            }
            m_service.ChangeProducts(deletes);
            

            ChangeProducts changeProducts = new ChangeProducts();
            i = -1;
            changeProducts.InsertProducts = InitProducts(
                InitProduct(i--, "ProdA_A", 10, 10.0, "CatA", null),
                InitProduct(i--, "ProdB_A", 10, 10.0, "CatA", null),
                InitProduct(i--, "ProdC_A", 10, 10.0, "CatA", null),
                InitProduct(i--, "ProdD_A", 10, 10.0, "CatA", null),
                InitProduct(i--, "ProdA_B", 10, 10.0, "CatB", null),
                InitProduct(i--, "ProdB_B", 10, 10.0, "CatB", null),
                InitProduct(i--, "ProdC_B", 10, 10.0, "CatB", null),
                InitProduct(i--, "ProdD_B", 10, 10.0, "CatB", null),
                InitProduct(i--, "ProdA_C", 10, 10.0, "CatC", null),
                InitProduct(i--, "ProdB_C", 10, 10.0, "CatC", null),
                InitProduct(i--, "ProdC_C", 10, 10.0, "CatC", null),
                InitProduct(i--, "ProdD_C", 10, 10.0, "CatC", null),
                InitProduct(i--, "ToDelete1", 10, 10.0, "DeleteCat", null),
                InitProduct(i--, "ToDelete2", 10, 10.0, "DeleteCat", null),
                InitProduct(i--, "ToDelete3", 10, 10.0, "DeleteCat", null),
                InitProduct(i--, "ToDelete4", 10, 10.0, "DeleteCat", null));
            IdentResult[] results = m_service.ChangeProducts(changeProducts);

            ChangeProducts changeTwo = new ChangeProducts();
            changeTwo.DeleteProducts = new VersionId[4];
            changeTwo.UpdateProducts = new Product[12];
            i = 0;
            foreach(IdentResult result in results)
            {
                Product p = changeProducts.InsertProducts[i];
                Debug.Assert(p.Id == result.InputId);

                if(p.Category.Equals("DeleteCat"))
                {
                    VersionId versionId = new VersionId();
                    versionId.Id = result.ResultId;
                    versionId.Timestamp = result.Timestamp;
                    changeTwo.DeleteProducts[i++ - 12] = versionId;
                }
                else
                {
                    changeTwo.UpdateProducts[i++] = 
                        InitProduct(result.ResultId, p.Name + "_d", p.QuantityPerUnit * 3, p.UnitPrice * 2, p.Category + "_d", result.Timestamp);
                }
            }
            m_service.ChangeProducts(changeTwo);
        }

        protected Order InitOrder(int id, DateTime orderDate, byte[] timestamp, params OrderDetail[] details)
        {
            Order order = new Order();
            order.Id = id;
            order.OrderDate = orderDate;
            order.Timestamp = timestamp;
            order.OrderDetails = details;
            return order;
        }

        protected OrderDetail InitOrderDetail(int productId, int quantity, double unitPrice, byte[] timestamp)
        {
            OrderDetail detail = new OrderDetail();
            detail.ProductId = productId;
            detail.Quantity = quantity;
            detail.Timestamp = timestamp;
            detail.UnitPrice = unitPrice;
            return detail;
        }

        protected VersionId InitVersionId(int id, byte[] timestamp)
        {
            VersionId vid = new VersionId();
            vid.Id = id;
            vid.Timestamp = timestamp;
            return vid;
        }

        public void RunOrderTests()
        {
            Person[] persons = m_service.GetPersonByName("TestYOneQ");
            Product[] catA = m_service.GetProductsByCategory("CatA");
            Product[] catB = m_service.GetProductsByCategory("CatB");
            Product[] catC = m_service.GetProductsByCategory("CatC");


            UpdatePerson updatePerson = new UpdatePerson();
            updatePerson.Id = persons[0].Id;
            updatePerson.Timestamp = persons[0].Timestamp;
            updatePerson.AddOrders = new Order[3];
            updatePerson.AddOrders[0] = InitOrder(-1, DateTime.Now, null,  
                InitOrderDetail(catA[0].Id, 1, catA[0].UnitPrice, null),
                InitOrderDetail(catA[1].Id, 2, catA[1].UnitPrice, null),
//                InitOrderDetail(catA[2].Id, 3, catA[2].UnitPrice, null),
                InitOrderDetail(catA[3].Id, 4, catA[3].UnitPrice, null));
            updatePerson.AddOrders[1] = InitOrder(-2, DateTime.Now, null,  
                InitOrderDetail(catB[0].Id, 1, catB[0].UnitPrice, null),
                InitOrderDetail(catB[1].Id, 2, catB[1].UnitPrice, null),
//                InitOrderDetail(catB[2].Id, 3, catB[2].UnitPrice, null),
                InitOrderDetail(catB[3].Id, 4, catB[3].UnitPrice, null));
            updatePerson.AddOrders[2] = InitOrder(-3, DateTime.Now, null,  
                InitOrderDetail(catC[0].Id, 1, catC[0].UnitPrice, null),
                InitOrderDetail(catC[1].Id, 2, catC[1].UnitPrice, null),
//                InitOrderDetail(catC[2].Id, 3, catC[2].UnitPrice, null),
                InitOrderDetail(catC[3].Id, 4, catC[3].UnitPrice, null));
            UpdatePersonResult result = m_service.UpdatePerson(updatePerson);
            UpdatePerson uP2 = new UpdatePerson();
            uP2.Id = persons[0].Id;
            uP2.Timestamp = persons[0].Timestamp;
            uP2.UpdateOrders = new UpdateOrder[3];

            for(int i = 0; i < 3; i++)
            {
                Product[] cat = null;
                switch(i)
                {
                    case 0:
                        cat = catA;
                        break;
                    case 1:
                        cat = catB;
                        break;
                    case 2:
                        cat = catC;
                        break;
                }
                UpdateOrderResult oresult = result.UpdateOrderResults[i];
                byte[][] uod = oresult.UpdateOrderDetailResults;
                Debug.Assert(oresult.IdentResult.InputId == updatePerson.AddOrders[i].Id);
                UpdateOrder updateOrder = new UpdateOrder();
                updateOrder.Id = oresult.IdentResult.ResultId;
                updateOrder.Timestamp = oresult.IdentResult.Timestamp;
                updateOrder.UpdateOrderDetails = new OrderDetail[2];
                updateOrder.UpdateOrderDetails[0] = InitOrderDetail(
                    updatePerson.AddOrders[i].OrderDetails[0].ProductId,
                    updatePerson.AddOrders[i].OrderDetails[0].Quantity * 2,
                    updatePerson.AddOrders[i].OrderDetails[0].UnitPrice * 3,
                    uod[0]);
                updateOrder.UpdateOrderDetails[1] = InitOrderDetail(
                    updatePerson.AddOrders[i].OrderDetails[1].ProductId,
                    updatePerson.AddOrders[i].OrderDetails[1].Quantity * 2,
                    updatePerson.AddOrders[i].OrderDetails[1].UnitPrice * 3,
                    uod[1]);
                updateOrder.AddOrderDetails = new OrderDetail[1];
                updateOrder.AddOrderDetails[0] = InitOrderDetail(cat[2].Id, 3, cat[2].UnitPrice, null);
                updateOrder.RemoveOrderDetails = new VersionId[1];
                updateOrder.RemoveOrderDetails[0] = InitVersionId(cat[3].Id, uod[2]);
                uP2.UpdateOrders[i] = updateOrder;
            }
            m_service.UpdatePerson(uP2);
        }

        public TimeSpan RunTest(int count)
        {
//            double average = 0;
//            for(int i = 0; i < 100; i++)
//            {
//                DateTime startTime = DateTime.Now;
//                RunPersonTests();
//                RunProductTests();
//                RunOrderTests();
//                TimeSpan time = (DateTime.Now - startTime);
//                if(i == 0)
//                    average = time.Milliseconds;
//                else 
//                    average = (i * average + time.Milliseconds) / (i + 1);
//            }
//            return average;
			DateTime startTime = DateTime.Now;
			for(int i = 0; i < count; i++)
			{
				RunPersonTests();
				RunProductTests();
				RunOrderTests();
			}
			TimeSpan time = (DateTime.Now - startTime);
			return time;
        }
	}
}
