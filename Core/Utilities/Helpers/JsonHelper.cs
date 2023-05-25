using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Core.Utilities.Helpers
{
    public class JsonHelper
    {
        public static JObject FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JObject>(json);
        }
    }
}

