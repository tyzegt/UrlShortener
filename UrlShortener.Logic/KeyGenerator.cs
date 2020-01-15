using System;
using System.IO;
using System.Text.RegularExpressions;

namespace UrlShortener.Logic
{
    public static class KeyGenerator
    {
        public static string GetRandomKey()
        {
            string randomString = Regex.Replace(Path.GetRandomFileName(), @"[^a-z0-9]", "");
            return randomString.Substring(0, Options.MAX_KEY_LENGTH);
        }
    }
}
