using System.Text;

namespace DecryptWeb
{
    public class RailFence
    {
        public static string RailFenceDecrypt(string inStr, int numRows)
        {
            char[] outStr = new char[inStr.Length + 1];
            var cycleLength = 2 * numRows - 2;
            var offset = cycleLength - 2;
            var index = 0;

            for (var i = 0; i < inStr.Length; i++)
                outStr[i] = '.';

            // First Row
            for (var i = 0; i < inStr.Length; i += cycleLength)
                outStr[i] = inStr[index++];

            // Middle Rows
            for (var i = 2; i <= numRows - 1; i++)
            {
                for (var j = i; j <= inStr.Length; j += cycleLength)
                {
                    outStr[j - 1] = inStr[index++];
                    if (j + offset - 1 < inStr.Length)
                        outStr[j + offset - 1] = inStr[index++];
                }
                offset -= 2;
            }

            // Last Row
            for (var i = numRows - 1; i < inStr.Length; i += cycleLength)
                outStr[i] = inStr[index++];

            return new string(outStr);
        }

        public static string RailFenceEncrypt(string inStr, int numRows)
        {
            var outStr = new StringBuilder();
            var cycleLength = 2 * numRows - 2;
            var offset = cycleLength - 2;

            //outStr.AppendFormat("{0} rows: ", numRows);
            // First Row
            for (var i = 0; i < inStr.Length; i += cycleLength)
                outStr.Append(inStr[i]);

            // Middle Rows
            for (var i = 2; i <= numRows - 1; i++)
            {
                //outStr.Append(' ');
                for (var j = i; j <= inStr.Length; j += cycleLength)
                {
                    outStr.Append(inStr[j - 1]);
                    if (j + offset - 1 < inStr.Length)
                        outStr.Append(inStr[j + offset - 1]);
                }
                offset -= 2;
            }

            //outStr.Append(' ');
            // Last Row
            for (var i = numRows - 1; i < inStr.Length; i += cycleLength)
                outStr.Append(inStr[i]);

            return outStr.ToString();
        }
    }
}