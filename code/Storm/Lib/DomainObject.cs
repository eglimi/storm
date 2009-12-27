using System;
using System.Collections;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for DomainObject.
	/// </summary>
	public abstract class DomainObject
	{
		public enum ObjectState { Unchanged, Modified, Added, Deleted, Detached }

		public delegate void IdChangedHandler(DomainObject subject);
		public event IdChangedHandler OnIdChanged;

		#region Attributes

		protected Key m_id = null;
		private ObjectState m_state = ObjectState.Detached;
		protected Timestamp m_timestamp = null;

		#endregion

//		public DomainObject(Key id, Timestamp timestamp)
//		{
//			m_id = id;
//			m_timestamp = timestamp;
//		}

		#region Properties

		public Key Id        
		{
			get { return m_id; }
			set { m_id = value; }
		}

		public Timestamp Timestamp   
		{
			get { return m_timestamp; }
			set { m_timestamp = value; }
		}

		internal ObjectState State     
		{
			get { return m_state; }
			set { m_state = value; }
		}

		public virtual bool isNull(string propertyName)
		{
			throw new NotSupportedException();
		}

		#endregion

		public virtual void delete()
		{
			throw new NotSupportedException();
		}

		#region UnitOfWork Methodes

		protected void markNew()     
		{
			UnitOfWork.Instance.registerNew(this);
		}

		protected void markClean()   
		{
			UnitOfWork.Instance.registerClean(this);
		}

		protected void markDirty()   
		{
			UnitOfWork.Instance.registerDirty(this);
		}

		protected void markRemoved() 
		{
			UnitOfWork.Instance.registerDeleted(this);
		}


		#endregion

		public void FireIdChanged()
		{
			if(OnIdChanged != null)
				OnIdChanged(this);
		}
	}
}
