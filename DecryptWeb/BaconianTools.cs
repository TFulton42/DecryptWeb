using System.Linq;
using System.Text;

namespace DecryptWeb
{
    public class BaconianTools
    {
        public static string BaconianDecode(string inStr, bool twentysixchar)
        {
            var outStr = new StringBuilder();

            for (var i = 0; i < inStr.Length - 4; i += 5)
            {
                while (!char.IsLetter(inStr[i]))
                    i++;
                var num = 0;
                if (char.ToUpper(inStr[i]) == 'B')
                    num += 16;
                if (char.ToUpper(inStr[i+1]) == 'B')
                    num += 8;
                if (char.ToUpper(inStr[i+2]) == 'B')
                    num += 4;
                if (char.ToUpper(inStr[i+3]) == 'B')
                    num += 2;
                if (char.ToUpper(inStr[i+4]) == 'B')
                    num += 1;
                if (twentysixchar)
                    outStr.Append((char) ('a' + num));
                else
                {
                    if (num < 9)
                        outStr.Append((char)('a' + num));
                    else if (num < 20)
                        outStr.Append((char)('a' + num + 1));
                    else
                        outStr.Append((char)('a' + num + 2));
                }
            }

            return outStr.ToString();
        }

        public static string BaconBiliteralDecode(string inStr, bool twentysixchar)
        {
            var outStr = new StringBuilder();

            for (var i = 0; i < inStr.Length - 4; i += 5)
            {
                while (!char.IsLetter(inStr[i]))
                    i++;
                var num = 0;
                if (char.IsUpper(inStr[i]))
                    num += 16;
                if (char.IsUpper(inStr[i+1]))
                    num += 8;
                if (char.IsUpper(inStr[i+2]))
                    num += 4;
                if (char.IsUpper(inStr[i+3]))
                    num += 2;
                if (char.IsUpper(inStr[i+4]))
                    num += 1;
                if (twentysixchar)
                    outStr.Append((char) ('a' + num));
                else
                {
                    if (num < 9)
                        outStr.Append((char) ('a' + num));
                    else if (num < 20)
                        outStr.Append((char) ('a' + num + 1));
                    else
                        outStr.Append((char) ('a' + num + 2));
                }
            }

            return outStr.ToString();
        }

        public static string BaconianEncode(string inStr, bool twentysixchar)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (!char.IsLetter(c))
                    continue;

                var ch = (int) (char.ToUpper(c) - 'A');
                if (!twentysixchar)
                {
                    if (char.ToUpper(c) > 'U')
                        ch -= 2;
                    else if (char.ToUpper(c) > 'I')
                        ch -= 1;
                }

                outStr.Append((ch / 16 == 0) ? 'a' : 'b');
                ch = ch % 16;
                outStr.Append((ch / 8 == 0) ? 'a' : 'b');
                ch = ch % 8;
                outStr.Append((ch / 4 == 0) ? 'a' : 'b');
                ch = ch % 4;
                outStr.Append((ch / 2 == 0) ? 'a' : 'b');
                ch = ch % 2;
                outStr.Append((ch == 0) ? 'a' : 'b');
                outStr.Append(' ');
            }

            return outStr.ToString();
        }

        public static string BaconBiliteralEncode(string inStr, bool twentysixchar)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (!char.IsLetter(c))
                    continue;

                var ch = (int)(char.ToUpper(c) - 'A');
                if (!twentysixchar)
                {
                    if (char.ToUpper(c) > 'U')
                        ch -= 2;
                    else if (char.ToUpper(c) > 'I')
                        ch -= 1;
                }

                outStr.Append((ch / 16 == 0) ? 'a' : 'A');
                ch = ch % 16;
                outStr.Append((ch / 8 == 0) ? 'a' : 'A');
                ch = ch % 8;
                outStr.Append((ch / 4 == 0) ? 'a' : 'A');
                ch = ch % 4;
                outStr.Append((ch / 2 == 0) ? 'a' : 'A');
                ch = ch % 2;
                outStr.Append((ch == 0) ? 'a' : 'A');
                outStr.Append(' ');
            }

            return outStr.ToString();
        }
    }
}