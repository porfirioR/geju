using System.Runtime.Serialization;

namespace GeJu.Utilities.Enums
{
    public enum CountryType
    {
        [EnumMember(Value = "Paraguay")]
        Paraguay = 1,
        [EnumMember(Value = "Argentina")]
        Argentina = 2,
        [EnumMember(Value = "EstadosUnidos")]
        EstadosUnidos = 3
    }
}
