using System.Text.Json.Serialization;

namespace DataLayer.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Degree//todo what if term was close
{
    BS, MS, PHD
}

