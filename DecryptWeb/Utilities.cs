using System;
using System.Text;

namespace DecryptWeb
{
    public class Utilities
    {
        private static string _origText;

        public static void SaveOriginalText(string text)
        {
            _origText = text;
        }

        public static string RestoreOriginalText()
        {
            return _origText;
        }

        public static string ReverseString(string text)
        {
            var cArray = text.ToCharArray();
            Array.Reverse(cArray);
            return new string(cArray);
        }

        public static string ComputeTextOffset(string inStr, string offsetStr, string startStr)
        {
            var outStr = new StringBuilder();
            var newStr = new StringBuilder();

            var offset = Convert.ToInt32(offsetStr);
            if (offset < 1)
            {
                outStr.AppendFormat("Bad offset value {0}", offsetStr);
                return (outStr.ToString());
            }
            var start = Convert.ToInt32(startStr);
            if (start < 1)
            {
                outStr.AppendFormat("Bad start value {0}", startStr);
                return (outStr.ToString());
            }
            foreach (var c in inStr)
            {
                if (c == 10 || c == 13)
                    continue;
                newStr.Append(c);
            }
            for (var i = start - 1; i < newStr.Length; i += offset)
            {
                outStr.Append(newStr[i]);
            }
            return outStr.ToString();
        }

        public static string OnlyCaps(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
                if (char.IsUpper(c))
                    outStr.Append(c);
            return outStr.ToString();
        }

        public static string OnlyLower(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
                if (char.IsLower(c))
                    outStr.Append(c);
            return outStr.ToString();
        }

        public static string ToCaps(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                    outStr.Append(char.ToUpper(c));
                else
                    outStr.Append(c);
            }
            return outStr.ToString();
        }

        public static string ToLower(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                    outStr.Append(char.ToLower(c));
                else
                    outStr.Append(c);
            }
            return outStr.ToString();
        }

        public static string RemoveSpaces(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (c != ' ')
                    outStr.Append(c);
            }
            return outStr.ToString();
        }

        public static string RemoveAllButLetters(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                    outStr.Append(c);
            }
            return outStr.ToString();
        }

        public static string SumOfLetters(string inStr)
        {
            var outStr = new StringBuilder();
            var sum0 = 0;
            var sum1 = 0;

            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                {
                    var ch = char.ToUpper(c);
                    sum0 += (int) (ch - 'A');
                    sum1 += (int)(ch - 'A') + 1;
                }
            }
            outStr.AppendFormat("A = 0 sum is {0}", sum0).AppendLine();
            outStr.AppendFormat("A = 1 sum is {0}", sum1).AppendLine();
            return outStr.ToString();
        }

        public static string BuildCipherAlphabetFromKey(string inKeyStr, string cipherAlphabet)
        {
            var outStr = new StringBuilder();
            var keyStr = new StringBuilder();
            var used = new bool[26];

            if (cipherAlphabet.Length == 0)
                cipherAlphabet = "abcdefghijklmnopqrstuvwxyz";
            if (cipherAlphabet.Length != 26)
            {
                outStr.AppendFormat("Invalid cipher alphabet length {0}", cipherAlphabet.Length);
                return outStr.ToString();
            }

            // Build alphabet, first strip repeated characters from the key.
            for (var i = 0; i < cipherAlphabet.Length; i++)
                used[i] = false;
            for (var i = 0; i < inKeyStr.Length && i < cipherAlphabet.Length; i++)
            {
                var kc = inKeyStr[i];
                if (!char.IsLetter(kc))
                {
                    outStr.AppendFormat("Illegal character '{0}' at position {1}", (int)kc, i);
                    return (outStr.ToString());
                }
                if (char.IsUpper(kc))
                    kc = char.ToLower(kc);
                if (!used[(int)(kc - 'a')])
                {
                    keyStr.Append(kc);
                    used[(int)(kc - 'a')] = true;
                }
            }

            // Put the key into the encryptAlphabet
            for (var i = 0; i < cipherAlphabet.Length; i++)
                used[i] = false;
            for (var i = 0; i < keyStr.Length && i < cipherAlphabet.Length; i++)
            {
                outStr.Append(keyStr[i]);
                used[cipherAlphabet.ToString().IndexOf(keyStr[i])] = true;
            }

            // Fill out the rest of the encryptAlphabet
            var nextAlpha = 0;
            for (var i = keyStr.Length; i < cipherAlphabet.Length; i++)
            {
                for (int j = nextAlpha; j < cipherAlphabet.Length; j++)
                    if (used[nextAlpha])
                        nextAlpha++;
                outStr.Append(cipherAlphabet[nextAlpha++]);
            }

            return outStr.ToString();
        }

        public static string BuildCipherAlphabetFromKey(string inKeyStr)
        {
            return BuildCipherAlphabetFromKey(inKeyStr, "abcdefghijklmnopqrstuvwxyz");
        }
    }
}