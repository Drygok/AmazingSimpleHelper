using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class ErrorTest : AbstractTest
	{
		public override string Name => "Тест с ошибкой";

		private string UserName;

		public ErrorTest(string userName)
		{
			this.UserName = userName;
		}
		
		public override string Test()
		{
			throw new Exception($"При исполнении теста пользователем {UserName} произошла ошибка");
		}
	}
}
