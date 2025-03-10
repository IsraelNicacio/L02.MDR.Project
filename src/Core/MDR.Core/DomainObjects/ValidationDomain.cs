using System.Text.RegularExpressions;

namespace MDR.Core.DomainObjects;

public class ValidationDomain
{
    public static void ValidarSeVazioNulo(string value, string message)
    {
        if (string.IsNullOrEmpty(value))
            throw new DomainException(message);
    }

    public static void ValidarSeIgual(object obj1, object obj2, string message)
    {
        if (obj1.Equals(obj2))
            throw new DomainException(message);
    }

    public static void ValidarSeDiferente(object obj1, object obj2, string message)
    {
        if (obj1.Equals(obj2))
            throw new DomainException(message);
    }

    public static void ValidarCaracteres(string value, int max, string message)
    {
        if (!string.IsNullOrEmpty(value) && value.Length > max)
            throw new DomainException(message);
    }

    public static void ValidarCaracteres(string value, int min, int max, string message)
    {
        if (!string.IsNullOrEmpty(value) && (value.Length < min || value.Length > max))
            throw new DomainException(message);
    }

    public static void ValidarExpressaoRegular(string value, string pattern, string message)
    {
        if (!string.IsNullOrEmpty(value) && new Regex(pattern).IsMatch(value))
            throw new DomainException(message);
    }

    public static void ValidarMinimoMaximo(decimal value, decimal min, decimal max, string message)
    {
        if (value < min || value > max)
            throw new DomainException(message);
    }

    public static void ValidarSeMenorIqualMinimo(decimal value, decimal min, string message)
    {
        if (value <= min)
            throw new DomainException(message);
    }

    public static void ValidarSeFalso(bool value, string message)
    {
        if (value)
            throw new DomainException(message);
    }

    public static void ValidarSeVerdadeiro(bool value, string message)
    {
        if (!value)
            throw new DomainException(message);
    }
}