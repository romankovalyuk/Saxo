using System.Collections.Generic;
using System.Dynamic;
using System.Web.Script.Serialization;
using Saxo.Extensions;

namespace Saxo.Helpers
{
    public static class JsonHelper
    {
        public static ExpandoObject ConvertJsonStringToExpando(string json)
        {
            var serializer = new JavaScriptSerializer();

            var dictionary = serializer.Deserialize<IDictionary<string, object>>(json);

            return dictionary.Expando();
        }
    }
}