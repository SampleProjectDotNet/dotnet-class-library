using System;

namespace ClassLibrary
{
    public class CpfValidator
    {
        /// <summary>
        /// Valida se o CPF fornecido é válido.
        /// </summary>
        /// <param name="cpf">O CPF a ser validado.</param>
        /// <returns>True se o CPF for válido, caso contrário False.</returns>
        public bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !long.TryParse(cpf, out _)) return false;

            // Verifica se todos os dígitos são iguais
            if (new string(cpf[0], cpf.Length) == cpf) return false;

            // Calcula os dígitos verificadores
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito1;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }
    }
}
