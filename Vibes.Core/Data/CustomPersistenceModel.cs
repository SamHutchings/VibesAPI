using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions.Helpers;
using System.Reflection;

namespace Vibes.Core.Data
{
	public class CustomPersistenceModel : AutoPersistenceModel
	{
		public CustomPersistenceModel() : base(new VibesMappingConfiguration())
		{
			AddEntityAssembly(Assembly.Load("Vibes.Core"))
				.Conventions.AddAssembly(Assembly.Load("Vibes.Core"))
				.UseOverridesFromAssembly(Assembly.Load("Vibes.Core"))
				.Conventions.Add(ForeignKey.EndsWith("Id"), DefaultCascade.SaveUpdate());
		}
	}
}
