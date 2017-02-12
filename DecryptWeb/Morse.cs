using System;
using System.Text;

namespace DecryptWeb
{
    public class Morse
    {
        public const int MORSELEN = 41;
        private static readonly string[,] morse = new string[MORSELEN, 2] {{"a",".-"},{"b","-..."},{"c","-.-."},{"d","-.."},
                                            {"e","."},{"f","..-."},{"g","--."},{"h","...."},
                                            {"i",".."},{"j",".---"},{"k","-.-"},{"l",".-.."},
                                            {"m","--"},{"n","-."},{"o","---"},{"p",".--."},
                                            {"q","--.-"},{"r",".-."},{"s","..."},{"t","-"},
                                            {"u","..-"},{"v","...-"},{"w",".--"},{"x","-..-"},
                                            {"y","-.--"},{"z","--.."},{".",".-.-.-"},{",","--..--"},
                                            {"?","..--.."},{"/","-..-."},{"@",".--.-."},{"0","-----"},{"1",".----"},
                                            {"2","..---"},{"3","...--"},{"4","....-"},{"5","....."},
                                            {"6","-...."},{"7","--..."},{"8","---.."},{"9","----."}};
        private static readonly string[] fractionatedMorse = new string[26] {"...", "..-", "..X", ".-.", ".--", ".-X", ".X.", ".X-",
                                            ".XX", "-..", "-.-", "-.X", "--.", "---", "--X", "-X.",
                                            "-X-", "-XX", "X..", "X.-", "X.X", "X-.", "X--", "X-X",
                                            "XX.", "XX-"};

        public static string MorseCodeDecrypt(string inStr)
        {
            var outStr = new StringBuilder();
            var codeSegment = new StringBuilder();
            var inStrPtr = 0;
            var codeSegmentLen = 0;

            while (inStrPtr < inStr.Length)
            {
                // If the next character is a . or -, add it to the code segment.
                var c = inStr[inStrPtr];
                if (c == '.' || c == '-')
                {
                    codeSegment.Append(c);
                    codeSegmentLen++;
                }
                else
                {
                    // If next character is not a . or -, terminate the code segment and decrypt if it's not 0 length.
                    // Also restart the code segment.
                    if (codeSegmentLen != 0)
                    {
                        for (var i = 0; i < MORSELEN; i++)
                        {
                            if (string.Equals(codeSegment.ToString(), morse[i, 1]))
                            {
                                outStr.Append(morse[i, 0]);
                                break;
                            }
                        }
                        codeSegment.Length = 0;
                    }
                }
                inStrPtr++;
            }
            if (codeSegmentLen != 0)
            {
                for (var i = 0; i < MORSELEN; i++)
                {
                    if (string.Equals(codeSegment.ToString(), morse[i, 1]))
                    {
                        outStr.Append(morse[i, 0]);
                        break;
                    }
                }
            }
            return outStr.ToString();
        }

        public static string MorseCodeEncrypt(string inStr)
        {
            var outStr = new StringBuilder();

            foreach (var c in inStr)
            {
                if (char.IsLetter(c))
                {
                    outStr.Append(morse[char.ToLower(c) - 'a', 1]);
                }
                else if (char.IsNumber(c))
                {
                    outStr.Append(morse[c - '0' + 31, 1]);
                }
                else
                {
                    for (int j = 26; j < 32; j++)
                    {
                        if (c == morse[j, 0][0])
                            outStr.Append(morse[j, 1]);
                    }
                }
                outStr.Append(" ");
            }
            return outStr.ToString();
        }

        public static string FracMorseCodeDecrypt(string inStr, string inKeyStr)
        {
            var outStr = new StringBuilder();
            var morseStr = new StringBuilder();
            string cipherAlphabet;
            var mapping = new int[26];
            char c;

            if (inKeyStr.Length == 0)
            {
                outStr.AppendFormat("Key must be greater than 0 characters");
                return outStr.ToString();
            }

            // Build cipher alphabet from key
            cipherAlphabet = Utilities.BuildCipherAlphabetFromKey(inKeyStr);
            for (var i = 0; i < 26; i++)
                mapping[(int) (cipherAlphabet[i] - 'a')] = i;

            // Create Morse string
            for (var i = 0; i < inStr.Length; i++)
            {
                if (!char.IsLetter(c = inStr[i]))
                    continue;
                if (char.IsUpper(c))
                    c = char.ToLower(c);
                morseStr.Append(fractionatedMorse[mapping[(int) (c - 'a')]]);
            }

            // Replace the X's with ' ' and decode the morse
            for (var i = 0; i < morseStr.Length; i++)
            {
                if (morseStr[i] == 'X')
                    morseStr[i] = ' ';
            }
            outStr.Append(MorseCodeDecrypt(morseStr.ToString()));

            return outStr.ToString();
        }

        public static string FracMorseCodeEncrypt(string inStr, string inKeyStr)
        {
            var outStr = new StringBuilder();
            var morseStr = new StringBuilder();
            var mapping = new int[26];
            string cipherAlphabet;
            char c;
            var dblX = false;
            var cnt = 0;

            if (inKeyStr.Length == 0)
            {
                outStr.AppendFormat("Key must be greater than 0 characters");
                return outStr.ToString();
            }

            // Build the Morse string
            for (var i = 0; i < inStr.Length; i++)
            {
                if (char.IsLetter(c = inStr[i]))
                {
                    if (char.IsUpper(c))
                        c = char.ToLower(c);
                    morseStr.Append(morse[c - 'a', 1]);
                    morseStr.Append('X');
                    dblX = false;
                }
                else if (char.IsNumber(c))
                {
                    morseStr.Append(morse[c - '0' + 31, 1]);
                    morseStr.Append('X');
                    dblX = false;
                }
                else
                {
                    if (!dblX)
                        morseStr.Append('X');
                    dblX = true;
                }
            }
            if (!dblX)
                morseStr.Append('X');

            // Build cipher alphabet from key
            cipherAlphabet = Utilities.BuildCipherAlphabetFromKey(inKeyStr);
            for (var i = 0; i < 26; i++)
                mapping[i] = (int)(cipherAlphabet[i] - 'a');

            // Encrypt message
            for (var i = 0; i < morseStr.Length - 2; i += 3)
            {
                for (int j = 0; j < 26; j++)
                {
                    //outStr.AppendFormat("{0}{1}{2} = ", morseStr[i], morseStr[i + 1], morseStr[i + 2]);
                    if (morseStr[i] == fractionatedMorse[j][0] &&
                        morseStr[i + 1] == fractionatedMorse[j][1] &&
                        morseStr[i + 2] == fractionatedMorse[j][2])
                    {
                        //outStr.AppendFormat("{0}: mapping = {1}", fractionatedMorse[j], mapping[j]).AppendLine();
                        outStr.Append((char)(mapping[j] + 'a'));
                        cnt++;
                        if (cnt == 5)
                        {
                            outStr.Append(' ');
                            cnt = 0;
                        }
                        continue;
                    }
                }
            }

            return outStr.ToString();
        }
    }
}