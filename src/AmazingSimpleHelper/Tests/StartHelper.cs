using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class StartHelper : AbstractTest
	{
		public override string Name => "Инициализация приложения";
		public override string Test()
		{
			return "Приложение запущено";
		}
	}
}
