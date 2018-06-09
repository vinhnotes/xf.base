using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BaseProject.Commons;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BaseProject.Services
{
    public class FeedService : IService
    {
        public JsonConverter[] Converters = null;

        public bool IsBusy { set; get; }
        public bool IsCancel { set; get; }
        public bool IsError { set; get; }
        public bool IsFeedMessage { set; get; }

        public bool IsHanderError { set; get; }

        public int Recall { set; get; }


        public string Url { set; get; }


        public void Complete()
        {
            IsBusy = false;
        }

        public FeedService()
        {
            IsHanderError = false;
        }
        public FeedService(string url, bool isFeedMessage)
        {
            IsHanderError = false;
            IsFeedMessage = isFeedMessage;
            Url = url;
        }

        public async Task<T> GetAsync<T>()
        {
            return await GetAsync<T>(Url);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            IsBusy = true;
            IsError = false;
            IsCancel = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Awesome-Octocat-App");
                    var resp = await client.GetAsync(url);

                    if (resp.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new Exception(resp.Content.ToString());
                    }

                    var str = resp.Content.ReadAsStringAsync().Result;
                    System.Diagnostics.Debug.WriteLine(url);
                    System.Diagnostics.Debug.WriteLine(String.Format("Response: {0}", str));
                    if (Converters != null)
                    {
                        return JsonConvert.DeserializeObject<T>(str, Converters);
                    }

                    return Utilities.Deserialize<T>(str);
                }
            }
            catch (Exception e)
            {
                throw (e);

            }

            return default(T);
        }

        public async Task<T> PostAsync<T>(HttpRequestMessage requestMessage)
        {
            IsBusy = true;
            IsError = false;
            IsCancel = false;
            try
            {
                System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

                System.Net.Http.HttpResponseMessage response = await client.SendAsync(requestMessage);
                string str = await response.Content.ReadAsStringAsync();

                System.Diagnostics.Debug.WriteLine(str);
                IsBusy = false;
                return Utilities.Deserialize<T>(str);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return default(T);
        }

    }

    public class FeedService<T> : FeedService
    {
        public Action<T> CallBack;
        public Action<int> ErrorCallBack;
        public FeedService(string url, Action<T> callBack, bool isFeedMessage = false)
            : base(url, isFeedMessage)
        {
            CallBack = callBack;
        }

        public FeedService(string url, Action<T> callBack, Action<int> errorCallBack = null)
            : base(url, false)
        {
            CallBack = callBack;
            ErrorCallBack = errorCallBack;
            IsHanderError = true;

        }
    }
}
