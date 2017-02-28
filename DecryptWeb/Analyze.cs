using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecryptWeb
{
    public class Analyze
    {
        private static string[] _words;
        private const int PositiveMatchCount = 2;
        private const string Path = @"c:\Users\tfult\Documents\Visual Studio 2015\Projects\DecryptWeb\library.txt";
        private const Boolean FullRun = false;

        public class DecryptObj
        {
            public string Key;
            public int NumMatches;
            public string DecryptStr;

            public DecryptObj(string foundKey, int foundNumMatches, string foundDecryptStr)
            {
                this.Key = foundKey;
                this.NumMatches = foundNumMatches;
                this.DecryptStr = foundDecryptStr;
            }

        }

        public class DecryptObjList
        {
            private static readonly List<DecryptObj> DecryptList = new List<DecryptObj>();

            public DecryptObjList()
            {
                DecryptList.Clear();
            }

            public static void AddObj(DecryptObj obj)
            {
                DecryptList.Add(obj);
            }

            public string BuildList()
            {
                var outStr = new StringBuilder();

                DecryptList.Sort((x, y) => y.NumMatches.CompareTo(x.NumMatches));

                foreach (var item in DecryptList)
                {
                    outStr.AppendFormat("{0} (Number of matches {1}): {2}\n", item.Key, item.NumMatches, item.DecryptStr);
                }
                return outStr.ToString() + "\nDone.";
            }
        }

        public static int InitializeModule()
        {
            var count = ReadLibrary();
            return count;
        }

        public static int ReadLibrary()
        {
            if (!File.Exists(Path))
                return 0;
            var text = File.ReadAllText(Path);
            _words = text.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            return _words.Length;
        }

        public static int NumberOfLibraryMatches(string inStr)
        {
            var count = 0;

            foreach (var word in _words)
            {
                if (inStr.ToLower().IndexOf(word, StringComparison.Ordinal) >= 0)
                    count++;
            }

            return count;
        }

        public static string AnalyzeNoKey(string inStr)
        {
            var decryptList = new DecryptObjList();

            for (var i = 1; i < 26; i++)
            {
                var decryptStr = CaesarTools.RotNDecrypt(i, inStr);
                var count = NumberOfLibraryMatches(decryptStr);
                if (count >= PositiveMatchCount)
                {
                    var keyStr = "ROT-" + i;
                    DecryptObjList.AddObj(new DecryptObj(keyStr, count, decryptStr));
                }
            }
            return decryptList.BuildList();
        }

        public static string AnalyzeKeyGuess(string inStr, string keyGuess)
        {
            var outStr = new StringBuilder();
            var count = 0;
            var decryptList = new DecryptObjList();

            // Try Vigenere
            var decryptStr = Vigenere.VigenereDecode(inStr, keyGuess);
            count = NumberOfLibraryMatches(decryptStr);
            if (count >= PositiveMatchCount)
                DecryptObjList.AddObj(new DecryptObj("Vigenere", count, decryptStr));

            // Try Fractionated Morse
            decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyGuess);
            count = NumberOfLibraryMatches(decryptStr);
            if (count >= PositiveMatchCount)
                DecryptObjList.AddObj(new DecryptObj("Fractionated Morse", count, decryptStr));

            // Try Keyword
            decryptStr = Miscellaneous.KeywordCipherDecode(inStr, keyGuess, "");
            count = NumberOfLibraryMatches(decryptStr);
            if (count >= PositiveMatchCount)
                DecryptObjList.AddObj(new DecryptObj("Keyword", count, decryptStr));

            // Try Playfair
            decryptStr = Playfair.PlayfairDecrypt(inStr, keyGuess);
            count = NumberOfLibraryMatches(decryptStr);
            if (count >= PositiveMatchCount)
                DecryptObjList.AddObj(new DecryptObj("Playfair", count, decryptStr));

            return decryptList.BuildList();
        }

        public static string VigenereKeyBruteForce(string inStr)
        {
            var outStr = new StringBuilder();
            var keyStr = new StringBuilder();
            var count = 0;
            var decryptList = new DecryptObjList();

            // 1 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                keyStr.Length = 0;
                keyStr.Append((char) ('a' + i1));
                var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                count = NumberOfLibraryMatches(decryptStr);
                if (count >= PositiveMatchCount)
                {
                    DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                }
            }

            // 2 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                for (var i2 = 0; i2 < 26; i2++)
                {
                    keyStr.Length = 0;
                    keyStr.AppendFormat("{0}{1}", (char) ('a' + i1), (char)('a' + i2));
                    var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                    count = NumberOfLibraryMatches(decryptStr);
                    if (count >= PositiveMatchCount)
                    {
                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                    }
                }
            }

            // 3 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                for (var i2 = 0; i2 < 26; i2++)
                {
                    for (var i3 = 3; i3 < 26; i3++)
                    {
                        keyStr.Length = 0;
                        keyStr.AppendFormat("{0}{1}{2}", (char) ('a' + i1), (char) ('a' + i2), (char)('a' + i3));
                        var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                        count = NumberOfLibraryMatches(decryptStr);
                        if (count >= PositiveMatchCount)
                        {
                            DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                        }
                    }
                }
            }

            // 4 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                for (var i2 = 0; i2 < 26; i2++)
                {
                    for (var i3 = 0; i3 < 26; i3++)
                    {
                        for (var i4 = 0; i4 < 26; i4++)
                        {
                            keyStr.Length = 0;
                            keyStr.AppendFormat("{0}{1}{2}{3}", (char) ('a' + i1), (char) ('a' + i2), (char) ('a' + i3),
                                (char) ('a' + i4));
                            var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                            count = NumberOfLibraryMatches(decryptStr);
                            if (count >= PositiveMatchCount)
                            {
                                DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                            }
                        }
                    }
                }
            }

            if (FullRun)
            {
                // 5 letter keys
                for (var i1 = 0; i1 < 26; i1++)
                {
                    for (var i2 = 0; i2 < 26; i2++)
                    {
                        for (var i3 = 0; i3 < 26; i3++)
                        {
                            for (var i4 = 0; i4 < 26; i4++)
                            {
                                for (var i5 = 0; i5 < 26; i5++)
                                {
                                    keyStr.Length = 0;
                                    keyStr.AppendFormat("{0}{1}{2}{3}{4}", (char) ('a' + i1), (char) ('a' + i2),
                                        (char) ('a' + i3), (char) ('a' + i4), (char) ('a' + i5));
                                    var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                                    count = NumberOfLibraryMatches(decryptStr);
                                    if (count >= PositiveMatchCount)
                                    {
                                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                                    }
                                }
                            }
                        }
                    }
                }

                // 6 letter keys - 5 letters and x
                for (var i1 = 0; i1 < 26; i1++)
                {
                    for (var i2 = 0; i2 < 26; i2++)
                    {
                        for (var i3 = 0; i3 < 26; i3++)
                        {
                            for (var i4 = 0; i4 < 26; i4++)
                            {
                                for (var i5 = 0; i5 < 26; i5++)
                                {
                                    keyStr.Length = 0;
                                    keyStr.AppendFormat("{0}{1}{2}{3}{4}x", (char) ('a' + i1), (char) ('a' + i2),
                                        (char) ('a' + i3), (char) ('a' + i4), (char) ('a' + i5));
                                    var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                                    count = NumberOfLibraryMatches(decryptStr);
                                    if (count >= PositiveMatchCount)
                                    {
                                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                                    }
                                }
                            }
                        }
                    }
                }

                // 7 letter keys - 5 letters and xx
                for (var i1 = 0; i1 < 26; i1++)
                {
                    for (var i2 = 0; i2 < 26; i2++)
                    {
                        for (var i3 = 0; i3 < 26; i3++)
                        {
                            for (var i4 = 0; i4 < 26; i4++)
                            {
                                for (var i5 = 0; i5 < 26; i5++)
                                {
                                    keyStr.Length = 0;
                                    keyStr.AppendFormat("{0}{1}{2}{3}{4}xx", (char) ('a' + i1), (char) ('a' + i2),
                                        (char) ('a' + i3), (char) ('a' + i4), (char) ('a' + i5));
                                    var decryptStr = Vigenere.VigenereDecode(inStr, keyStr.ToString());
                                    count = NumberOfLibraryMatches(decryptStr);
                                    if (count >= PositiveMatchCount)
                                    {
                                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return decryptList.BuildList();
        }

        public static string FracMorseKeyBruteForce(string inStr)
        {
            var outStr = new StringBuilder();
            var keyStr = new StringBuilder();
            var count = 0;
            var decryptList = new DecryptObjList();

            // 1 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                keyStr.Length = 0;
                keyStr.Append((char)('a' + i1));
                var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                count = NumberOfLibraryMatches(decryptStr);
                if (count >= PositiveMatchCount)
                {
                    DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                }
            }

            // 2 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                for (var i2 = 0; i2 < 26; i2++)
                {
                    keyStr.Length = 0;
                    keyStr.AppendFormat("{0}{1}", (char)('a' + i1), (char)('a' + i2));
                    var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                    count = NumberOfLibraryMatches(decryptStr);
                    if (count >= PositiveMatchCount)
                    {
                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                    }
                }
            }

            // 3 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                for (var i2 = 0; i2 < 26; i2++)
                {
                    for (var i3 = 3; i3 < 26; i3++)
                    {
                        keyStr.Length = 0;
                        keyStr.AppendFormat("{0}{1}{2}", (char)('a' + i1), (char)('a' + i2), (char)('a' + i3));
                        var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                        count = NumberOfLibraryMatches(decryptStr);
                        if (count >= PositiveMatchCount)
                        {
                            DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                        }
                    }
                }
            }

            // 4 letter keys
            for (var i1 = 0; i1 < 26; i1++)
            {
                for (var i2 = 0; i2 < 26; i2++)
                {
                    for (var i3 = 0; i3 < 26; i3++)
                    {
                        for (var i4 = 0; i4 < 26; i4++)
                        {
                            keyStr.Length = 0;
                            keyStr.AppendFormat("{0}{1}{2}{3}", (char)('a' + i1), (char)('a' + i2), (char)('a' + i3),
                                (char)('a' + i4));
                            var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                            count = NumberOfLibraryMatches(decryptStr);
                            if (count >= PositiveMatchCount)
                            {
                                DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                            }
                        }
                    }
                }
            }

            if (FullRun)
            {
                // 5 letter keys
                for (var i1 = 0; i1 < 26; i1++)
                {
                    for (var i2 = 0; i2 < 26; i2++)
                    {
                        for (var i3 = 0; i3 < 26; i3++)
                        {
                            for (var i4 = 0; i4 < 26; i4++)
                            {
                                for (var i5 = 0; i5 < 26; i5++)
                                {
                                    keyStr.Length = 0;
                                    keyStr.AppendFormat("{0}{1}{2}{3}{4}", (char)('a' + i1), (char)('a' + i2),
                                        (char)('a' + i3), (char)('a' + i4), (char)('a' + i5));
                                    var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                                    count = NumberOfLibraryMatches(decryptStr);
                                    if (count >= PositiveMatchCount)
                                    {
                                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                                    }
                                }
                            }
                        }
                    }
                }

                // 6 letter keys - 5 letters and x
                for (var i1 = 0; i1 < 26; i1++)
                {
                    for (var i2 = 0; i2 < 26; i2++)
                    {
                        for (var i3 = 0; i3 < 26; i3++)
                        {
                            for (var i4 = 0; i4 < 26; i4++)
                            {
                                for (var i5 = 0; i5 < 26; i5++)
                                {
                                    keyStr.Length = 0;
                                    keyStr.AppendFormat("{0}{1}{2}{3}{4}x", (char)('a' + i1), (char)('a' + i2),
                                        (char)('a' + i3), (char)('a' + i4), (char)('a' + i5));
                                    var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                                    count = NumberOfLibraryMatches(decryptStr);
                                    if (count >= PositiveMatchCount)
                                    {
                                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                                    }
                                }
                            }
                        }
                    }
                }

                // 7 letter keys - 5 letters and xx
                for (var i1 = 0; i1 < 26; i1++)
                {
                    for (var i2 = 0; i2 < 26; i2++)
                    {
                        for (var i3 = 0; i3 < 26; i3++)
                        {
                            for (var i4 = 0; i4 < 26; i4++)
                            {
                                for (var i5 = 0; i5 < 26; i5++)
                                {
                                    keyStr.Length = 0;
                                    keyStr.AppendFormat("{0}{1}{2}{3}{4}xx", (char)('a' + i1), (char)('a' + i2),
                                        (char)('a' + i3), (char)('a' + i4), (char)('a' + i5));
                                    var decryptStr = Morse.FracMorseCodeDecrypt(inStr, keyStr.ToString());
                                    count = NumberOfLibraryMatches(decryptStr);
                                    if (count >= PositiveMatchCount)
                                    {
                                        DecryptObjList.AddObj(new DecryptObj(keyStr.ToString(), count, decryptStr));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return decryptList.BuildList();
        }
    }
}