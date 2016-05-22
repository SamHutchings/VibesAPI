using FluentNHibernate;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;
using System;
using System.Linq;

namespace Vibes.Core.Data.Conventions
{
	/// <summary>
	/// Add FK onto foreign keys
	/// </summary>
	public class CustomForeignKeyConvention : IReferenceConvention, ICollectionConvention
	{
		/// <summary>
		/// Get the key name from the property or the type
		/// </summary>
		/// <param name="property"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public virtual string GetKeyName(Member property, Type type)
		{
			if (property != null)
				return property.Name + type.Name + "Id";

			return type.Name + "Id";
		}

		/// <summary>
		/// Apply the reference convention
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(IManyToOneInstance instance)
		{
			string columnName = GetKeyName(instance.Property, instance.Class.GetUnderlyingSystemType());

			instance.Column(columnName);

			var key = String.Format("FK_{0}_{1}", instance.EntityType.Name, instance.Name);

			instance.ForeignKey(key);
		}

		/// <summary>
		/// Apply the collection convention
		/// </summary>
		/// <param name="instance"></param>
		public void Apply(ICollectionInstance instance)
		{
			string columnName = GetKeyName(null, instance.EntityType);
			instance.Key.Column(columnName);
		}
	}
}
