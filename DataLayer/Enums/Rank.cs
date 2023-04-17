using System.Text.Json.Serialization;

namespace DataLayer.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Rank
{
    ASSISTANT, ASSOCIATE, FULL
}
