using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using System;

namespace Vibes.Core.Data.Conventions
{
	/// <summary>
	/// Reference conventions
	/// </summary>
	public class CustomReferenceConvention : IReferenceConvention
	{
		/// <summary>
		/// Many to one convention
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(IManyToOneInstance instance)
		{
			if (instance.Property != null)
				instance.Column(instance.Property.Name + "Id");
			else
				instance.Column(instance.Class.GetUnderlyingSystemType() + "Id");

			instance.ForeignKey(String.Format("FK_{0}_{1}", instance.EntityType.Name, instance.Name);
		}
	}
}
