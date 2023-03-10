using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingSimpleHelper.Util.Trinity
{
	public class TrinityResponse<T>
	{
		public TrinityResponseCode code;
		public T response;
	}
}
