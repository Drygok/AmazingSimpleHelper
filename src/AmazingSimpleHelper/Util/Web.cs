using System;
using System.ComponentModel;
using System.Net.Cache;
using System.Net;
using System.Text;

namespace AmazingSimpleHelper.Util
{
	public static class Web
	{
		public class TimedWebClient : WebClient
		{
			// Timeout in milliseconds, default = 600,000 msec
			public int Timeout { get; set; }

			public TimedWebClient()
			{
				this.Timeout = 600000;
			}

			protected override WebRequest GetWebRequest(Uri address)
			{
				WebRequest webRequest = base.GetWebRequest(address);
				webRequest.Timeout = this.Timeout; // null = npe = exception = ok
				return webRequest;
			}
		}


		public static WebClient CreateWebClient(int timeout = 5000)
		{
			WebClient webClient = new TimedWebClient() { Timeout = timeout };
			webClient.Headers.Add("User-Agent", "AmazingSimpleHelper (Snegirev Maxim, vk.com/drygok, 2.1)");
			webClient.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);

			return webClient;
		}

		#region GET-запросы
		public static string SendGetRequest(string url)
		{
			return Encoding.UTF8.GetString(CreateWebClient().DownloadData(url));
		}
		#endregion

		#region Получение файлов
		public static void DownloadFile(string url, string name)
		{
			CreateWebClient(60000).DownloadFile(url, name);
		}
		public static void DownloadFileAsync(string url, string name, AsyncCompletedEventHandler completedEventHandler)
		{
			WebClient webClient = CreateWebClient();
			if (completedEventHandler != null) webClient.DownloadFileCompleted += completedEventHandler;
			webClient.DownloadFileAsync(new Uri(url), name);
		}
		#endregion
	}
}
