using System.ComponentModel;
using System.Reflection;

namespace JuiceShopAutomation.Maps.Common
{
    public static class ExtensionMethods
    {
        public static string GenerateRandomString(StringType type, int length)
        {
            var allowedChars = type.GetEnumDescription();
            var rnd = new Random(Guid.NewGuid().GetHashCode());

            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedChars[rnd.Next(allowedChars.Length)];
            }

            return new string(chars);
        }

        public static string GenerateRandomEmail()
        {
            return string.Format("{0}@{1}.com", GenerateRandomString(StringType.Alphabets, 10), GenerateRandomString(StringType.Alphabets, 10));
        }

        public static string GenerateSecurePassword(int length)
        {
            if (length < 4)
                throw new ArgumentException("Password length must be at least 4 characters.");

            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digitChars = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            var rnd = new Random(Guid.NewGuid().GetHashCode());

            char[] password = new char[length];
            password[0] = lowerChars[rnd.Next(lowerChars.Length)];
            password[1] = upperChars[rnd.Next(upperChars.Length)];
            password[2] = digitChars[rnd.Next(digitChars.Length)];
            password[3] = specialChars[rnd.Next(specialChars.Length)];

            string allChars = lowerChars + upperChars + digitChars + specialChars;
            for (int i = 4; i < length; i++)
            {
                password[i] = allChars[rnd.Next(allChars.Length)];
            }

            return new string([.. password.OrderBy(_ => rnd.Next())]);
        }

        public static string GetEnumDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }
    }

    public enum StringType
    {
        [Description("abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        Alphabets,
        [Description("123456789")]
        Numerics
    }
}
