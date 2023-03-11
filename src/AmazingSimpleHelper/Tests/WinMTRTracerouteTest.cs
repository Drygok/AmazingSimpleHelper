using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class WinMTRTracerouteTest : AbstractTest
	{
		public override string Name => "Трассировка к серверу " + IP;
		private string IP;

		public WinMTRTracerouteTest(string ip) 
		{ 
			this.IP = ip;
		}

		public override string Test()
		{
			return Execute();
		}

		public string Execute()
		{
			string output = "";

			// Путь к исполняемому файлу WinMTR
			string winMTRPath = "WinMTR.exe";

			// Команда для запуска WinMTR с заданным IP-адресом назначения
			string command = $"{winMTRPath} {this.IP}";

			ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
			processInfo.CreateNoWindow = true;
			processInfo.UseShellExecute = false;
			processInfo.RedirectStandardOutput = true;

			using (Process process = new Process())
			{
				process.StartInfo = processInfo;
				process.Start();

				// Считывание выходных данных из процесса
				output = process.StandardOutput.ReadToEnd();

				process.WaitForExit();
			}

			return output;
		}
	}
}
