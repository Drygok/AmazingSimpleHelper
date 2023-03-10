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
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine(new StartHelper().Invoke());
			}
			catch
			{

			}

			Console.ReadLine();
		}
	}
}
