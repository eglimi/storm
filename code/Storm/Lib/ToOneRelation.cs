using System;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for ToOneRelation.
	/// </summary>
	public class ToOneRelation
	{
		bool m_isLoaded = false;
		Type m_relation;
		String m_fieldName;
		Key m_targetId;
		DomainObject m_object;

		public ToOneRelation(Type relation, String fieldName, Key targetId)
		{
//			if(m_targetId == null && targetId == null)
//				m_isLoaded = true;
//			else
//			{
//			}
			m_relation = relation;
			m_fieldName = fieldName;
			m_targetId = targetId;
			if(targetId != null)
			{
				foreach(object item in targetId)
				{
					if(item == null)
					{
						m_targetId = null;
						break;
					}
				}
			}
		}

		public Key TargetId
		{
			get 
			{
				if(m_object == null)
					return m_targetId;
				else
					return m_object.Id;
			}
//			set
//			{
//				if(m_object == null) 
//				{
//					if(value != null)
//					{
//						m_targetId = value;
//						m_isLoaded = false;
//					}
//				}
//				else
//					throw new ApplicationException("Only allowed on empty ToOneRelations");
//			}
		}

		public DomainObject Object
		{
			get
			{
				//if(m_targetId == null)
				//	return null;
				if(m_object == null && m_targetId != null)
					LoadChild();
				return m_object;
			}
			set
			{
				m_isLoaded = true;
				m_object = value;
				m_targetId = value.Id;
			}
		}

		private void LoadChild()
		{
			if(m_isLoaded == false)
			{
				m_object =
					UnitOfWork.Instance.IdentityMap.getDomainObjectIfLoaded(m_relation, m_targetId);

				if(m_object == null)
				{
					IMapper mapper = Registry.Instance.getMapper(m_relation);
					m_object = mapper.ResolveToOneRelation(m_targetId, m_fieldName);
				}

				m_isLoaded = true;
			}            
		}
	}
}
