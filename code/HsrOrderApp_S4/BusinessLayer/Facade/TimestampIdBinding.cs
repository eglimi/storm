using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using Storm.Lib;

namespace HsrOrderApp.BusinessLayer.Facade
{
    public class BindingInfo
    {
        private object m_destination;
        private string m_idAttribute;
        private string m_timestampAttribute;
        private int m_destinationIndex;
        private bool m_isIndexed = false;
        
        public BindingInfo(object destination,
            string idAttribute, string timestampAttribute)
        {
            m_idAttribute = idAttribute;
            m_timestampAttribute = timestampAttribute;
            m_destination = destination;
        }

        public BindingInfo(object destination, int destinationIndex)
        {
            Debug.Assert(destination is IList);
            m_destination = destination;
            m_destinationIndex = destinationIndex;
            m_isIndexed = true;
        }

        public BindingInfo(object destination)
            : this(destination, null, null)
        {
        }

        public BindingInfo(object destination, string timestampAttribute)
            : this(destination, null, timestampAttribute)
        {
        }

        public object Destination
        {
            get { return m_destination; }
        }

        public string IdAttribute
        {
            get { return m_idAttribute; }
        }

        public string TimestampAttribute
        {
            get { return m_timestampAttribute; }
        }

        public bool IsIndexed
        {
            get { return m_isIndexed; }
        }

        public int DestinationIndex
        {
            get { return m_destinationIndex; }
        }
    }
	/// <summary>
	/// Summary description for TimestampIdBinding.
	/// </summary>
	public class TimestampIdBinding
	{
        private BindingInfo m_bindingInfo;

        public TimestampIdBinding(DomainObject source, BindingInfo bindingInfo)
		{
            if(bindingInfo == null || bindingInfo.Destination == null)
                return;
            m_bindingInfo = bindingInfo;
            source.OnIdChanged += new DomainObject.IdChangedHandler(OnIdChanged);
        }

        public void OnIdChanged(DomainObject subject)
        {
            Type destType = m_bindingInfo.Destination.GetType();
            if(m_bindingInfo.IsIndexed == false)
            {
                if(m_bindingInfo.IdAttribute != null)
                {
                    FieldInfo fieldInfo = destType.GetField(m_bindingInfo.IdAttribute);
                    if(fieldInfo != null)
                    {
                        fieldInfo.SetValue(m_bindingInfo.Destination, subject.Id[0]);
                    }
                }
                if(m_bindingInfo.TimestampAttribute != null)
                {
                    FieldInfo fieldInfo = destType.GetField(m_bindingInfo.TimestampAttribute);
                    if(fieldInfo != null)
                    {
                        fieldInfo.SetValue(m_bindingInfo.Destination, subject.Timestamp.Value);
                    }
                }
            }
            else
            {
                ((IList)m_bindingInfo.Destination)[m_bindingInfo.DestinationIndex] = 
                    subject.Timestamp.Value;
            }
        }
	}
}
