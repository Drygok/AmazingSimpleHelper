using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class GetDevicesTest : AbstractTest
	{
		public override string Name => "Получение списка подключенных устройств";

		public override string Test()
		{
			ManagementObjectCollection deviceCollection = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity").Get();

			string result = "Подключенные устройства:\n";

			foreach (ManagementObject device in deviceCollection)
			{
				string name = device.GetPropertyValue("Name")?.ToString();
				string deviceId = device.GetPropertyValue("DeviceID")?.ToString();

				result += $"\t{name} ({deviceId})\n";
			}

			return result;
		}
	}
}
