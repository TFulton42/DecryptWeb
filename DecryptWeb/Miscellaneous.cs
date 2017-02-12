using System.Text;

namespace DecryptWeb
{
    public class Miscellaneous
    {
//        private static char[,] _typewriter = new char[10, 10] {{'*','0','p',';','/',' ','*','*','*','*'},
//                                              {'*','1','q','a','z',' ','*','*','*','*'},
//                                              {'*','2','w','s','x',' ','*','*','*','*'},
//                                              {'*','3','e','d','c',' ','*','*','*','*'},
//                                              {'*','4','r','f','v',' ','*','*','*','*'},
//                                              {'*','5','t','g','b',' ','*','*','*','*'},
//                                              {'*','6','y','h','n',' ','*','*','*','*'},
//                                              {'*','7','u','j','m',' ','*','*','*','*'},
//                                              {'*','8','i','k',',',' ','*','*','*','*'},
//                                              {'*','9','o','l','.',' ','*','*','*','*'}};

        public static string KeywordCipherDecode(string inStr, string inKeyStr, string inCipherAlphabet)
            // Right now, the key is required to be alphabetic.
        {
            var outStr = new StringBuilder();
            var cipherAlphabet = new StringBuilder();
            char[] decryptAlphabet = new char[inCipherAlphabet.Length == 0 ? 26 : inCipherAlphabet.Length];

            if (inCipherAlphabet.Length != 0)
            {
                if (inCipherAlphabet.Length < 26)
                {
                    outStr.AppendFormat("Cipher alphabet insufficient (too short).");
                    return outStr.ToString();
                }
                foreach (var c in inCipherAlphabet)
                {
                    if (char.IsUpper(c))
                        cipherAlphabet.Append(char.ToLower(c));
                    else
                        cipherAlphabet.Append(c);
                }
            }
            else
            {
                cipherAlphabet.Append("abcdefghijklmnopqrstuvwxyz");
            }

            var encryptAlphabet = Utilities.BuildCipherAlphabetFromKey(inKeyStr, inCipherAlphabet);

            // Build the decryption alphabet
            for (var i = 0; i < cipherAlphabet.Length; i++)
                decryptAlphabet[cipherAlphabet.ToString().IndexOf(encryptAlphabet[i])] = cipherAlphabet[i];

            // Finally decrypt the message
            foreach (var c in inStr)
            {
                var kc = char.ToLower(c);
                if (cipherAlphabet.ToString().IndexOf(kc) < 0)
                    outStr.Append(kc);
                else
                    outStr.Append(decryptAlphabet[cipherAlphabet.ToString().IndexOf(kc)]);
            }

            return outStr.ToString();
        }

        public static string KeywordCipherEncode(string inStr, string inKeyStr, string inCipherAlphabet)
            // Right now, the key is required to be alphabetic.
        {
            var outStr = new StringBuilder();
            var cipherAlphabet = new StringBuilder();

            if (inCipherAlphabet.Length != 0)
            {
                if (inCipherAlphabet.Length < 26)
                {
                    outStr.AppendFormat("Cipher alphabet insufficient (too short).");
                    return outStr.ToString();
                }
                foreach (var c in inCipherAlphabet)
                {
                    if (char.IsUpper(c))
                        cipherAlphabet.Append(char.ToLower(c));
                    else
                        cipherAlphabet.Append(c);
                }
            }
            else
            {
                cipherAlphabet.Append("abcdefghijklmnopqrstuvwxyz");
            }
            var encryptAlphabet = Utilities.BuildCipherAlphabetFromKey(inKeyStr, inCipherAlphabet);


            for (var i = 0; i < inStr.Length; i++)
            {
                char c = inStr[i];
                if (char.IsUpper(c))
                    c = char.ToLower(c);
                if (cipherAlphabet.ToString().IndexOf(c) < 0)
                {
                    outStr.Append(c);
                }
                else
                {
                    outStr.Append(encryptAlphabet[cipherAlphabet.ToString().IndexOf(c)]);
                }
            }

            return outStr.ToString();
        }

//        public static string BasicTypewriteDecrypt(string inStr)
//        {
//            var outStr = new StringBuilder();
//            var first = true;
//            var x = 0;
//            var y = 0;
//
//            foreach (var c in inStr)
//            {
//                if (c == 10 || c == 13)
//                    continue;
//                if (c < '0' || c > '9')
//                {
//                    outStr.AppendFormat("Illegal character {0}", (int) c);
//                    return outStr.ToString();
//                }
//                if (first)
//                {
//                    x = (int) (c - '0');
//                    first = false;
//                }
//                else
//                {
//                    y = (int) (c - '0');
//                    outStr.Append(_typewriter[x, y]);
//                    first = true;
//                }
//            }
//            return outStr.ToString();
//        }
    }
}