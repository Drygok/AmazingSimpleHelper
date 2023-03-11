using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Tests
{
	internal class InstalledProgramsTest : AbstractTest
	{
		public override string Name => "Получение списка установленных программ";

		public List<string> GetInstalledPrograms(RegistryKey baseKey)
		{
			List<string> installedPrograms = new List<string>();

			// Открываем ключ реестра, где хранятся установленные программы
			using (RegistryKey key = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"))
			{
				// Получаем список всех подключей в этом ключе
				string[] subKeyNames = key.GetSubKeyNames();

				// Перебираем все подключи и ищем названия программ
				foreach (string subKeyName in subKeyNames)
				{
					// Получаем подключь по имени
					using (RegistryKey subKey = key.OpenSubKey(subKeyName))
					{
						// Получаем название программы из соответствующего параметра реестра
						string displayName = subKey.GetValue("DisplayName")?.ToString();

						// Если название программы найдено/* и она не является обновлением или исправлением*/
						if (!string.IsNullOrEmpty(displayName)/* && !displayName.Contains("Update") && !displayName.Contains("Patch")*/)
						{
							installedPrograms.Add(displayName);
						}
					}
				}
			}

			return installedPrograms;
		}

		public override string Test()
		{
			//return $"Установленные глобально программы: \n\t" +
			//	$"{string.Join("\n\t", GetInstalledPrograms(Registry.LocalMachine))}" +
			//	$"\nУстановки текущего пользователя: \n\t" +
			//	$"{string.Join("\n\t", GetInstalledPrograms(Registry.CurrentUser))}";
			List<string> result = GetInstalledPrograms(Registry.LocalMachine);
			result.AddRange(GetInstalledPrograms(Registry.CurrentUser));

			// Возвращаем список установленных программ без дубликатов, отсортированный по алфавиту
			return $"Установленные программы: \n\t" +
				$"{string.Join("\n\t", result.Distinct().OrderBy(program => program).ToList())}";
		}
	}
}
