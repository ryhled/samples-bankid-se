using System.Text;

namespace Samples.BankId.SE.Extensions
{
    public static class StringExtensions
    {
        public static string Encode(this string raw) => Convert.ToBase64String(Encoding.UTF8.GetBytes(raw));

        public static string Decode(this string endcoded) => Encoding.UTF8.GetString(Convert.FromBase64String(endcoded));
    }
}
