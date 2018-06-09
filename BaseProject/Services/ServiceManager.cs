using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BaseProject.Apps;
using BaseProject.Models;
using BaseProject.ViewModels;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BaseProject.Services
{
    public class ServiceManager
    {
        Dictionary<string, IService> Services;
        BaseViewModel ViewModel;

        public ServiceManager(BaseViewModel viewModel)
        {
            ViewModel = viewModel;
            Services = new Dictionary<string, IService>();
        }

        public void Cancel(string serviceId)
        {
            if (Services.ContainsKey(serviceId))
            {
                if (Services[serviceId].IsBusy)
                {
                    Services[serviceId].IsCancel = true;
                    ViewModel.OnFeedCompleted();
                }
            }
        }
        public void Cancel()
        {
            int count = Services.Keys.Count;
            for (int i = 0; i < count; i++)
            {
                if (Services[Services.Keys.ElementAt(i)].IsBusy)
                {
                    Services[Services.Keys.ElementAt(i)].IsCancel = true;
                    ViewModel.OnFeedCompleted();
                }
            }
        }

        public void Retry()
        {
            int count = Services.Keys.Count;
            for (int i = 0; i < count; i++)
            {
                IService feedservice = Services[Services.Keys.ElementAt(i)];
                if (feedservice.IsError)
                {
                    if (!feedservice.IsFeedMessage)
                    {
                        var methodInfo = typeof(ServiceManager).GetRuntimeMethod("GetData", new Type[] { typeof(IService) });
                        var method = methodInfo.MakeGenericMethod(feedservice.GetType().GenericTypeArguments[0]);
                        method.Invoke(this, new[] { feedservice });
                    }
                    else
                    {
                        GetFeedMessage(feedservice);
                    }
                }
            }
        }



        public void GetData<T>(string serviceId, string url, Action<T> callback, params JsonConverter[] converters)
        {
            if (!Services.ContainsKey(serviceId))
            {
                Services.Add(serviceId, new FeedService<T>(url, callback, null)
                {
                    Converters = converters
                });
            }
            else
            {
                (Services[serviceId] as FeedService<T>).CallBack = callback;

            }
            IService feedService = Services[serviceId];
            feedService.Url = url;
            GetData<T>(feedService);
        }

        public void GetData<T>(string serviceId, string url, Action<T> callback, Action<int> errorCallBack, params JsonConverter[] converters)
        {
            if (!Services.ContainsKey(serviceId))
            {
                Services.Add(serviceId, new FeedService<T>(url, callback, errorCallBack)
                {
                    Converters = converters
                });
            }
            else
            {
                (Services[serviceId] as FeedService<T>).CallBack = callback;
                (Services[serviceId] as FeedService<T>).ErrorCallBack = errorCallBack;
            }
            IService feedService = Services[serviceId];
            feedService.Url = url;
            GetData<T>(feedService);
        }

        public void GetData<T>(string serviceId, string url, Action<T> callback, Action<int> errorCallBack = null)
        {
            if (!Services.ContainsKey(serviceId))
            {
                Services.Add(serviceId, new FeedService<T>(url, callback, errorCallBack));
            }
            else
            {
                (Services[serviceId] as FeedService<T>).CallBack = callback;
                (Services[serviceId] as FeedService<T>).ErrorCallBack = errorCallBack;
            }
            IService feedService = Services[serviceId];
            feedService.Url = url;
            GetData<T>(feedService);
        }


        public void GetMessage(string serviceId, string url, Action<int> callback = null)
        {
            if (!Services.ContainsKey(serviceId))
            {
                Services.Add(serviceId, new FeedService<int>(url, callback, true));
            }
            else
            {
                (Services[serviceId] as FeedService<int>).CallBack = callback;

            }
            IService feedService = Services[serviceId];
            feedService.Url = url;
            GetFeedMessage(feedService);
        }

        public void GetData<T>(IService feedService)
        {
            if (!feedService.IsBusy && !feedService.IsCancel)
            {
                ViewModel.OnPreFeed();
                var task = feedService.GetAsync<T>();
                var awaiter = task.GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    ViewModel.OnFeedCompleted();
                    if (task.Exception != null)
                    {
                        System.Diagnostics.Debug.WriteLine(task.Exception.InnerException.ToString());
                        feedService.IsError = true;
                        ViewModel.IsDisconect = true;
                        feedService.Complete();
                        if (feedService.IsHanderError)
                        {
                            var feed = (feedService as FeedService<T>);
                            if (feed.ErrorCallBack != null)
                            {
                                ViewModel.IsDisconect = true;
                                feed.ErrorCallBack(Constants.ParseDataErrorCode);
                            }
                        }
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            if (!feedService.IsCancel)
                            {
                                ViewModel.IsDisconect = false;
                                Response result = task.Result as Response;
                                if (result != null)
                                {
                                    feedService.Recall = 0;
                                    (feedService as FeedService<T>).CallBack(task.Result);
                                }
                                else
                                {

                                    feedService.IsError = true;
                                    ViewModel.IsDisconect = true;
                                    if (feedService.IsHanderError)
                                    {
                                        var feed = (feedService as FeedService<T>);
                                        if (feed.ErrorCallBack != null)
                                        {
                                            feed.ErrorCallBack(Constants.DisconnectErrorCode);
                                        }
                                    }
                                }
                                feedService.Complete();
                            }
                        });
                    }
                });
            }

        }

        public void GetFeedMessage(IService feedService)
        {

            if (!feedService.IsBusy || !feedService.IsCancel)
            {
                ViewModel.OnPreFeed();
                var task = feedService.GetAsync<Response>();
                var awaiter = task.GetAwaiter();

                awaiter.OnCompleted(() =>
                {
                    ViewModel.OnFeedCompleted();
                    if (task.Exception != null)
                    {
                        feedService.IsError = true;
                        if ((feedService as FeedService<int>).CallBack != null)
                        {
                            (feedService as FeedService<int>).CallBack(Constants.ParseDataErrorCode);
                        }

                        feedService.Complete();
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            if (!feedService.IsCancel)
                            {
                                Response result = task.Result;
                                if (result != null)
                                {
                                    if ((feedService as FeedService<int>).CallBack != null)
                                    {
                                        (feedService as FeedService<int>).CallBack(0);
                                    }
                                }
                                else
                                {
                                    feedService.Recall = 0;
                                    feedService.IsError = true;

                                    (feedService as FeedService<int>).CallBack(Constants.DisconnectErrorCode);
                                }
                                feedService.Complete();

                            }
                        });
                    }
                });
            }
        }

    }
}
