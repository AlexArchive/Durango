using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using Nancy;

namespace Service
{
    public static class ObjectExtensions
    {
        public static dynamic ToExpandoObject(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));

            return expando as ExpandoObject;
        }

        public static string BaseUri(this Request request)
        {
            var host = request.Url.Port == null
                         ? request.Url.HostName
                         : string.Format("{0}:{1}", request.Url.HostName, request.Url.Port);
            return string.Format("{0}://{1}{2}", request.Url.Scheme, string.IsNullOrWhiteSpace(host) ? "bogus" : host, request.Url.BasePath);
        }

    }
}