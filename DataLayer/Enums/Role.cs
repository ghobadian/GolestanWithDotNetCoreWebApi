using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DataLayer.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Role
{
    STUDENT,
    INSTRUCTOR,
    ADMIN
}


