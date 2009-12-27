using System;
using System.Reflection;
using System.Collections;
using Storm.Attributes;

namespace Storm.Lib
{
	/// <summary>
	/// Summary description for Registry.
	/// </summary>
	public class Registry
	{
		#region Members

		private static Registry m_Registry;
		
		private bool m_initialized = false;
		private Hashtable m_impls = new Hashtable();
		private Hashtable m_mappers = new Hashtable();
		private Hashtable m_mapperInstances = new Hashtable();
		private Hashtable m_factories = new Hashtable();
		
		#endregion

		public Registry()
		{
		}

    /// <summary>
		/// Gets the instance of the Registry (Singleton). 
		/// </summary>
		public static Registry Instance
		{
			get
			{
				if(m_Registry == null)
				{
					m_Registry = new Registry();
				}
				return m_Registry;
			}
		}

		/// <summary>
		/// This functions initializes the Registry. It has to be called before first
		/// usage of the Registry.
		/// </summary>
		/// <param name="runnable"></param>
		/// <param name="host">Computername of the Database Server</param>
		/// <param name="database">Name of the database</param>
		public void init(object runnable, string hostname, string database)
		{
			if(m_initialized)
				return;

			UnitOfWork.Instance.Hostname = hostname;
			UnitOfWork.Instance.Database = database;

			Assembly assembly = runnable.GetType().Assembly;
			ArrayList assemblies = new ArrayList();
			assemblies.Add(assembly.GetName());
			assemblies.AddRange(assembly.GetReferencedAssemblies());
			foreach(AssemblyName refAssemblyName in assemblies)
			{
				if(refAssemblyName.Name != "mscorlib")
				{
					Assembly refAssembly = Assembly.Load(refAssemblyName);
					foreach(Type type in refAssembly.GetTypes())
					{
						if(type.IsClass)
						{
							foreach(Attribute attr in type.GetCustomAttributes(true))
							{
								switch(attr.GetType().Name)
								{
									case "DomainObjectImplAttribute":
										addImpl(type);
										continue;
									case "MapperImplAttribute":
										addMapper(((MapperImplAttribute)attr).Type, type);
										continue;
								}
							}
						}
					}
				}
			}
			m_initialized = true;
		}

		private void addImpl(Type type)
		{
			m_impls.Add(type.BaseType, type);
		}

		public Type getImpl(Type baseType)
		{
			return (Type)m_impls[baseType];
		}

		private void addMapper(Type type, Type mapperType)
		{
			m_mappers.Add(type, mapperType);
		}

		public IMapper getMapper(Type type)
		{
			if(!m_initialized)
				throw new ApplicationException("Registry not initialized!");
//			Type implType = (Type)m_impls[type];
//
//			MethodInfo mInfo = implType.GetProperty("Mapper").GetGetMethod(false);
//			Object[] parameters = new Object[0];
//			return (IMapper)mInfo.Invoke(null, parameters);
			Type mapperType = (Type)m_mappers[type];
			IMapper mapper = (IMapper)m_mapperInstances[mapperType];
			if(mapper == null)
			{
				ConstructorInfo ci = mapperType.GetConstructor(System.Type.EmptyTypes);
				mapper = (IMapper)ci.Invoke(new object[] {});
				m_mapperInstances[mapperType] = mapper;
			}
				
			return mapper;
		}

		public IFactory getFactory(Type type)
		{
			if(!m_initialized)
				throw new ApplicationException("Registry not initialized!");
			Type implType = (Type)m_impls[type];

			MethodInfo mInfo = implType.GetProperty("Factory").GetGetMethod(false);
			Object[] parameters = new Object[0];
			return (IFactory)mInfo.Invoke(null, parameters);
		}

		public IFinder getFinder(Type type)
		{
			if(!m_initialized)
				throw new ApplicationException("Registry not initialized!");
			Type implType = (Type)m_impls[type];

			MethodInfo mInfo = implType.GetProperty("Finder").GetGetMethod(false);
			Object[] parameters = new Object[0];
			return (IFinder)mInfo.Invoke(null, parameters);
		}
	}
}
