using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;
using System.Globalization;
using System.Text;

namespace Libreria.LogicaNegocio.Vo
{
    public record VoEmail : IValidable
    {
        public string Value { get; private set; }

        public VoEmail(string value)
        {
            Value = Normalizar(value);
            Validable();
        }
        public void Validable()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new EmailException("El email no puede estar vacío");
            if (!Value.Contains("@"))
                throw new EmailException("El email debe contener '@'");
        }
        private static string Normalizar(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            var chars = normalized.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new string(chars.ToArray()).Normalize(NormalizationForm.FormC).ToLower();
        }
    }
}
