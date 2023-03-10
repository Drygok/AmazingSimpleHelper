using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	/// <summary>
	/// Пример реализации теста-наследника AbstractTest
	/// </summary>
	internal class StartHelperTest : AbstractTest
	{
		/// <summary>
		/// Заголовок теста
		/// </summary>
		public override string Name => "Инициализация приложения";

		/// <summary>
		/// Реализация теста
		/// </summary>
		/// <returns>Текст завершения или исключение с сообщением ошибки</returns>
		public override string Test()
		{
			// тест завершился с ошибкой
			// throw new Exception("Ошибка запуска");

			// тест пройден успешно
			return "Приложение запущено";
		}
	}
}
