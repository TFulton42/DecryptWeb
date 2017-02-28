using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;

namespace DecryptWeb
{
    public class Playfair
    {
        struct KeyTableType
        {
            public int row, col;
        }

        private static readonly KeyTableType[] _keyTable = new KeyTableType[26];

        private static void BuildPlayfairKey(string keyStr)
        {
            var used = new Boolean[26];
            var rowIndex = 0;
            var colIndex = 0;

            for (var i = 0; i < 26; i++)
                used[i] = false;

            // Mark the entries for J as unused.
            _keyTable['J' - 'A'].row = -1;
            _keyTable['J' - 'A'].col = -1;

            // Build key table - start with the input key
            foreach (var c in keyStr)
            {
                if (!char.IsLetter(c))
                    continue;
                var keyChar = char.ToUpper(c);

                // Map J to I
                if (keyChar == 'J')
                    keyChar = 'I';

                if (used[(int) (keyChar - 'A')])
                    continue;
                used[(int) (keyChar - 'A')] = true;
                _keyTable[(int) (keyChar - 'A')].col = colIndex++;
                _keyTable[(int) (keyChar - 'A')].row = rowIndex;

                if (colIndex == 5)
                {
                    colIndex = 0;
                    rowIndex++;
                }
            }

            // finish with the rest of the alphabet
            for (var i = 0; i < 26; i++)
            {
                if ((int) (i + 'A') == 'J')
                    continue;
                if (!used[i])
                {
                    _keyTable[i].col = colIndex++;
                    _keyTable[i].row = rowIndex;

                    if (colIndex == 5)
                    {
                        colIndex = 0;
                        rowIndex++;
                    }
                }
            }
        }

        public static string PrintKeyTable(string keyStr)
        {
            var outStr = new StringBuilder();

            BuildPlayfairKey(keyStr);

            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    for (var k = 0; k < 26; k++)
                    {
                        if (_keyTable[k].col == j && _keyTable[k].row == i)
                        {
                            outStr.AppendFormat("{0} ", (char) ('A' + k));
                        }
                    }
                }
                outStr.AppendLine();
            }

            return outStr.ToString();
        }

        public static string PlayfairDecrypt(string inStr, string keyStr)
        {
            var outStr = new StringBuilder();
            var inStrIndex = 0;
            int index2;
            int index1;

            BuildPlayfairKey(keyStr);

            while (inStrIndex < inStr.Length)
            {
                if (!char.IsLetter(inStr[inStrIndex]))
                {
                    inStrIndex++;
                    continue;
                }
                var c1 = char.ToUpper(inStr[inStrIndex++]) - 'A';
                if (c1 == 'J' - 'A')
                    c1 = 'I' - 'A';
                while (inStrIndex < inStr.Length && !char.IsLetter(inStr[inStrIndex]))
                    inStrIndex++;
                if (inStrIndex >= inStr.Length)
                    break;
                var c2 = char.ToUpper(inStr[inStrIndex++]) - 'A';
                if (c2 == 'J' - 'A')
                    c2 = 'I' - 'A';

                if (_keyTable[c1].row == _keyTable[c2].row)
                {
                    if (_keyTable[c1].col == 0)
                        index2 = 4;
                    else
                        index2 = _keyTable[c1].col - 1;
                    index1 = _keyTable[c1].row;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            break;
                        }
                    if (_keyTable[c2].col == 0)
                        index2 = 4;
                    else
                        index2 = _keyTable[c2].col - 1;
                    index1 = _keyTable[c2].row;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            break;
                        }
                }
                else if (_keyTable[c1].col == _keyTable[c2].col)
                {
                    if (_keyTable[c1].row == 0)
                        index1 = 4;
                    else
                        index1 = _keyTable[c1].row - 1;
                    index2 = _keyTable[c1].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char) (i + 'a'));
                            break;
                        }
                    if (_keyTable[c2].row == 0)
                        index1 = 4;
                    else
                        index1 = _keyTable[c2].row - 1;
                    index2 = _keyTable[c2].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char) (i + 'a'));
                            break;
                        }
                }
                else
                {
                    index1 = _keyTable[c1].row;
                    index2 = _keyTable[c2].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char) (i + 'a'));
                            break;
                        }
                    index1 = _keyTable[c2].row;
                    index2 = _keyTable[c1].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char) (i + 'a'));
                            break;
                        }
                }
            }

            return outStr.ToString();
        }

        public static string PlayfairEncrypt(string inStr, string keyStr)
        {
            var outStr = new StringBuilder();
            int inStrIndex = 0;
            int index1;
            int index2;

            BuildPlayfairKey(keyStr);

            while (inStrIndex < inStr.Length)
            {
                if (!char.IsLetter(inStr[inStrIndex]))
                {
                    inStrIndex++;
                    continue;
                }
                var c1 = char.ToUpper(inStr[inStrIndex++]) - 'A';
                if (c1 == 'J' - 'A')
                    c1 = 'I' - 'A';
                while (inStrIndex < inStr.Length && !Char.IsLetter(inStr[inStrIndex]))
                    inStrIndex++;
                int c2;
                if (inStrIndex >= inStr.Length)
                    c2 = 'X' - 'A';
                else
                    c2 = char.ToUpper(inStr[inStrIndex++]) - 'A';
                if (c2 == 'J' - 'A')
                    c2 = 'I' - 'A';
                if (c1 == c2) // Have to add a pad since the characters are the same.
                {
                    if (c1 == 'X' - 'A')
                        c2 = 'Y' - 'A';
                    else
                        c2 = 'X' - 'A';
                    inStrIndex--;
                }
                if (_keyTable[c1].row == _keyTable[c2].row)
                {
                    if (_keyTable[c1].col == 4)
                        index2 = 0;
                    else
                        index2 = _keyTable[c1].col + 1;
                    index1 = _keyTable[c1].row;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            break;
                        }
                    if (_keyTable[c2].col == 4)
                        index2 = 0;
                    else
                        index2 = _keyTable[c2].col + 1;
                    index1 = _keyTable[c2].row;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            outStr.Append(' ');
                            break;
                        }
                }
                else if (_keyTable[c1].col == _keyTable[c2].col)
                {
                    if (_keyTable[c1].row == 4)
                        index1 = 0;
                    else
                        index1 = _keyTable[c1].row + 1;
                    index2 = _keyTable[c1].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            break;
                        }
                    if (_keyTable[c2].row == 4)
                        index1 = 0;
                    else
                        index1 = _keyTable[c2].row + 1;
                    index2 = _keyTable[c2].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            outStr.Append(' ');
                            break;
                        }
                }
                else
                {
                    index1 = _keyTable[c1].row;
                    index2 = _keyTable[c2].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            break;
                        }
                    index1 = _keyTable[c2].row;
                    index2 = _keyTable[c1].col;
                    for (var i = 0; i < 26; i++)
                        if (_keyTable[i].row == index1 && _keyTable[i].col == index2)
                        {
                            outStr.Append((char)(i + 'a'));
                            outStr.Append(' ');
                            break;
                        }
                }
            }

            return outStr.ToString();
        }
    }
}