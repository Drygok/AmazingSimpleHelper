using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	/// <summary>
	/// Родитель всех тестов
	/// </summary>
	public abstract class AbstractTest
	{
		public virtual string Name => "Неизвестный тест";
		public abstract string Test();

		/// <summary>
		/// Базовый метод исполнения теста
		/// </summary>
		/// <returns>Текст с результатом исполнения</returns>
		public string Invoke()
		{
			string result;
			try
			{
				result = $"OK ({Test()})";
			}
			catch (Exception e) 
			{
				result = $"ОШИБКА ({e.Message})";
			}

			return $"{this.GetType().Name} - {Name}: {result}";
		}
	}
}
