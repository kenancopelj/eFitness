using System.Security.Cryptography;

namespace eFitnessAPI.Helper
{
    public static class Fajlovi
    {

        public static void Snimi(this byte[] nova_slika, string filename)
        {
            //string Nova = Ekstenzije.ToBase64(nova_slika);
            //byte[] nova2 = Ekstenzije.parseBase64(Nova);
            using var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            fs.Write(nova_slika, 0, nova_slika.Length);
        }

        public static byte[] Ucitaj(string path)
        {
            try
            {
                return System.IO.File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
