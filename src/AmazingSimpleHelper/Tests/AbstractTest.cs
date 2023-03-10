using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	public abstract class AbstractTest
	{
		public abstract string Name { get; }
		public abstract string Test();

		public string Invoke()
		{
			return $"{this.GetType().Name} - {Name}: {Test()}";
		}
	}
}
