using System;
using System.Text;

namespace DecryptWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDowns();
            }
            if (Analyze.InitializeModule() == 0)
                TextBox2.Text = "No words loaded into library";
        }

        public void LoadDropDowns()
        {
            DropDownList1.Items.Clear();
            DropDownList1.Items.Add("Caesar Tools");
            DropDownList1.Items.Add("ASCII Tools");
            DropDownList1.Items.Add("Vigenere Tools");
            DropDownList1.Items.Add("Morse Code Tools");
            DropDownList1.Items.Add("Bacon Ciphers");
            DropDownList1.Items.Add("Miscellaneous Ciphers");
            DropDownList1.Items.Add("Tools");
            DropDownList1.Items.Add("Analyze Code");
            DropDownList1.SelectedIndex = 0;

            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Caesar Bruteforce");
            DropDownList2.Items.Add("ROT-1");
            DropDownList2.Items.Add("ROT-2");
            DropDownList2.Items.Add("ROT-3");
            DropDownList2.Items.Add("ROT-4");
            DropDownList2.Items.Add("ROT-5");
            DropDownList2.Items.Add("ROT-6");
            DropDownList2.Items.Add("ROT-7");
            DropDownList2.Items.Add("ROT-8");
            DropDownList2.Items.Add("ROT-9");
            DropDownList2.Items.Add("ROT-10");
            DropDownList2.Items.Add("ROT-11");
            DropDownList2.Items.Add("ROT-12");
            DropDownList2.Items.Add("ROT-13");
            DropDownList2.Items.Add("ROT-14");
            DropDownList2.Items.Add("ROT-15");
            DropDownList2.Items.Add("ROT-16");
            DropDownList2.Items.Add("ROT-17");
            DropDownList2.Items.Add("ROT-18");
            DropDownList2.Items.Add("ROT-19");
            DropDownList2.Items.Add("ROT-20");
            DropDownList2.Items.Add("ROT-21");
            DropDownList2.Items.Add("ROT-22");
            DropDownList2.Items.Add("ROT-23");
            DropDownList2.Items.Add("ROT-24");
            DropDownList2.Items.Add("ROT-25");
            DropDownList2.SelectedIndex = 13;

            DropDownList3.Items.Clear();
            DropDownList3.Items.Add("Caesar Tools");
            DropDownList3.Items.Add("Vigenere Tools");
            DropDownList3.Items.Add("Morse Code Tools");
            DropDownList3.Items.Add("Bacon Ciphers");
            DropDownList3.Items.Add("Miscellaneous Ciphers");
            DropDownList3.SelectedIndex = 0;

            DropDownList4.Items.Clear();
            DropDownList4.Items.Add("ROT-1");
            DropDownList4.Items.Add("ROT-2");
            DropDownList4.Items.Add("ROT-3");
            DropDownList4.Items.Add("ROT-4");
            DropDownList4.Items.Add("ROT-5");
            DropDownList4.Items.Add("ROT-6");
            DropDownList4.Items.Add("ROT-7");
            DropDownList4.Items.Add("ROT-8");
            DropDownList4.Items.Add("ROT-9");
            DropDownList4.Items.Add("ROT-10");
            DropDownList4.Items.Add("ROT-11");
            DropDownList4.Items.Add("ROT-12");
            DropDownList4.Items.Add("ROT-13");
            DropDownList4.Items.Add("ROT-14");
            DropDownList4.Items.Add("ROT-15");
            DropDownList4.Items.Add("ROT-16");
            DropDownList4.Items.Add("ROT-17");
            DropDownList4.Items.Add("ROT-18");
            DropDownList4.Items.Add("ROT-19");
            DropDownList4.Items.Add("ROT-20");
            DropDownList4.Items.Add("ROT-21");
            DropDownList4.Items.Add("ROT-22");
            DropDownList4.Items.Add("ROT-23");
            DropDownList4.Items.Add("ROT-24");
            DropDownList4.Items.Add("ROT-25");
            DropDownList4.SelectedIndex = 12;

            DropDownList5.Items.Clear();
            DropDownList6.Items.Clear();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int numRows;

            switch (DropDownList1.Text)
            {
                case "Caesar Tools":
                    switch (DropDownList2.Text)
                    {
                        case "ROT-13":
                            TextBox2.Text = CaesarTools.RotNDecrypt(13, TextBox1.Text);
                            break;
                        case "ROT-1":
                            TextBox2.Text = CaesarTools.RotNDecrypt(1, TextBox1.Text);
                            break;
                        case "ROT-2":
                            TextBox2.Text = CaesarTools.RotNDecrypt(2, TextBox1.Text);
                            break;
                        case "ROT-3":
                            TextBox2.Text = CaesarTools.RotNDecrypt(3, TextBox1.Text);
                            break;
                        case "ROT-4":
                            TextBox2.Text = CaesarTools.RotNDecrypt(4, TextBox1.Text);
                            break;
                        case "ROT-5":
                            TextBox2.Text = CaesarTools.RotNDecrypt(5, TextBox1.Text);
                            break;
                        case "ROT-6":
                            TextBox2.Text = CaesarTools.RotNDecrypt(6, TextBox1.Text);
                            break;
                        case "ROT-7":
                            TextBox2.Text = CaesarTools.RotNDecrypt(7, TextBox1.Text);
                            break;
                        case "ROT-8":
                            TextBox2.Text = CaesarTools.RotNDecrypt(8, TextBox1.Text);
                            break;
                        case "ROT-9":
                            TextBox2.Text = CaesarTools.RotNDecrypt(9, TextBox1.Text);
                            break;
                        case "ROT-10":
                            TextBox2.Text = CaesarTools.RotNDecrypt(10, TextBox1.Text);
                            break;
                        case "ROT-11":
                            TextBox2.Text = CaesarTools.RotNDecrypt(11, TextBox1.Text);
                            break;
                        case "ROT-12":
                            TextBox2.Text = CaesarTools.RotNDecrypt(12, TextBox1.Text);
                            break;
                        case "ROT-14":
                            TextBox2.Text = CaesarTools.RotNDecrypt(14, TextBox1.Text);
                            break;
                        case "ROT-15":
                            TextBox2.Text = CaesarTools.RotNDecrypt(15, TextBox1.Text);
                            break;
                        case "ROT-16":
                            TextBox2.Text = CaesarTools.RotNDecrypt(16, TextBox1.Text);
                            break;
                        case "ROT-17":
                            TextBox2.Text = CaesarTools.RotNDecrypt(17, TextBox1.Text);
                            break;
                        case "ROT-18":
                            TextBox2.Text = CaesarTools.RotNDecrypt(18, TextBox1.Text);
                            break;
                        case "ROT-19":
                            TextBox2.Text = CaesarTools.RotNDecrypt(19, TextBox1.Text);
                            break;
                        case "ROT-20":
                            TextBox2.Text = CaesarTools.RotNDecrypt(20, TextBox1.Text);
                            break;
                        case "ROT-21":
                            TextBox2.Text = CaesarTools.RotNDecrypt(21, TextBox1.Text);
                            break;
                        case "ROT-22":
                            TextBox2.Text = CaesarTools.RotNDecrypt(22, TextBox1.Text);
                            break;
                        case "ROT-23":
                            TextBox2.Text = CaesarTools.RotNDecrypt(23, TextBox1.Text);
                            break;
                        case "ROT-24":
                            TextBox2.Text = CaesarTools.RotNDecrypt(24, TextBox1.Text);
                            break;
                        case "ROT-25":
                            TextBox2.Text = CaesarTools.RotNDecrypt(25, TextBox1.Text);
                            break;
                        case "Caesar Bruteforce":
                            TextBox2.Text = CaesarTools.CaesarBruteforce(TextBox1.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown Caesar Tools option";
                            break;
                    }
                    break;
                case "ASCII Tools":
                    switch (DropDownList2.Text)
                    {
                        case "Decimal to ASCII":
                            TextBox2.Text = AsciiTools.DecimalToAscii(TextBox1.Text);
                            break;
                        case "Hex to ASCII":
                            TextBox2.Text = AsciiTools.HexToAscii(TextBox1.Text);
                            break;
                        case "Binary to ASCII":
                            TextBox2.Text = AsciiTools.BinaryToAscii(TextBox1.Text);
                            break;
                        case "ASCII to Decimal":
                            TextBox2.Text = AsciiTools.AsciiToDecimal(TextBox1.Text);
                            break;
                        case "ASCII to Hex":
                            TextBox2.Text = AsciiTools.AsciiToHex(TextBox1.Text);
                            break;
                        case "ASCII to Binary":
                            TextBox2.Text = AsciiTools.AsciiToBinary(TextBox1.Text);
                            break;
                        case "Binary to Decimal":
                            TextBox2.Text = AsciiTools.BinaryToDecimal(TextBox1.Text);
                            break;
                        case "Binary to Hex":
                            TextBox2.Text = AsciiTools.BinaryToHex(TextBox1.Text);
                            break;
                        case "Number to Letter (a = 1)":
                            TextBox2.Text = AsciiTools.NumberToLetter(TextBox1.Text);
                            break;
                        case "Index into String":
                            TextBox2.Text = AsciiTools.IndexIntoString(TextBox1.Text, TextBox3.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown ASCII option";
                            break;
                    }
                    break;
                case "Vigenere Tools":
                    switch (DropDownList2.Text)
                    {
                        case "Vigenere Cipher Decoder":
                            TextBox2.Text = Vigenere.VigenereDecode(TextBox1.Text, TextBox3.Text);
                            break;
                        case "Vigenere Key Guesser":
                            TextBox3.Text = Vigenere.VigenereKeyGuesser(TextBox1.Text, TextBox2.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown Vigenere option";
                            break;
                    }
                    break;
                case "Morse Code Tools":
                    switch (DropDownList2.Text)
                    {
                        case "Morse Code Decrypt":
                            TextBox2.Text = Morse.MorseCodeDecrypt(TextBox1.Text);
                            break;
                        case "Fractionated Morse Decrypt":
                            TextBox2.Text = Morse.FracMorseCodeDecrypt(TextBox1.Text, TextBox3.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown Morse Code option";
                            break;
                    }
                    break;
                case "Bacon Ciphers":
                    switch (DropDownList2.Text)
                    {
                        case "Baconian Cipher":
                            switch (DropDownList5.Text)
                            {
                                case "24 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconianDecode(TextBox1.Text, false);
                                    break;
                                case "26 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconianDecode(TextBox1.Text, true);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Bacon's Biliteral - lower case == A":
                            switch (DropDownList5.Text)
                            {
                                case "24 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconBiliteralDecode(TextBox1.Text, false);
                                    break;
                                case "26 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconBiliteralDecode(TextBox1.Text, true);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            TextBox2.Text = "Unknown Bacon Cipher option";
                            break;
                    }
                    break;
                case "Miscellaneous Ciphers":
                    switch (DropDownList2.Text)
                    {
                        case "Keyword Cipher":
                            TextBox2.Text = Miscellaneous.KeywordCipherDecode(TextBox1.Text, TextBox3.Text, TextBox6.Text);
                            break;
                        case "Playfair Cipher":
                            TextBox2.Text = Playfair.PlayfairDecrypt(TextBox1.Text, TextBox3.Text);
                            break;
                        case "Playfair Key Square":
                            TextBox2.Text = Playfair.PrintKeyTable(TextBox3.Text);
                            break;
                        case "One Time Pad":
                            TextBox2.Text = OneTimePadTools.OneTimePadDecrypt(TextBox1.Text, TextBox3.Text);
                            break;
                        case "One Time Pad Key Guesser":
                            TextBox2.Text = OneTimePadTools.OneTimePadKeyGuesser(TextBox1.Text, TextBox3.Text);
                            break;
                        case "Rail Fence Cipher":
                            numRows = DropDownList5.Text[0] - '0';
                            TextBox2.Text = RailFence.RailFenceDecrypt(TextBox1.Text, numRows);
                            break;
                        default:
                            TextBox2.Text = "Unknown Miscellaneous Code option";
                            break;
                    }
                    break;
                case "Tools":
                    switch (DropDownList2.Text)
                    {
                        case "Reverse String":
                            TextBox2.Text = Utilities.ReverseString(TextBox1.Text);
                            break;
                        case "Text Offset":
                            TextBox2.Text = Utilities.ComputeTextOffset(TextBox1.Text, TextBox4.Text, TextBox5.Text);
                            break;
                        case "Show just CAPS":
                            TextBox2.Text = Utilities.OnlyCaps(TextBox1.Text);
                            break;
                        case "Show just lowercase":
                            TextBox2.Text = Utilities.OnlyLower(TextBox1.Text);
                            break;
                        case "Convert to CAPS":
                            TextBox2.Text = Utilities.ToCaps(TextBox1.Text);
                            break;
                        case "Convert to lowercase":
                            TextBox2.Text = Utilities.ToLower(TextBox1.Text);
                            break;
                        case "Character Count":
                            var outStr = new StringBuilder();
                            outStr.AppendFormat("{0} characters", TextBox1.Text.Length);
                            TextBox2.Text = outStr.ToString();
                            break;
                        case "Remove Spaces":
                            TextBox2.Text = Utilities.RemoveSpaces(TextBox1.Text);
                            break;
                        case "Remove All But Letters":
                            TextBox2.Text = Utilities.RemoveAllButLetters(TextBox1.Text);
                            break;
                        case "Sum of Letters":
                            TextBox2.Text = Utilities.SumOfLetters(TextBox1.Text);
                            break;
                        case "Test Routine":
                            TextBox2.Text = Utilities.BuildCipherAlphabetFromKey(TextBox3.Text, TextBox6.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown option";
                            break;
                    }
                    break;
                case "Analyze Code":
                    switch (DropDownList2.Text)
                    {
                        case "Analyze - No Key":
                            TextBox2.Text = Analyze.AnalyzeNoKey(TextBox1.Text);
                            break;
                        case "Analyze - Key Guess":
                            TextBox2.Text = Analyze.AnalyzeKeyGuess(TextBox1.Text, TextBox3.Text);
                            break;
                        case "Vigenere Key Brute Force":
                            TextBox2.Text = Analyze.VigenereKeyBruteForce(TextBox1.Text);
                            break;
                        case "Fractionated Morse Brute Force":
                            TextBox2.Text = Analyze.FracMorseKeyBruteForce(TextBox1.Text);
                            break;
                        case "Keyword (Standard Alphabet) Brute Force":
                            TextBox2.Text = Analyze.FracMorseKeyBruteForce(TextBox1.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown option";
                            break;
                    }
                    break;
                default:
                    TextBox2.Text = "Unknown option";
                    break;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int numRows;

            switch (DropDownList3.Text)
            {
                case "Caesar Tools":
                    switch (DropDownList4.Text)
                    {
                        case "ROT-13":
                            TextBox2.Text = CaesarTools.RotNEncrypt(13, TextBox1.Text);
                            break;
                        case "ROT-1":
                            TextBox2.Text = CaesarTools.RotNEncrypt(1, TextBox1.Text);
                            break;
                        case "ROT-2":
                            TextBox2.Text = CaesarTools.RotNEncrypt(2, TextBox1.Text);
                            break;
                        case "ROT-3":
                            TextBox2.Text = CaesarTools.RotNEncrypt(3, TextBox1.Text);
                            break;
                        case "ROT-4":
                            TextBox2.Text = CaesarTools.RotNEncrypt(4, TextBox1.Text);
                            break;
                        case "ROT-5":
                            TextBox2.Text = CaesarTools.RotNEncrypt(5, TextBox1.Text);
                            break;
                        case "ROT-6":
                            TextBox2.Text = CaesarTools.RotNEncrypt(6, TextBox1.Text);
                            break;
                        case "ROT-7":
                            TextBox2.Text = CaesarTools.RotNEncrypt(7, TextBox1.Text);
                            break;
                        case "ROT-8":
                            TextBox2.Text = CaesarTools.RotNEncrypt(8, TextBox1.Text);
                            break;
                        case "ROT-9":
                            TextBox2.Text = CaesarTools.RotNEncrypt(9, TextBox1.Text);
                            break;
                        case "ROT-10":
                            TextBox2.Text = CaesarTools.RotNEncrypt(10, TextBox1.Text);
                            break;
                        case "ROT-11":
                            TextBox2.Text = CaesarTools.RotNEncrypt(11, TextBox1.Text);
                            break;
                        case "ROT-12":
                            TextBox2.Text = CaesarTools.RotNEncrypt(12, TextBox1.Text);
                            break;
                        case "ROT-14":
                            TextBox2.Text = CaesarTools.RotNEncrypt(14, TextBox1.Text);
                            break;
                        case "ROT-15":
                            TextBox2.Text = CaesarTools.RotNEncrypt(15, TextBox1.Text);
                            break;
                        case "ROT-16":
                            TextBox2.Text = CaesarTools.RotNEncrypt(16, TextBox1.Text);
                            break;
                        case "ROT-17":
                            TextBox2.Text = CaesarTools.RotNEncrypt(17, TextBox1.Text);
                            break;
                        case "ROT-18":
                            TextBox2.Text = CaesarTools.RotNEncrypt(18, TextBox1.Text);
                            break;
                        case "ROT-19":
                            TextBox2.Text = CaesarTools.RotNEncrypt(19, TextBox1.Text);
                            break;
                        case "ROT-20":
                            TextBox2.Text = CaesarTools.RotNEncrypt(20, TextBox1.Text);
                            break;
                        case "ROT-21":
                            TextBox2.Text = CaesarTools.RotNEncrypt(21, TextBox1.Text);
                            break;
                        case "ROT-22":
                            TextBox2.Text = CaesarTools.RotNEncrypt(22, TextBox1.Text);
                            break;
                        case "ROT-23":
                            TextBox2.Text = CaesarTools.RotNEncrypt(23, TextBox1.Text);
                            break;
                        case "ROT-24":
                            TextBox2.Text = CaesarTools.RotNEncrypt(24, TextBox1.Text);
                            break;
                        case "ROT-25":
                            TextBox2.Text = CaesarTools.RotNEncrypt(25, TextBox1.Text);
                            break;
                        case "Caesar Bruteforce":
                            TextBox2.Text = CaesarTools.CaesarBruteforce(TextBox1.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown Caesar Tools option";
                            break;
                    }
                    break;
                case "Vigenere Tools":
                    switch (DropDownList4.Text)
                    {
                        case "Vigenere Cipher Encoder":
                            TextBox2.Text = Vigenere.VigenereEncode(TextBox1.Text, TextBox3.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown Vigenere Tools option";
                            break;
                    }
                    break;
                case "Morse Code Tools":
                    switch (DropDownList4.Text)
                    {
                        case "Morse Code Encrypt":
                            TextBox2.Text = Morse.MorseCodeEncrypt(TextBox1.Text);
                            break;
                        case "Fractionated Morse Encrypt":
                            TextBox2.Text = Morse.FracMorseCodeEncrypt(TextBox1.Text, TextBox3.Text);
                            break;
                        default:
                            TextBox2.Text = "Unknown Morse Code option";
                            break;
                    }
                    break;
                case "Bacon Ciphers":
                    switch (DropDownList4.Text)
                    {
                        case "Baconian Cipher":
                            switch (DropDownList6.Text)
                            {
                                case "24 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconianEncode(TextBox1.Text, false);
                                    break;
                                case "26 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconianEncode(TextBox1.Text, true);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Bacon's Biliteral - lower case == A":
                            switch (DropDownList6.Text)
                            {
                                case "24 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconBiliteralEncode(TextBox1.Text, false);
                                    break;
                                case "26 letter alphabet":
                                    TextBox2.Text = BaconianTools.BaconBiliteralEncode(TextBox1.Text, true);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            TextBox2.Text = "Unknown Bacon Cipher option";
                            break;
                    }
                    break;
                case "Miscellaneous Ciphers":
                    switch (DropDownList4.Text)
                    {
                        case "Keyword Cipher":
                            TextBox2.Text = Miscellaneous.KeywordCipherEncode(TextBox1.Text, TextBox3.Text, TextBox6.Text);
                            break;
                        case "Playfair Cipher":
                            TextBox2.Text = Playfair.PlayfairEncrypt(TextBox1.Text, TextBox3.Text);
                            break;
                        case "One Time Pad":
                            TextBox2.Text = OneTimePadTools.OneTimePadEncrypt(TextBox1.Text, TextBox3.Text);
                            break;
                        case "Rail Fence Cipher":
                            numRows = DropDownList6.Text[0] - '0';
                            TextBox2.Text = RailFence.RailFenceEncrypt(TextBox1.Text, numRows);
                            break;
                        default:
                            TextBox2.Text = "Unknown Miscellaneous Code option";
                            break;
                    }
                    break;
                default:
                    TextBox2.Text = "Unknown option.";
                    break;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Utilities.SaveOriginalText(TextBox1.Text);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TextBox1.Text = Utilities.RestoreOriginalText();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox2.Text;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList5.Items.Clear();
            switch (DropDownList1.Text)
            {
                case "Caesar Tools":
                    DropDownList2.Items.Add("Caesar Bruteforce");
                    DropDownList2.Items.Add("ROT-1");
                    DropDownList2.Items.Add("ROT-2");
                    DropDownList2.Items.Add("ROT-3");
                    DropDownList2.Items.Add("ROT-4");
                    DropDownList2.Items.Add("ROT-5");
                    DropDownList2.Items.Add("ROT-6");
                    DropDownList2.Items.Add("ROT-7");
                    DropDownList2.Items.Add("ROT-8");
                    DropDownList2.Items.Add("ROT-9");
                    DropDownList2.Items.Add("ROT-10");
                    DropDownList2.Items.Add("ROT-11");
                    DropDownList2.Items.Add("ROT-12");
                    DropDownList2.Items.Add("ROT-13");
                    DropDownList2.Items.Add("ROT-14");
                    DropDownList2.Items.Add("ROT-15");
                    DropDownList2.Items.Add("ROT-16");
                    DropDownList2.Items.Add("ROT-17");
                    DropDownList2.Items.Add("ROT-18");
                    DropDownList2.Items.Add("ROT-19");
                    DropDownList2.Items.Add("ROT-20");
                    DropDownList2.Items.Add("ROT-21");
                    DropDownList2.Items.Add("ROT-22");
                    DropDownList2.Items.Add("ROT-23");
                    DropDownList2.Items.Add("ROT-24");
                    DropDownList2.Items.Add("ROT-25");
                    DropDownList2.SelectedIndex = 13;
                    break;
                case "ASCII Tools":
                    DropDownList2.Items.Add("Decimal to ASCII");
                    DropDownList2.Items.Add("Hex to ASCII");
                    DropDownList2.Items.Add("Binary to ASCII");
                    DropDownList2.Items.Add("ASCII to Decimal");
                    DropDownList2.Items.Add("ASCII to Hex");
                    DropDownList2.Items.Add("ASCII to Binary");
                    DropDownList2.Items.Add("Binary to Decimal");
                    DropDownList2.Items.Add("Binary to Hex");
                    DropDownList2.Items.Add("Number to Letter (a = 1)");
                    DropDownList2.Items.Add("Index into String");
                    DropDownList2.SelectedIndex = 0;
                    break;
                case "Vigenere Tools":
                    DropDownList2.Items.Add("Vigenere Cipher Decoder");
                    DropDownList2.Items.Add("Vigenere Key Guesser");
                    DropDownList2.SelectedIndex = 0;
                    break;
                case "Morse Code Tools":
                    DropDownList2.Items.Add("Morse Code Decrypt");
                    DropDownList2.Items.Add("Fractionated Morse Decrypt");
                    DropDownList2.SelectedIndex = 0;
                    break;
                case "Bacon Ciphers":
                    DropDownList2.Items.Add("Baconian Cipher");
                    DropDownList2.Items.Add("Bacon's Biliteral - lower case == A");
                    DropDownList2.SelectedIndex = 0;
                    DropDownList5.Items.Add("24 letter alphabet");
                    DropDownList5.Items.Add("26 letter alphabet");
                    DropDownList5.SelectedIndex = 0;
                    break;
                case "Miscellaneous Ciphers":
                    DropDownList2.Items.Add("Keyword Cipher");
                    DropDownList2.Items.Add("Playfair Cipher");
                    DropDownList2.Items.Add("Playfair Key Square");
                    DropDownList2.Items.Add("One Time Pad");
                    DropDownList2.Items.Add("One Time Pad Key Guesser");
                    DropDownList2.Items.Add("Rail Fence Cipher");
                    DropDownList2.SelectedIndex = 0;
                    break;
                case "Tools":
                    DropDownList2.Items.Add("Reverse String");
                    DropDownList2.Items.Add("Text Offset");
                    DropDownList2.Items.Add("Show just CAPS");
                    DropDownList2.Items.Add("Show just lowercase");
                    DropDownList2.Items.Add("Convert to CAPS");
                    DropDownList2.Items.Add("Convert to lowercase");
                    DropDownList2.Items.Add("Character Count");
                    DropDownList2.Items.Add("Remove Spaces");
                    DropDownList2.Items.Add("Remove All But Letters");
                    DropDownList2.Items.Add("Sum of Letters");
                    DropDownList2.Items.Add("Test Routine");
                    DropDownList2.SelectedIndex = 0;
                    break;
                case "Analyze Code":
                    DropDownList2.Items.Add("Analyze - No Key");
                    DropDownList2.Items.Add("Analyze - Key Guess");
                    DropDownList2.Items.Add("Vigenere Key Brute Force");
                    DropDownList2.Items.Add("Fractionated Morse Brute Force");
                    DropDownList2.Items.Add("Keyword (Standard Alphabet) Brute Force");
                    DropDownList2.SelectedIndex = 0;
                    break;
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList4.Items.Clear();
            DropDownList6.Items.Clear();
            switch (DropDownList3.Text)
            {
                case "Caesar Tools":
                    DropDownList4.Items.Add("ROT-1");
                    DropDownList4.Items.Add("ROT-2");
                    DropDownList4.Items.Add("ROT-3");
                    DropDownList4.Items.Add("ROT-4");
                    DropDownList4.Items.Add("ROT-5");
                    DropDownList4.Items.Add("ROT-6");
                    DropDownList4.Items.Add("ROT-7");
                    DropDownList4.Items.Add("ROT-8");
                    DropDownList4.Items.Add("ROT-9");
                    DropDownList4.Items.Add("ROT-10");
                    DropDownList4.Items.Add("ROT-11");
                    DropDownList4.Items.Add("ROT-12");
                    DropDownList4.Items.Add("ROT-13");
                    DropDownList4.Items.Add("ROT-14");
                    DropDownList4.Items.Add("ROT-15");
                    DropDownList4.Items.Add("ROT-16");
                    DropDownList4.Items.Add("ROT-17");
                    DropDownList4.Items.Add("ROT-18");
                    DropDownList4.Items.Add("ROT-19");
                    DropDownList4.Items.Add("ROT-20");
                    DropDownList4.Items.Add("ROT-21");
                    DropDownList4.Items.Add("ROT-22");
                    DropDownList4.Items.Add("ROT-23");
                    DropDownList4.Items.Add("ROT-24");
                    DropDownList4.Items.Add("ROT-25");
                    DropDownList4.SelectedIndex = 12;
                    break;
                case "Vigenere Tools":
                    DropDownList4.Items.Add("Vigenere Cipher Encoder");
                    DropDownList4.SelectedIndex = 0;
                    break;
                case "Morse Code Tools":
                    DropDownList4.Items.Add("Morse Code Encrypt");
                    DropDownList4.Items.Add("Fractionated Morse Encrypt");
                    DropDownList4.SelectedIndex = 0;
                    break;
                case "Bacon Ciphers":
                    DropDownList4.Items.Add("Baconian Cipher");
                    DropDownList4.Items.Add("Bacon's Biliteral - lower case == A");
                    DropDownList4.SelectedIndex = 0;
                    DropDownList6.Items.Add("24 letter alphabet");
                    DropDownList6.Items.Add("26 letter alphabet");
                    DropDownList6.SelectedIndex = 0;
                    break;
                case "Miscellaneous Ciphers":
                    DropDownList4.Items.Add("Keyword Cipher");
                    DropDownList4.Items.Add("Playfair Cipher");
                    DropDownList4.Items.Add("One Time Pad");
                    DropDownList4.Items.Add("Rail Fence Cipher");
                    DropDownList4.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList5.Items.Clear();
            switch (DropDownList2.Text)
            {
                case "Baconian Cipher":
                case "Bacon's Biliteral - lower case == A":
                    DropDownList5.Items.Add("24 letter alphabet");
                    DropDownList5.Items.Add("26 letter alphabet");
                    DropDownList5.SelectedIndex = 0;
                    break;
                case "Rail Fence Cipher":
                    DropDownList5.Items.Add("3 rows");
                    DropDownList5.Items.Add("4 rows");
                    DropDownList5.Items.Add("5 rows");
                    DropDownList5.Items.Add("6 rows");
                    DropDownList5.Items.Add("7 rows");
                    DropDownList5.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList6.Items.Clear();
            switch (DropDownList4.Text)
            {
                case "Baconian Cipher":
                case "Bacon's Biliteral - lower case == A":
                    DropDownList6.Items.Add("24 letter alphabet");
                    DropDownList6.Items.Add("26 letter alphabet");
                    DropDownList6.SelectedIndex = 0;
                    break;
                case "Rail Fence Cipher":
                    DropDownList6.Items.Add("3 rows");
                    DropDownList6.Items.Add("4 rows");
                    DropDownList6.Items.Add("5 rows");
                    DropDownList6.Items.Add("6 rows");
                    DropDownList6.Items.Add("7 rows");
                    DropDownList6.SelectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
    }
}