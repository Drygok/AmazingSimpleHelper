using AmazingSimpleHelper.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper
{
	internal class Program
	{
		/// <summary>
		/// Список тестов релизной версии, исполняющихся всегда
		/// </summary>
		private static readonly AbstractTest[] ReleaseTests =
		{
			new StartHelperTest()
		};
		/// <summary>
		/// Список тестов development-сборки, исполняющихся только в тестовой версии приложения
		/// </summary>
		private static readonly AbstractTest[] DevelopmentTests =
		{
			new ErrorTest(Environment.UserName)
		};

		static void Main(string[] args)
		{
			try
			{
				foreach (AbstractTest releaseTest in ReleaseTests)
				{
					Console.WriteLine($"[P] " +
						$"[{DateTime.Now.ToShortTimeString()} - {DateTime.Now.ToShortDateString()}] " +
						$"{releaseTest.Invoke()}");
				}
				foreach (AbstractTest developmentTest in DevelopmentTests)
				{
					Console.WriteLine($"[D] " +
						$"[{DateTime.Now.ToShortTimeString()} - {DateTime.Now.ToShortDateString()}] " +
						$"{developmentTest.Invoke()}");
				}

			}
			catch
			{

			}

			Console.ReadLine();
		}
	}
}
