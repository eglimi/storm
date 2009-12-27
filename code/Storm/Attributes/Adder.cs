using System;

namespace Storm.Attributes
{
	/// <summary>
	/// Applies to Methods.
	/// Defines that an adder method should be generated. This is used for ToMany relations.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class AdderAttribute : Attribute
	{
		private String m_localProperty = String.Empty;
		private String m_targetProperty = String.Empty;

		public AdderAttribute(String localProperty, String targetProperty)
		{
			m_localProperty = localProperty;
			m_targetProperty = targetProperty;
		}

		/// <summary>
		/// Name of the Property in the current class which defines
		/// the corresponding get method. This must be a ToMany relation.
		/// </summary>
		public String LocalProperty
		{
			get
			{
				return m_localProperty;
			}
		}

		/// <summary>
		/// Name of the Property in the target class which defines
		/// the corresponding set method. This must be a ToOne relation.
		/// </summary>
		public String TargetProperty
		{
			get
			{
				return m_targetProperty;
			}
		}


	}
}
