using System.ComponentModel;
using System.Reflection;

namespace TransferoHR.Services.Utils
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            // Obtém o tipo do enum
            var field = value.GetType().GetField(value.ToString());

            // Obtém os atributos do campo
            var attribute = field.GetCustomAttribute<DescriptionAttribute>();

            // Retorna a descrição, ou o nome do enum se não houver descrição
            return attribute != null ? attribute.Description : value.ToString();
        }
    }
}
