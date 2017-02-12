using System.Text;

namespace DecryptWeb
{
    public class BaconianTools
    {
        public static string BaconianDecode(string inStr)
        {
            var outStr = new StringBuilder();

            for (var i = 0; i < inStr.Length - 4; i += 5)
            {
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
                outStr.Append((char) ('a' + num));
            }

            return outStr.ToString();
        }

        public static string BaconBiliteralDecode(string inStr)
        {
            var outStr = new StringBuilder();

            for (var i = 0; i < inStr.Length - 4; i += 5)
            {
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
                outStr.Append((char)('a' + num));
            }

            return outStr.ToString();
        }
    }
}