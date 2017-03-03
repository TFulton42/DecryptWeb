using System.Text;

namespace DecryptWeb
{
    public class OneTimePadTools
    {
        public static string OneTimePadDecrypt(string inStr, string keyStr)
        {
            var outStr = new StringBuilder();
            int keyIdx = 0;
            int c1;

            foreach (var c in inStr)
            {
                if (!char.IsLetter(c))
                    continue;
                while (keyIdx < keyStr.Length && !char.IsLetter(keyStr[keyIdx]))
                    keyIdx++;
                if (keyIdx >= keyStr.Length)
                {
                    outStr.Append('.');
                    continue;
                }
                c1 = ((int) char.ToUpper(c)) - ((int) char.ToUpper(keyStr[keyIdx]));
                if (c1 < 0)
                    c1 += 26;
                outStr.Append((char) (c1 + 'A'));
                keyIdx++;
            }

            return outStr.ToString();
        }

        public static string OneTimePadEncrypt(string inStr, string keyStr)
        {
            var outStr = new StringBuilder();
            int keyIdx = 0;
            int c1;

            foreach (var c in inStr)
            {
                if (!char.IsLetter(c))
                    continue;
                while (keyIdx < keyStr.Length && !char.IsLetter(keyStr[keyIdx]))
                    keyIdx++;
                if (keyIdx >= keyStr.Length)
                {
                    outStr.Append('.');
                    continue;
                }
                c1 = (char.ToUpper(c) - 'A') + (char.ToUpper(keyStr[keyIdx]) - 'A');
                if (c1 >= 26)
                    c1 -= 26;
                //                outStr.AppendFormat("c1 = {0}, c2 = {1}, c3 = {2}, c3+26 = {3}, out = {4}\n",
                //                    (int)char.ToUpper(c), (int)char.ToUpper(keyStr[keyIdx]), c1, c1 + 26, (char) (c1 + 'A'));
                outStr.Append((char) (c1 + 'A'));
                keyIdx++;
            }

            return outStr.ToString();
        }

        public static string OneTimePadKeyGuesser(string inStr, string inGuess)
        {
            var outStr = new StringBuilder();
            int guessIdx = 0;
            int c1;

            foreach (var c in inStr)
            {
                if (!char.IsLetter(c))
                    continue;
                if (guessIdx >= inGuess.Length)
                {
                    outStr.Append('.');
                    continue;
                }
                while (!char.IsLetter(inGuess[guessIdx]))
                    guessIdx++;
                c1 = (char.ToUpper(c)) - (char.ToUpper(inGuess[guessIdx]));
                if (c1 < 0)
                    c1 += 26;
                outStr.Append((char) (c1 + 'A'));
                guessIdx++;
            }

            return outStr.ToString();
        }
    }
}