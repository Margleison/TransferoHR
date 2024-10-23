using System.ComponentModel;

namespace DentalRJ.Domain.Enums
{
    public enum StateCodeEnum
    {
        [Description("Acre")]
        AC,

        [Description("Alagoas")]
        AL,

        [Description("Amapá")]
        AP,

        [Description("Amazonas")]
        AM,

        [Description("Bahia")]
        BA,

        [Description("Ceará")]
        CE,

        [Description("Distrito Federal")]
        DF,

        [Description("Espírito Santo")]
        ES,

        [Description("Goiás")]
        GO,

        [Description("Maranhão")]
        MA,

        [Description("Mato Grosso")]
        MT,

        [Description("Mato Grosso do Sul")]
        MS,

        [Description("Minas Gerais")]
        MG,

        [Description("Pará")]
        PA,

        [Description("Paraíba")]
        PB,

        [Description("Paraná")]
        PR,

        [Description("Pernambuco")]
        PE,

        [Description("Piauí")]
        PI,

        [Description("Rio de Janeiro")]
        RJ,

        [Description("Rio Grande do Norte")]
        RN,

        [Description("Rio Grande do Sul")]
        RS,

        [Description("Rondônia")]
        RO,

        [Description("Roraima")]
        RR,

        [Description("Santa Catarina")]
        SC,

        [Description("São Paulo")]
        SP,

        [Description("Sergipe")]
        SE,

        [Description("Tocantins")]
        TO
    }

    /*

    // Método de extensão para obter a descrição
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = (DescriptionAttribute)field.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
    */
}