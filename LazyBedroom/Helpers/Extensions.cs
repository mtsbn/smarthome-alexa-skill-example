using LazyBedroom.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LazyBedroom.Helpers
{
    public static class Extensions
    {
        public static object SerializeResponse(this AlexaResponse response)
        {
            var str = JsonConvert.SerializeObject(response, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            });

            Console.WriteLine("Response: ");
            Console.WriteLine(str);

            return JsonConvert.DeserializeObject<object>(str);
        }
    }
}

