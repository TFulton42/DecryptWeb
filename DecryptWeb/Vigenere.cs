using System.Text;

namespace DecryptWeb
{
    public class Vigenere
    {
        public static string VigenereDecode(string inStr, string key)
        {
            var outStr = new StringBuilder();
            var keyIndex = 0;

            if (key.Length == 0)
                return "No Decryption Key";
            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                {
                    var kc = key[keyIndex++];
                    if (keyIndex >= key.Length)
                        keyIndex = 0;
                    if (char.IsUpper(kc))
                        kc = char.ToLower(kc);
                    var offset = kc - 'a';

                    if (char.IsUpper(c))
                    {
                        if (c - offset < 'A')
                            outStr.Append((char)(c - offset + 26));
                        else
                            outStr.Append((char)(c - offset));
                    }
                    else if (char.IsLower(c))
                    {
                        if (c - offset < 'a')
                            outStr.Append((char)(c - offset + 26));
                        else
                            outStr.Append((char)(c - offset));
                    }
                }
                else
                {
                    outStr.Append(c);
                }
            }

            return outStr.ToString();
        }

        public static string VigenereEncode(string inStr, string key)
        {
            var outStr = new StringBuilder();
            var keyIndex = 0;

            if (key.Length == 0)
                return "No Decryption Key";
            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                {
                    var kc = key[keyIndex++];
                    if (keyIndex >= key.Length)
                        keyIndex = 0;
                    if (char.IsUpper(kc))
                        kc = char.ToLower(kc);
                    var offset = kc - 'a';

                    if (char.IsUpper(c))
                    {
                        if (c + offset > 'Z')
                            outStr.Append((char) (c + offset - 26));
                        else
                            outStr.Append((char) (c + offset));
                    }
                    else if (char.IsLower(c))
                    {
                        if (c + offset > 'z')
                            outStr.Append((char)(c + offset - 26));
                        else
                            outStr.Append((char)(c + offset));
                    }
                }
                else
                {
                    outStr.Append(c);
                }
            }
            return outStr.ToString();
        }

        public static string VigenereKeyGuesser(string inStr, string decryptGuess)
        {
            var outStr = new StringBuilder();

            for (var i = 0; i < decryptGuess.Length; i++)
            {
                var c = inStr[i];
                var dc = decryptGuess[i];

                if (char.IsUpper(c))
                    c = char.ToLower(c);
                if (char.IsUpper(dc))
                    dc = char.ToLower(dc);
                if (char.IsLetter(c))
                {
                    c -= 'a';
                    dc -= 'a';
                    var num = (int) (c - dc);
                    if (num < 0)
                        num += 26;
                    outStr.Append((char) (num + 'a'));
                }
                else
                {
                    outStr.Append(c);
                }
            }
            return outStr.ToString();
        }
    }
}