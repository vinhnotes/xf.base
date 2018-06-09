using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace BaseProject.Commons
{
    public class Utilities
    {
        public static T Deserialize<T>(string jsonstring)
        {
            return JsonConvert.DeserializeObject<T>(jsonstring);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static string GetString(string key)
        {
            return "";
        }
    }
}

