using System;
using System.Collections;
using System.Xml.Schema;
using System.Diagnostics;
using System.ComponentModel;
using CodeSmith.CustomProperties;

namespace XParser
{
	/// <summary>
	/// 
	/// Summary description for XsdHelper.
	/// </summary>
	[TypeConverter(typeof(XmlSerializedTypeConverter))]
	[Editor(typeof(XParser.XHelperEditor),typeof(System.Drawing.Design.UITypeEditor))]
	public class XHelper
	{	
		private Loader m_loader;
		private string m_fileName;
		private string m_className;
		private XAttribute m_currentXAttribute = null;
		private ArrayList m_currentXAttributesOfClass = null;
		private Hashtable m_classesAndAttributes = new Hashtable();
		//private Hashtable m_

		public XHelper()
		{
//			DebugConsole.Instance.Init(true, true);
//			Debug.WriteLine("XsdHelper() Konstruktor");
			m_loader = new Loader();
		}

		
		public Hashtable getAttributes()
		{
			string classType = String.Empty;
			XmlSchemaElement classElement = null;
			
			//search desired class
			IDictionaryEnumerator classEnumerator = m_loader.Classes.GetEnumerator();
			while(classEnumerator.MoveNext())
			{
				if((string)classEnumerator.Key == ClassName || ClassName == String.Empty)
				{
					classElement = (XmlSchemaElement)classEnumerator.Value;
					m_classesAndAttributes.Add(classEnumerator.Key, m_currentXAttributesOfClass);
				}
			}

			//search definition of found class
			classType = classElement.SchemaTypeName.Name;
			IDictionaryEnumerator typeEnumerator = m_loader.TypeCollection.GetEnumerator();
			while(typeEnumerator.MoveNext())
			{
				if((string)typeEnumerator.Key == classType)
					if(typeEnumerator.Value is XmlSchemaComplexType)
						readXmlComplexType((XmlSchemaObject)typeEnumerator.Value);
			}
			return m_classesAndAttributes;
		}

		private void readXmlSequence(XmlSchemaObject item)
		{
			XmlSchemaSequence sequence = item as XmlSchemaSequence;
			
			if(sequence != null)
			{
				foreach(XmlSchemaObject obj in sequence.Items)
				{
					if(obj is XmlSchemaElement)
						readXmlElement(obj);
					//TODO: add all possibilities
				}
			}
		}

		private void readXmlElement(XmlSchemaObject item)
		{
			XmlSchemaElement element = item as XmlSchemaElement;

			if(element != null)
			{
				//set properties of attributeClass
				m_currentXAttributesOfClass = new ArrayList();
				m_currentXAttribute = new XAttribute();
				m_currentXAttributesOfClass.Add(m_currentXAttribute);
				m_currentXAttribute.AttributeName = element.Name;
				m_currentXAttribute.MinOccurs = element.MinOccurs;
				m_currentXAttribute.MaxOccurs = element.MaxOccurs;
				//TODO:add all possible attributes
				
				//check relations
				if(m_currentXAttribute.MinOccurs == 0 && m_currentXAttribute.MaxOccurs >=1)
				{
					if(m_currentXAttribute.MaxOccurs ==1)
						m_currentXAttribute.OneToOneRelation = true;
					else
						m_currentXAttribute.OneToManyRelation = true;
				
					if(element.SchemaTypeName.Name != String.Empty)
						m_currentXAttribute.RelationTo = element.SchemaTypeName.Name;
				}

				if(element.SchemaType is XmlSchemaSimpleType)
					readXmlSimpleType(element.SchemaType);
				//TODO: add complexType
			}
		}

		private void readXmlSimpleType(XmlSchemaObject item)
		{
			XmlSchemaSimpleType simpleType = item as XmlSchemaSimpleType;

			if(simpleType != null)
			{
				if(simpleType.Content is XmlSchemaSimpleTypeRestriction)
					readXmlRestriction(simpleType.Content);
			}
		}

		private void readXmlComplexType(XmlSchemaObject item)
		{
			XmlSchemaComplexType complexType = item as XmlSchemaComplexType;

			if(complexType != null)
			{
				if(complexType.Particle is XmlSchemaSequence)
					readXmlSequence(complexType.Particle);
				//TODO: add more Particle Types
			}
		}

		private void readXmlRestriction(XmlSchemaObject item)
		{
			XmlSchemaSimpleTypeRestriction restriction = item as XmlSchemaSimpleTypeRestriction;

			if(restriction != null)
			{
				m_currentXAttribute.AttributeType = restriction.BaseTypeName.Name;
				XmlSchemaObjectEnumerator facetEnumerator = restriction.Facets.GetEnumerator();
				while(facetEnumerator.MoveNext())
				{
					if(facetEnumerator.Current is XmlSchemaLengthFacet)
						m_currentXAttribute.Length = Int32.Parse(((XmlSchemaLengthFacet)facetEnumerator.Current).Value);
					if(facetEnumerator.Current is XmlSchemaEnumerationFacet)
						m_currentXAttribute.addEnumType(((XmlSchemaEnumerationFacet)facetEnumerator.Current).Value);
					//TODO: add all facets
				}
			}
		}

		public override string ToString()
		{
			return m_className + ", " + m_fileName;
		}

		#region Properties
		public string FileName
		{
			get{return m_fileName;}
			set
			{
				m_fileName = value;
				if(!m_loader.readXSD(m_fileName))
				{
					m_fileName = String.Empty;
				}
			}
		}

		public string ClassName
		{
			get{return m_className;}
			set{m_className = value;}
		}
		#endregion
	}

	/// <summary>
	/// A class that represents a class in the xml schema file and holds
	/// all relevant information (attribute names, types, etc.), including relations.
	/// </summary>
	public class XAttribute
	{
		private string m_attributeName = String.Empty;
		private string m_attributeType = String.Empty;
		private int m_length = 0;
		private decimal m_minOccurs = 0;
		private decimal m_maxOccurs = 0;
		private ArrayList m_enumValues = new ArrayList();
		private  Hashtable m_attributeRestriction = new Hashtable();
		private bool m_hasOneToManyRelation = false;
		private bool m_hasOneToOneRelation = false;
		private string m_relationTo = String.Empty;
		
		/// <summary>
		/// class constructor
		/// </summary>
		internal XAttribute()
		{
		}

		internal void setAttributeRestriction(object key, object restrictionValue)
		{
			m_attributeRestriction.Add(key, restrictionValue);
		}

		internal void addEnumType(string enumValue)
		{
			m_enumValues.Add(enumValue);
		}
		
		#region Properties
		public string AttributeName
		{
			get{return m_attributeName;}
			set{m_attributeName = value;}
		}

		public string AttributeType
		{
			get{return m_attributeType;}
			set{m_attributeType = value;}
		}

		public int Length
		{
			get{return m_length;}
			set{m_length = value;}
		}

		public ArrayList EnumValues
		{
			get{return m_enumValues;}
		}

		public decimal MinOccurs
		{
			get{return m_minOccurs;}
			set{m_minOccurs = value;}
		}

		public decimal MaxOccurs
		{
			get{return m_maxOccurs;}
			set{m_maxOccurs = value;}
		}

		public bool OneToOneRelation
		{
			get{return m_hasOneToOneRelation;}
			set{m_hasOneToOneRelation = value;}
		}
			
		public bool OneToManyRelation
		{
			get{return m_hasOneToManyRelation;}
			set{m_hasOneToManyRelation = value;}
		}
		
		public string RelationTo
		{
			get{return m_relationTo;}
			set{m_relationTo = value;}
		}

		#endregion
	}
}
