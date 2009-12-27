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
	/// Summary description for PersonService.
	/// </summary>
	public class PersonService
	{
		public PersonService()
		{
		}

        static internal DomainModel.Person LoadPerson(int personId)
        {
            return (DomainModel.Person)UnitOfWork.Instance.IdentityMap.getDomainObject(
				new Key(new object[] {personId}), typeof(DomainModel.Person));
        }

//        internal static DomainModel.IPersonFinder GetPersonFinder()
//        {
//            return (DomainModel.IPersonFinder)
//                UnitOfWork.Instance.MapperRegistry.GetFinder(
//                typeof(DomainModel.IPersonFinder));
//        }
		internal static Person.PersonFinder GetPersonFinder()
		{
			return (Person.PersonFinder)Registry.Instance.getFinder(typeof(Person));
		}

//        private DomainModel.Person.PersonRole TransformRole(DTO.Role role)
//        {
//            return (DomainModel.Person.PersonRole)Enum.Parse(
//                    typeof(DomainModel.Person.PersonRole), role.ToString(), true);
//        }

        public void AddPerson(DTO.Person dto, BindingInfo personBinding,
            BindingInfo[] addressBindings)
        {
//            DomainModel.Person person = new DomainModel.Person(dto.Name, dto.Password);
			DomainModel.Person person = ((Person.PersonFactory)Registry.Instance.getFactory(typeof(Person)))
				.createPerson(dto.Name, dto.Password);
//            if(dto.Roles != null)
//            {
//                foreach(DTO.Role role in dto.Roles)
//                {
//                    person.AddRole(TransformRole(role));
//                }
//            }
            new TimestampIdBinding(person, personBinding);
            if(dto.Addresses != null)
            {
                for(int i = 0; i < dto.Addresses.Length; i++)
                {
                    DTO.Address dtoAddress = dto.Addresses[i];

					Address address = ((Address.AddressFactory)Registry.Instance.getFactory(typeof(Address)))
						.createAddress(person, dtoAddress.City, dtoAddress.Street, dtoAddress.Postalcode, 
							dtoAddress.Phone, dtoAddress.Email);
					person.addAddress(address);
//                    DomainModel.Address address =
//                        person.AddAddress(dtoAddress.Street, 
//                            dtoAddress.City, dtoAddress.Postalcode, 
//                            dtoAddress.Email, dtoAddress.Phone);

                    new TimestampIdBinding(address, addressBindings[i]);
                }
            }
        }

        public void RemovePerson(int personId, byte[] timestamp)
        {
            DomainModel.Person person = LoadPerson(personId);
            if(person != null)
            {
                if(person.Timestamp.Equals(new Timestamp(timestamp)) == false)
                    throw new ApplicationException("ConcurrencyException");
                person.delete();
            }
        }

        public DTO.Person GetPerson(int personId)
        {
            DomainModel.Person person = LoadPerson(personId);
            if(person == null)
                return null;
            return DTO.DTOAssembler.AssemblePerson(person);
        }

        private DTO.Person[] MakeOrderDTOArray(IList persons)
        {
            if(persons == null)
                return null;
            DTO.Person[] dtos = new DTO.Person[persons.Count];
            IEnumerator personsEnum = persons.GetEnumerator();
            for(int i = 0; i < persons.Count; i++)
            {
                personsEnum.MoveNext();
                dtos[i] = 
                    DTO.DTOAssembler.AssemblePerson((DomainModel.Person)personsEnum.Current);
            }
            return dtos;
        }

        public DTO.Person[] GetPersonsByName(string name)
        {
            IList persons = GetPersonFinder().findByName(name);
            return MakeOrderDTOArray(persons);
        }

        public DTO.Person[] GetPersons()
        {
            IList persons = Registry.Instance.getFinder(typeof(Person)).findAll();
            return MakeOrderDTOArray(persons);
        }

//        public void AddRole(int personId, DTO.Role role, BindingInfo bindingInfo)
//        {
//            DomainModel.Person person = LoadPerson(personId);
//            person.AddRole(TransformRole(role));
//            new TimestampIdBinding(person, bindingInfo);
//        }
//
//        public void RemoveRole(int personId, DTO.Role role, BindingInfo bindingInfo)
//        {
//            DomainModel.Person person = LoadPerson(personId);
//            person.RemoveRole(TransformRole(role));
//            new TimestampIdBinding(person, bindingInfo);
//        }

        public void AddAddress(int personId, DTO.Address dto, BindingInfo bindingInfo)
        {
            DomainModel.Person person = LoadPerson(personId);
			Address address = ((Address.AddressFactory)Registry.Instance.getFactory(typeof(Address)))
				.createAddress(person, dto.City, dto.Street, dto.Postalcode, dto.Phone, dto.Email);
			person.addAddress(address);
//            DomainModel.Address address = person.AddAddress(
//                dto.Street, dto.City, dto.Postalcode, dto.Email, dto.Phone);

            new TimestampIdBinding(address, bindingInfo);
        }

        public void RemoveAddress(int personId, int addressId, byte[] timestamp)
        {
            DomainModel.Person person = LoadPerson(personId);
            if(person != null)
            {
                DomainModel.Address address = person.findAddress(addressId);
                if(address != null)
                {
                    if(address.Timestamp.Equals(new Timestamp(timestamp)) == false)
                        throw new ApplicationException("ConcurrencyException");
                    person.removeAddress(address);
                }
            }
        }

        public void UpdateAddress(int personId, DTO.Address dto, BindingInfo bindingInfo)
        {
            DomainModel.Person person = LoadPerson(personId);
            if(person == null)
                return;
            DomainModel.Address address = person.findAddress(dto.Id);
            if(address == null)
                return;
            if(address.Timestamp.Equals(new Timestamp(dto.Timestamp)) == false)
                throw new ApplicationException("ConcurrencyException");
            address.Street = dto.Street;
            address.Phone = dto.Phone;
            address.PostalCode = dto.Postalcode;
            address.Email = dto.Email;
            address.City = dto.City;
            new TimestampIdBinding(address, bindingInfo);
        }

        public void UpdatePersonData(int personId, string name, string password, 
            byte[] timestamp, BindingInfo bindingInfo)
        {
            DomainModel.Person person = LoadPerson(personId);
            if(person == null)
                return;
            if(person.Timestamp.Equals(new Timestamp(timestamp)) == false)
            {
                throw new ApplicationException("ConcurrencyException");
            }
            person.Name = name;
            person.Password = password;
            new TimestampIdBinding(person, bindingInfo);
        }
	}
}