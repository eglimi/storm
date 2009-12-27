using System;
using System.Collections;
using System.Diagnostics;
using Storm.Lib;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for IdentityMap.
	/// </summary>
	public class IdentityMap
	{
		Hashtable m_typeMaps = new Hashtable();
//        UnitOfWork m_unitOfWork;

        public IdentityMap()
        {
//            m_unitOfWork = unitOfWork;
        }

        public DomainObject getDomainObjectIfLoaded(Type type, Key id)
        {
            Hashtable typeMap = (Hashtable)m_typeMaps[type];
            if(typeMap == null)
            {
                return null;
            }
            DomainObject domainObject = (DomainObject)(typeMap[id]);
            if(domainObject != null)
            {
                return domainObject;
            }
            return null;
        }

        public DomainObject getDomainObject(Key id, Type type)
        {
            Hashtable typeMap = (Hashtable)m_typeMaps[type];
            if(typeMap == null)
            {
                typeMap = new Hashtable();
                m_typeMaps[type] = typeMap;
            }
            DomainObject domainObject = (DomainObject)(typeMap[id]);
            if(domainObject != null)
            {
                if(domainObject.State == DomainObject.ObjectState.Deleted)
                {
                    return null;
                }
                return domainObject;
            }
            //IMapper mapper = domainObject.Mapper;
            //domainObject = mapper.Find(id, m_unitOfWork.Connection);
			domainObject = Registry.Instance.getFinder(type).findById(id);
            return domainObject;
        }

        public void registerDomainObject(DomainObject domainObject)
        {
            Type type = domainObject.GetType().BaseType;
            Hashtable typeMap = (Hashtable)m_typeMaps[type];
            if(typeMap == null)
            {
                typeMap = new Hashtable();
                m_typeMaps[type] = typeMap;
            }
            Debug.Assert(typeMap.Contains(domainObject) == false);
            typeMap.Add(domainObject.Id, domainObject);
        }

        public void unregisterDomainObject(DomainObject domainObject)
        {
            Hashtable typeMap = (Hashtable)m_typeMaps[domainObject.GetType().BaseType];
            if(typeMap == null)
                Debug.Assert(false);
            Debug.Assert(typeMap.Contains(domainObject.Id));
            typeMap.Remove(domainObject.Id);
        }
	}
}
