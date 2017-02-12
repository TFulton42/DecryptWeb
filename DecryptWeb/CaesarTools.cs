using System;
using System.Text;

namespace DecryptWeb
{
    public class CaesarTools
    {
        public static string RotNDecrypt(int n, string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (char.IsLower(c))
                {
                    if (c + n <= 'z')
                    {
                        outStr.Append((char) (c + n));
                    }
                    else
                    {
                        outStr.Append((char) (c + n - 26));
                    }
                }
                else if (char.IsUpper(c))
                {
                    if (c + n <= 'Z')
                    {
                        outStr.Append((char) (c + n));
                    }
                    else
                    {
                        outStr.Append((char) (c + n - 26));
                    }
                }
                else
                {
                    outStr.Append(c);
                }
            }
            return (outStr.ToString());
        }

        public static string RotNEncrypt(int n, string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (char.IsLower(c))
                {
                    if (c - n >= 'a')
                    {
                        outStr.Append((char)(c - n));
                    }
                    else
                    {
                        outStr.Append((char)(c - n + 26));
                    }
                }
                else if (char.IsUpper(c))
                {
                    if (c - n >= 'A')
                    {
                        outStr.Append((char)(c - n));
                    }
                    else
                    {
                        outStr.Append((char)(c - n + 26));
                    }
                }
                else
                {
                    outStr.Append(c);
                }
            }
            return (outStr.ToString());
        }

        public static string CaesarBruteforce(string inStr)
        {
            var outStr = new StringBuilder();
            for (var i = 1; i < 26; i++)
            {
                outStr.AppendFormat("ROT-{0}: {1}{2}{2}", i, RotNDecrypt(i, inStr), Environment.NewLine);
            }
            return (outStr.ToString());
        }
    }
}