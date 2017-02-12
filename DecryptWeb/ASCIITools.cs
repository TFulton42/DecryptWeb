using System;
using System.Text;

namespace DecryptWeb
{
    public class AsciiTools
    {
        public static string DecimalToAscii(string inStr)
        {
            var outStr = new StringBuilder();
            var num = 0;

            foreach (var c in inStr)
            {
                if (c == 10 || c == 13)
                    continue;
                if (c == ' ')
                {
                    if (char.IsControl((char) num))
                    {
                        outStr.Append('.');
                    }
                    else
                    {
                        outStr.AppendFormat("{0}", (char) num);
                    }
                    num = 0;
                    continue;
                }
                if (c < '0' || c > '9')
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int) c);
                    break;
                }
                num = num * 10 + (c - '0');
            }
            if (char.IsControl((char) num))
            {
                outStr.Append('.');
            }
            else
            {
                outStr.AppendFormat("{0}", (char) num);
            }
            return outStr.ToString();
        }

        public static string HexToAscii(string inStr)
        {
            var outStr = new StringBuilder();
            var first = true;
            var num = 0;

            foreach (var c in inStr)
            {
                char ch;
                if (c == ' ' || c == 10 || c == 13)
                    continue;
                ch = char.IsLower(c) ? char.ToUpper(c) : c;
                if ((ch < '0' || ch > '9') && (ch < 'A' || ch > 'F'))
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int) ch);
                    break;
                }
                if (first)
                {
                    if (ch >= '0' && ch <= '9')
                        num += (ch - '0') * 16;
                    else if (ch >= 'A' && ch <= 'F')
                        num += (ch - 'A' + 10) * 16;
                    first = false;
                }
                else
                {
                    if (ch >= '0' && ch <= '9')
                        num += c - '0';
                    else if (ch >= 'A' && ch <= 'F')
                        num += ch - 'A' + 10;
                    if (char.IsControl((char) num))
                        outStr.Append('.');
                    else
                        outStr.AppendFormat("{0}", (char) num);
                    first = true;
                    num = 0;
                }
            }
            return outStr.ToString();
        }

        public static string BinaryToAscii(string inStr)
        {
            var outStr = new StringBuilder();
            var num = 0;

            foreach (var c in inStr)
            {
                if (c == 10 || c == 13)
                    continue;
                if (c == ' ')
                {
                    if (char.IsControl((char) num))
                        outStr.Append('.');
                    else
                        outStr.AppendFormat("{0}", (char) num);
                    num = 0;
                    continue;
                }
                if (c < '0' || c > '1')
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int) c);
                    break;
                }
                num = num * 2 + (c - '0');
            }
            if (char.IsControl((char) num))
                outStr.Append('.');
            else
                outStr.AppendFormat("{0}", (char) num);
            return outStr.ToString();
        }

        public static string AsciiToDecimal(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                outStr.AppendFormat("{0} ", (int) c);
            }
            return outStr.ToString();
        }

        public static string AsciiToHex(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                outStr.AppendFormat("{0:X2} ", (int) c);
            }
            return outStr.ToString();
        }

        public static string AsciiToBinary(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                var output = Convert.ToString(c, 2);
                outStr.AppendFormat("{0, 8} ", output);
            }
            return outStr.ToString();
        }

        public static string BinaryToDecimal(string inStr)
        {
            var outStr = new StringBuilder();
            var num = 0;

            foreach (var c in inStr)
            {
                if (c == 10 || c == 13)
                    continue;
                if (c == ' ')
                {
                    outStr.AppendFormat("{0} ", num);
                    num = 0;
                    continue;
                }
                if (c < '0' || c > '1')
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int) c);
                    break;
                }
                num = num * 2 + (c - '0');
            }
            outStr.AppendFormat("{0}", num);
            return outStr.ToString();
        }

        public static string BinaryToHex(string inStr)
        {
            var outStr = new StringBuilder();
            var num = 0;

            foreach (var c in inStr)
            {
                if (c == 10 || c == 13)
                    continue;
                if (c == ' ')
                {
                    outStr.AppendFormat("{0:x2} ", num);
                    num = 0;
                    continue;
                }
                if (c < '0' || c > '1')
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int)c);
                    break;
                }
                num = num * 2 + (c - '0');
            }
            outStr.AppendFormat("{0:x2}", num);
            return outStr.ToString();
        }

        public static string NumberToLetter(string inStr)
        {
            var outStr = new StringBuilder();
            var num = 0;

            foreach (var c in inStr)
            {
                if (c == ' ')
                {
                    outStr.AppendFormat("{0}", (char) (num + 'a' - 1));
                    num = 0;
                    continue;
                }
                if (c < '0' || c > '9')
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int) c);
                    break;
                }
                num = num * 10 + (c - '0');
            }
            outStr.AppendFormat("{0}", (char)(num +'a' -1));
            return outStr.ToString();
        }

        public static string IndexIntoString(string inStr, string key)
        {
            var outStr = new StringBuilder();
            var num = 0;

            foreach (var c in inStr)
            {
                if (c == ' ')
                {
                    if (num > key.Length)
                    {
                        outStr.AppendFormat("Number longer than string length");
                        break;
                    }
                    outStr.AppendFormat("{0}", key[num - 1]);
                    num = 0;
                    continue;
                }
                if (c < '0' || c > '9')
                {
                    outStr.AppendFormat("Illegal character '{0}'", (int)c);
                    break;
                }
                num = num * 10 + (c - '0');
            }
            if (num > key.Length)
                outStr.AppendFormat("Number longer than string length");
            else
                outStr.AppendFormat("{0}", key[num - 1]);
            return outStr.ToString();
        }
    }
}