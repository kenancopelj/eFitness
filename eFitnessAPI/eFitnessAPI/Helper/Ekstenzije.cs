namespace eFitnessAPI.Helper
{
    public static class Ekstenzije
    {
        public static string ToBase64(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] parseBase64(this string base64)
        {
                base64 = base64.Split(',')[1];
                return Convert.FromBase64String(base64);
        }
    }
}
