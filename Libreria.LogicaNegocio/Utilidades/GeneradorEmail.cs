using System.Globalization;
using System.Text;

namespace Libreria.LogicaNegocio.Utilidades
{
    public static class GeneradorEmail
    {
        private const string DOMINIO = "@laempresa.com";

        public static string GenerarEmail(string nombre, string apellido)
        {

            string nombreNormalizado = NormalizarTexto(nombre);
            string apellidoNormalizado = NormalizarTexto(apellido);
            string parteNombre = ExtraerPrimeras3Letras(nombreNormalizado);
            string parteApellido = ExtraerPrimeras3Letras(apellidoNormalizado);
            return $"{parteNombre}{parteApellido}{DOMINIO}".ToLower();
        }

        private static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return texto;
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in textoNormalizado)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        private static string ExtraerPrimeras3Letras(string texto)
        {
            return texto.Length >= 3 ? texto.Substring(0, 3) : texto;
        }
        public static string GenerarNumeroAleatorio()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }
    }
}