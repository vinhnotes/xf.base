using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseProject.Services
{
    public interface IService
    {
        bool IsBusy { set; get; }
        bool IsCancel { set; get; }
        bool IsError { set; get; }
        bool IsFeedMessage { set; get; }

        bool IsHanderError { set; get; }

        int Recall { set; get; }
        string Url { set; get; }

        void Complete();
        Task<T> GetAsync<T>();
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(HttpRequestMessage requestMessage);
    }
}
