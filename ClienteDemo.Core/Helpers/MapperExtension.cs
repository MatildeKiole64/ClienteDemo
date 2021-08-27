using System.Text.Json;

namespace ClienteDemo.Core.Helpers
{
    public static class MapperExtension
    {
        public static T MapTo<T>(this object source) =>
            JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(source));
    }
}
