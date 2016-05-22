using FluentNHibernate;
using FluentNHibernate.Conventions;
using System;

namespace Vibes.Core.Data.Conventions
{
	/// <summary>
	/// Add FK onto foreign keys
	/// </summary>
	public class CustomForeignKeyConvention : ForeignKeyConvention
	{
		protected override string GetKeyName(Member property, Type type)
		{
			if (property == null)
			{
				return type.Name + "_FK";
			}

			return property.Name + "_FK";
		}
	}
}
