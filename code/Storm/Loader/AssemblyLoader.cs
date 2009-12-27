using System;
using System.IO;
using System.Reflection;
using System.ComponentModel;

namespace Storm.Loader
{
	/// <summary>
	/// Summary description for AssemblyGen.
	/// </summary>
	[TypeConverter(typeof(XmlSerializedTypeConverter))]
	[Editor(typeof(Storm.Loader.AssemblyLoaderEditor),typeof(System.Drawing.Design.UITypeEditor))]
	public class AssemblyLoader
	{
		private string m_sourceAssembly;
		private string m_className;

		public AssemblyLoader()
		{
			
		}

		public Type ClassType
		{
			get
			{
				try
				{	
					Assembly a = Assembly.LoadFile(SourceAssembly);

					Type[] types = a.GetTypes();
					foreach(Type type in types) 
					{
						if(type.Name == ClassName && type.IsClass)
							return type;
					}		
					return null;
				}
				catch(ApplicationException e)
				{
					throw new ApplicationException(e.Message);
				} 
			}
		}

		public string SourceAssembly
		{
			get{return m_sourceAssembly;}
			set{m_sourceAssembly = value;}
		}
		public string ClassName
		{
			get{return m_className;}
			set{m_className = value;}
		}
	}
}
