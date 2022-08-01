using Newtonsoft.Json;
using System.Reflection;
using ValueOf;

namespace ValueOfAPI.Conveters
{
    class ValueOfConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.BaseType.IsGenericType)
                if (objectType.BaseType.GetGenericTypeDefinition() == typeof(ValueOf<,>))
                    return true;
            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jt = Newtonsoft.Json.Linq.JToken.ReadFrom(reader);
            var valueType = objectType.BaseType.GetGenericArguments()[0];
            var value = jt.ToObject(valueType, serializer);
            var from = objectType.GetMethod("From", BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            return from.Invoke(null, new[] { value });
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var innerValue = ((dynamic)value).Value;
            serializer.Serialize(writer, innerValue);

        }
    }
}