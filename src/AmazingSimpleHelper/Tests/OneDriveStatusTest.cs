using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class OneDriveStatusTest : AbstractTest
	{
		public override string Name => "Определение наличия OneDrive в системе";

		public override string Test()
		{
			var regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\OneDrive");
			if (regKey == null)
			{
				return "OneDrive не найден";
			}
			var value = regKey.GetValue("EnableFile1");
			return (value != null && (int)value == 1) ? "OneDrive обнаружен" : "Вероятно, OneDrive выключен";
		}
	}
}
