using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace XParser
{
	public class Loader
	{
		XmlValidatingReader reader = null;
		//string m_xsdFileName = "D:\\ooxgen\\code\\HsrOrderApp_S4\\BusinessLayer\\DomainModel\\BusinessObjects1.xsd";
		string m_className = String.Empty;
		private Hashtable m_classes = new Hashtable();
		private Hashtable m_typeCollection = new Hashtable();
		private ArrayList m_typeDefs = new ArrayList();

		private enum elementType {Class, TypeDef, Ref, Undefined};
		
		public Loader() {}

		public bool readXSD(string fileName)
		{
			try
			{
				//textReader = new XmlTextReader(m_xsdFileName);
				//reader = new XmlValidatingReader(textReader);
				XmlTextReader reader = new XmlTextReader(fileName);
				
				XmlSchema schema = XmlSchema.Read(reader, new ValidationEventHandler(ValidationCallback));
				//schema.Compile(new ValidationEventHandler(ValidationCallback));

				//read items
				foreach(XmlSchemaObject item in schema.Items)
				{
					readXmlSchemaItem(item);
				}
				return true;
			}
			catch(XmlSchemaException e)
			{
				MessageBox.Show(e.ToString());
				return false;
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}
		}
			
		private void readXmlSchemaItem(XmlSchemaObject item)
		{
			if (item is XmlSchemaType)
				readXmlSchemaType(item);
			else if(item is XmlSchemaElement)
				readXmlSchemaElement(item, elementType.Undefined);
			else if(item is XmlSchemaGroup)
				readXmlSchemaGroup(item);
		}

		private void readXmlSchemaType(XmlSchemaObject item)
		{
			XmlSchemaType schemaType = item as XmlSchemaType;

			if(schemaType != null)
			{
				if(schemaType is XmlSchemaComplexType)
					readXmlSchemaComplexType(schemaType);
				else if(schemaType is XmlSchemaSimpleType)
					readXmlSchemaSimpleType(schemaType);
			}
		}

		private void readXmlSchemaGroup(XmlSchemaObject item)
		{
			XmlSchemaGroup group = item as XmlSchemaGroup;

			if(group != null && group.Name != String.Empty)
			{
				if(group.Name == "classes")
				{
					if(group.Particle is XmlSchemaSequence)
						foreach(XmlSchemaElement element in group.Particle.Items)
						{
							m_classes.Add(element.Name, element);
							m_typeDefs.Add(element.SchemaTypeName.Name);
						}
				}
			}
		}

		// not used at the moment
		private void readXmlSchemaSequence(XmlSchemaObject item, elementType type)
		{
			XmlSchemaSequence sequence = item as XmlSchemaSequence;
					
			if(sequence != null)
			{
				foreach(XmlSchemaObject obj in sequence.Items)
				{
					if(obj is XmlSchemaElement)
						readXmlSchemaElement(obj, type);
				}
			}
		}

		// not used at the moment
		private void readXmlSchemaElement(XmlSchemaObject item, elementType type)
		{
			XmlSchemaElement element = item as XmlSchemaElement;

			if(element != null && element.Name != String.Empty)
			{
			}
		}

		// not used at the moment
		private void readXmlSchemaSimpleType(XmlSchemaObject item)
		{
		
		}
		
		private void readXmlSchemaComplexType(XmlSchemaObject item)
		{
			XmlSchemaComplexType complexType = item as XmlSchemaComplexType;

			if(complexType != null && complexType.Name != String.Empty)
			{
				if(m_typeDefs.Contains(complexType.Name))
				{
					m_typeCollection.Add(complexType.Name, complexType);
				}
			}
		}

		/// <summary>
		/// callback method for xmlschema reader. In case of an error, this event handler
		/// will be called
		/// </summary>
		/// <param name="sender">the sender of the error</param>
		/// <param name="args">arguments which are passed to the event handler.
		/// this contains the error message.
		/// </param>
		public static void ValidationCallback(object sender, ValidationEventArgs args) 
		{
			MessageBox.Show(args.Message);
		}
		#region Properties
	
		public Hashtable Classes
		{
			get{return m_classes;}
		}
		
		public Hashtable TypeCollection
		{
			get{return m_typeCollection;}
		}

		#endregion
	}
}



