using System.Collections.Generic;
using System.IO;
using Nancy;
using Newtonsoft.Json;

namespace Durango.Web
{
    public class JsonNetSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;

        public JsonNetSerializer()
        {
            _serializer = new JsonSerializer();
        }

        public bool CanSerialize(string contentType)
        {
            return contentType == "application/json";
        }

        public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
        {
            using (var writer = new JsonTextWriter(new StreamWriter(outputStream)))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;

                _serializer.Serialize(writer, model);
                writer.Flush();
            }
        }

        public IEnumerable<string> Extensions { get; private set; }
    }
}