using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SpeedTest.Net;
using SpeedTest.Net.Models;

namespace AmazingSimpleHelper.Tests
{
	internal class SpeedTest : AbstractTest
	{
		public override string Name => "Получение скорости загрузки с ближайшего сервера SpeedTest";

		public override string Test()
		{
			Task<Server> serverTask = SpeedTestClient.GetServer(59.9504967, 30.2976463);
			serverTask.Wait();

			Server server = serverTask.Result;

			Task<DownloadSpeed> speedTask = SpeedTestClient.GetDownloadSpeed(server);

			speedTask.Wait();

			return "Скорость загрузки: " + speedTask.Result.Unit;
		}
	}
}
