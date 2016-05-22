using FluentNHibernate.Automapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vibes.Core.Data
{
	public class CustomPersistenceModel : AutoPersistenceModel
	{
		public CustomPersistenceModel() : base(new VibesMappingConfiguration()) { }
	}
}
