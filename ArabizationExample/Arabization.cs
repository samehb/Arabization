using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArabizationExample
{
    public class Arabization
    {
        String HandleSymbolsString(string Text)
        {
            char[] strArray = Text.ToCharArray();

            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i] == '(')
                    strArray.SetValue(')', i);
                else if (strArray[i] == ')')
                    strArray.SetValue('(', i);
                else if (strArray[i] == '<')
                    strArray.SetValue('>', i);
                else if (strArray[i] == '>')
                    strArray.SetValue('<', i);
                else if (strArray[i] == ']')
                    strArray.SetValue('[', i);
                else if (strArray[i] == '[')
                    strArray.SetValue(']', i);
                else if (strArray[i] == '{')
                    strArray.SetValue('}', i);
                else if (strArray[i] == '}')
                    strArray.SetValue('{', i);
            }

            String strReversed = new String(strArray);
            return strReversed;
        }
        String MakeReverse(String Text, bool ReverseSymbols)
        {
            char[] strArray = Text.ToCharArray();
            Array.Reverse(strArray);
            String strReversed = new String(strArray);

            if (ReverseSymbols)
                return HandleSymbolsString(strReversed);

            return strReversed;
        }

        public String ReverseArabicText(String ArabicText)
        {
            String PArabicText = "", RevEnglishText = "", RevArabicText = "";

            RevArabicText = MakeReverse(ArabicText, false);

            int i = 0, ii = 0, EngTextLeft = 0, EngTextRight = 0, OtherChars = 0;

            while (i < RevArabicText.Length)
            {
                if (RevArabicText[i] < '\x0080')
                {
                    OtherChars = 0;
                    RevEnglishText = "";

                    while ((i < RevArabicText.Length) && (RevArabicText[i] < '\x0080'))
                    {
                        if (!((RevArabicText[i] >= 'a' && RevArabicText[i] <= 'z') || (RevArabicText[i] >= 'A' && RevArabicText[i] <= 'Z') || (RevArabicText[i] >= '0' && RevArabicText[i] <= '9')))
                            OtherChars++;
                        RevEnglishText = RevEnglishText + RevArabicText[i];
                        i++;
                    }

                    ii = 0;
                    EngTextRight = 0;
                    EngTextLeft = 0;

                    if (OtherChars != RevEnglishText.Length)
                    {

                        while (!((RevEnglishText[ii] >= 'a' && RevEnglishText[ii] <= 'z') || (RevEnglishText[ii] >= 'A' && RevEnglishText[ii] <= 'Z') || (RevEnglishText[ii] >= '0' && RevEnglishText[ii] <= '9')))
                            ii++;
                        EngTextLeft = ii;

                        ii = RevEnglishText.Length - 1;

                        while (!((RevEnglishText[ii] >= 'a' && RevEnglishText[ii] <= 'z') || (RevEnglishText[ii] >= 'A' && RevEnglishText[ii] <= 'Z') || (RevEnglishText[ii] >= '0' && RevEnglishText[ii] <= '9')))
                            ii--;
                        EngTextRight = ii;

                        if (EngTextLeft > 0)
                            PArabicText += RevEnglishText.Substring(0, EngTextLeft);

                        PArabicText += MakeReverse(RevEnglishText.Substring(EngTextLeft, (EngTextRight - EngTextLeft) + 1), true);

                        if (EngTextRight < RevEnglishText.Length - 1)
                            PArabicText += RevEnglishText.Substring(EngTextRight + 1);
                    }
                    else
                        PArabicText += RevEnglishText;
                }
                else
                {
                    PArabicText = PArabicText + RevArabicText[i];
                    i++;
                }
            }
            return PArabicText;
        }

        public String Arabize(String ArabicText)
        {
            bool CharacterBefore, CharacterAfter;
            String CArabicText, CCodedArabicText, FilteredArabicText = "";
            const int Character = 0;
            const int Isolated = 1;
            const int Final = 2;
            const int Initial = 3;
            const int Medial = 4;


            char[,] ArabicCharactersSet = new char[,]
                {
                {'\x621', '\xfe80', '\xfe80', '\xfe80', '\xfe80'},///ء 
                {'\x622', '\xfe81', '\xfe82', '\xfe81', '\xfe82'},///ٱ
                {'\x623', '\xfe83', '\xfe84', '\xfe83', '\xfe84'},///أ
                {'\x624', '\xfe85', '\xfe86', '\xfe85', '\xfe86'},///ؤ
                {'\x625', '\xfe87', '\xfe88', '\xfe87', '\xfe88'},///ٳ
                {'\x626', '\xfe89', '\xfe8a', '\xfe8b', '\xfe8c'},//ىء
                {'\x627', '\xfe8d', '\xfe8e', '\xfe8d', '\xfe8e'},///ا
                {'\x628', '\xfe8f', '\xfe90', '\xfe91', '\xfe92'},//ب
                {'\x629', '\xfe93', '\xfe94', '\xfe93', '\xfe94'},///ة
                {'\x62a', '\xfe95', '\xfe96', '\xfe97', '\xfe98'},//ت
                {'\x62b', '\xfe99', '\xfe9a', '\xfe9b', '\xfe9c'},//ث
                {'\x62c', '\xfe9d', '\xfe9e', '\xfe9f', '\xfea0'},//ج
                {'\x62d', '\xfea1', '\xfea2', '\xfea3', '\xfea4'},//ح
                {'\x62e', '\xfea5', '\xfea6', '\xfea7', '\xfea8'},//خ
                {'\x62f', '\xfea9', '\xfeaa', '\xfea9', '\xfeaa'},///د
                {'\x630', '\xfeab', '\xfeac', '\xfeab', '\xfeac'},///ذ
                {'\x631', '\xfead', '\xfeae', '\xfead', '\xfeae'},///ر
                {'\x632', '\xfeaf', '\xfeb0', '\xfeaf', '\xfeb0'},///ز
                {'\x633', '\xfeb1', '\xfeb2', '\xfeb3', '\xfeb4'},//س
                {'\x634', '\xfeb5', '\xfeb6', '\xfeb7', '\xfeb8'},//ش
                {'\x635', '\xfeb9', '\xfeba', '\xfebb', '\xfebc'},//ص
                {'\x636', '\xfebd', '\xfebe', '\xfebf', '\xfec0'},//ض
                {'\x637', '\xfec1', '\xfec2', '\xfec3', '\xfec4'},//ط
                {'\x638', '\xfec5', '\xfec6', '\xfec7', '\xfec8'},//ظ
                {'\x639', '\xfec9', '\xfeca', '\xfecb', '\xfecc'},//ع
                {'\x63a', '\xfecd', '\xfece', '\xfecf', '\xfed0'},//غ
                {'\x641', '\xfed1', '\xfed2', '\xfed3', '\xfed4'},//ف
                {'\x642', '\xfed5', '\xfed6', '\xfed7', '\xfed8'},//ق
                {'\x643', '\xfed9', '\xfeda', '\xfedb', '\xfedc'},//ك
                {'\x644', '\xfedd', '\xfede', '\xfedf', '\xfee0'},//ل
                {'\x645', '\xfee1', '\xfee2', '\xfee3', '\xfee4'},//م
                {'\x646', '\xfee5', '\xfee6', '\xfee7', '\xfee8'},//ن
                {'\x647', '\xfee9', '\xfeea', '\xfeeb', '\xfeec'},//ه
                {'\x648', '\xfeed', '\xfeee', '\xfeed', '\xfeee'},///و
                {'\x649', '\xfeef', '\xfef0', '\xfeef', '\xfef0'},///ى
                {'\x64a', '\xfef1', '\xfef2', '\xfef3', '\xfef4'},//ي
                {'\x640', '\x0640', '\x0640', '\x0640', '\x0640'},///-
                {'\x61f', '\x061f', '\x061f', '\x061f', '\x061f'},///؟
                {'\x61f', '\xfef5', '\xfef6', '\xfef5', '\xfef6'},///لآ
                {'\x61f', '\xfef7', '\xfef8', '\xfef7', '\xfef8'},///لأ
                {'\x61f', '\xfef9', '\xfefa', '\xfef9', '\xfefa'},///لإ
                {'\x61f', '\xfefb', '\xfefc', '\xfefb', '\xfefc'}///لا
                };

            char[,] ArabicCharactersSetCodes = new char[,]
                {                
                {'\x621', '\x0000', '\x0000', '\x0000', '\x0000'},///ء 
                {'\x622', '\x0001', '\x0002', '\x0001', '\x0002'},///ٱ
                {'\x623', '\x0003', '\x0004', '\x0003', '\x0004'},///أ
                {'\x624', '\x0005', '\x0006', '\x0005', '\x0006'},///ؤ
                {'\x625', '\x0007', '\x0008', '\x0007', '\x0008'},///ٳ
                {'\x626', '\x0009', '\x000a', '\x000b', '\x000c'},//ىء
                {'\x627', '\x000d', '\x000e', '\x000d', '\x000e'},///ا
                {'\x628', '\x000f', '\x0010', '\x0011', '\x0012'},//ب
                {'\x629', '\x0013', '\x0014', '\x0013', '\x0014'},///ة
                {'\x62a', '\x0015', '\x0016', '\x0017', '\x0018'},//ت
                {'\x62b', '\x0019', '\x001a', '\x001b', '\x001c'},//ث
                {'\x62c', '\x001d', '\x001e', '\x001f', '\x0020'},//ج
                {'\x62d', '\x0021', '\x0022', '\x0023', '\x0024'},//ح
                {'\x62e', '\x0025', '\x0026', '\x0027', '\x0028'},//خ
                {'\x62f', '\x0029', '\x002a', '\x0029', '\x002a'},///د
                {'\x630', '\x002b', '\x002c', '\x002b', '\x002c'},///ذ
                {'\x631', '\x002d', '\x002e', '\x002d', '\x002e'},///ر
                {'\x632', '\x002f', '\x0030', '\x002f', '\x0030'},///ز
                {'\x633', '\x0031', '\x0032', '\x0033', '\x0034'},//س
                {'\x634', '\x0035', '\x0036', '\x0037', '\x0038'},//ش
                {'\x635', '\x0039', '\x003a', '\x003b', '\x003c'},//ص
                {'\x636', '\x003d', '\x003e', '\x003f', '\x0040'},//ض
                {'\x637', '\x0041', '\x0042', '\x0043', '\x0044'},//ط
                {'\x638', '\x0045', '\x0046', '\x0047', '\x0048'},//ظ
                {'\x639', '\x0049', '\x004a', '\x004b', '\x004c'},//ع
                {'\x63a', '\x004d', '\x004e', '\x004f', '\x0050'},//غ
                {'\x641', '\x0051', '\x0052', '\x0053', '\x0054'},//ف
                {'\x642', '\x0055', '\x0056', '\x0057', '\x0058'},//ق
                {'\x643', '\x0059', '\x005a', '\x005b', '\x005c'},//ك
                {'\x644', '\x005d', '\x005e', '\x005f', '\x0060'},//ل
                {'\x645', '\x0061', '\x0062', '\x0063', '\x0064'},//م
                {'\x646', '\x0065', '\x0066', '\x0067', '\x0068'},//ن
                {'\x647', '\x0069', '\x006a', '\x006b', '\x006c'},//ه
                {'\x648', '\x006d', '\x006e', '\x006d', '\x006e'},///و
                {'\x649', '\x006f', '\x0070', '\x006f', '\x0070'},///ى
                {'\x64a', '\x0071', '\x0072', '\x0073', '\x0074'},//ي
                {'\x640', '\x0075', '\x0075', '\x0075', '\x0075'},///-
                {'\x61f', '\x0076', '\x0076', '\x0076', '\x0076'},///؟
                {'\x61f', '\x0077', '\x0078', '\x0077', '\x0078'},///لآ
                {'\x61f', '\x0079', '\x007a', '\x0079', '\x007a'},///لأ
                {'\x61f', '\x007b', '\x007c', '\x007b', '\x007c'},///لإ
                {'\x61f', '\x007d', '\x007e', '\x007d', '\x007e'}///لا
                };

            for (uint i = 0; i < ArabicText.Length; i++)
            {
                char ch = ArabicText.ToCharArray()[i];
                if (ch < '\x064b' || ch > '\x0652')
                {
                    FilteredArabicText = FilteredArabicText + ch;
                }
            }

            ArabicText = FilteredArabicText;

            CArabicText = "";
            CCodedArabicText = "";
            for (uint i = 0; i < ArabicText.Length; i++)
            {
                char ch = ArabicText.ToCharArray()[i];
                if (ch >= '\x061f' && ch <= '\x064a')//
                {
                    int idx = 0;
                    while (idx < 38)
                    {
                        if (ArabicCharactersSet[idx, 0] == ArabicText.ToCharArray()[i])
                            break;
                        idx++;
                    }

                    if (i == ArabicText.Length - 1)
                        CharacterAfter = false;
                    else
                        CharacterAfter = (IsMedial(ArabicText.ToCharArray()[i + 1]) ||
                                           IsNotMedial(ArabicText.ToCharArray()[i + 1]));
                    if (i == 0)
                        CharacterBefore = false;
                    else
                        CharacterBefore = IsMedial(ArabicText.ToCharArray()[i - 1]);

                    if (CharacterBefore && CharacterAfter)
                    {
                        if ((ch == '\x644') && (ArabicText.ToCharArray()[i + 1] == '\x622' || ArabicText.ToCharArray()[i + 1] == '\x623' || ArabicText.ToCharArray()[i + 1] == '\x625' || ArabicText.ToCharArray()[i + 1] == '\x627'))
                        {
                            if (ArabicText.ToCharArray()[i + 1] == '\x622')
                            {
                                CArabicText += ArabicCharactersSet[38, Medial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[38, Medial] + 128);
                                i++;
                            }
                            else if (ArabicText.ToCharArray()[i + 1] == '\x623')
                            {
                                CArabicText += ArabicCharactersSet[39, Medial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[39, Medial] + 128);
                                i++;
                            }
                            else if (ArabicText.ToCharArray()[i + 1] == '\x625')
                            {
                                CArabicText += ArabicCharactersSet[40, Medial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[40, Medial] + 128);
                                i++;
                            }
                            else
                            {
                                CArabicText += ArabicCharactersSet[41, Medial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[41, Medial] + 128);
                                i++;
                            }
                        }
                        else
                        {
                            CArabicText += ArabicCharactersSet[idx, Medial];
                            CCodedArabicText += (char)((int)ArabicCharactersSetCodes[idx, Medial] + 128);
                        }
                    }
                    if (CharacterBefore && !CharacterAfter)
                    {
                        CArabicText += ArabicCharactersSet[idx, Final];
                        CCodedArabicText += (char)((int)ArabicCharactersSetCodes[idx, Final] + 128);
                    }
                    if (!CharacterBefore && CharacterAfter)
                    {
                        if ((ch == '\x644') && (ArabicText.ToCharArray()[i + 1] == '\x622' || ArabicText.ToCharArray()[i + 1] == '\x623' || ArabicText.ToCharArray()[i + 1] == '\x625' || ArabicText.ToCharArray()[i + 1] == '\x627'))
                        {
                            if (ArabicText.ToCharArray()[i + 1] == '\x622')
                            {
                                CArabicText += ArabicCharactersSet[38, Initial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[38, Initial] + 128);
                                i++;
                            }
                            else if (ArabicText.ToCharArray()[i + 1] == '\x623')
                            {
                                CArabicText += ArabicCharactersSet[39, Initial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[39, Initial] + 128);
                                i++;
                            }
                            else if (ArabicText.ToCharArray()[i + 1] == '\x625')
                            {
                                CArabicText += ArabicCharactersSet[40, Initial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[40, Initial] + 128);
                                i++;
                            }
                            else
                            {
                                CArabicText += ArabicCharactersSet[41, Initial];
                                CCodedArabicText += (char)((int)ArabicCharactersSetCodes[41, Initial] + 128);
                                i++;
                            }
                        }
                        else
                        {
                            CArabicText += ArabicCharactersSet[idx, Initial];
                            CCodedArabicText += (char)((int)ArabicCharactersSetCodes[idx, Initial] + 128);
                        }
                    }
                    if (!CharacterBefore && !CharacterAfter)
                    {
                        CArabicText += ArabicCharactersSet[idx, Isolated];
                        CCodedArabicText += (char)((int)ArabicCharactersSetCodes[idx, Isolated] + 128);
                    }
                }
                else
                {
                    CArabicText += ch;
                    CCodedArabicText += ch;
                }
            }

            return HandleSymbolsString(ReverseArabicText(CCodedArabicText));
        }
        //////////////////////////////////////////////////////////////////////

        bool IsMedial(char ch)
        {
            char[] MedialChars ={
                '\x626', '\x628', '\x62a', '\x62b', '\x62c', '\x62d', 
                '\x62e', '\x633', '\x634', '\x635', '\x636', '\x637', 
                '\x638', '\x639', '\x63a', '\x640', '\x641', '\x642', 
                '\x643', '\x644', '\x645', '\x646', '\x647', '\x64a'
                };
            int i = 0;
            while (i < 24)
            {
                if (ch == MedialChars[i])
                    return true;
                ++i;
            }
            return false;
        }
        //////////////////////////////////////////////////////////////////////

        bool IsNotMedial(char ch)
        {
            char[] NonMedialChars ={
                '\x622', '\x623', '\x624', '\x625', '\x627', '\x629',
                '\x62f', '\x630', '\x631', '\x632', '\x648', '\x649'
                };

            int i = 0;
            while (i < 12)
            {
                if (ch == NonMedialChars[i])
                    return true;
                i++;
            }
            return false;
        }

    }
}
