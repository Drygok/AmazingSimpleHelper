using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class OSVersionTest : AbstractTest
	{
		public override string Name => "Получение версии OC";

		public override string Test()
		{
			string result = "Сведения о системе: \n";

			using (Process process = new Process())
			{
				process.StartInfo = new ProcessStartInfo()
				{
					FileName = "cmd.exe",
					Arguments = "/c systeminfo",
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				};
				process.Start();

				while (!process.StandardOutput.EndOfStream)
				{
					string line = process.StandardOutput.ReadLine().Replace("\t", "").Trim();
					while (line.Contains("  "))
					{
						line = line.Replace("  ", " ");
					}

					result += $"\t{line}\n";
				}
			}

			return result;
		}
	}
}
