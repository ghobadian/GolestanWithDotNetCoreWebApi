
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace DataLayer.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Rank
{
    ASSISTANT, ASSOCIATE, FULL
}
