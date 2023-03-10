using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Util.Trinity
{
	/// <summary>
	/// Формат ответа Тринити
	/// </summary>
	/// <typeparam name="T">Любой сериализованный в JSON объект</typeparam>
	public class TrinityResponse<T>
	{
		public TrinityResponseCode code;
		public T response;
	}
}
