using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordMaker
{
    internal class PasswordMakerTool
    {
        private const string lowcase = "qwertyuiopasdfghjklzxcvbnm";
        private const string capital = "QWERTYUIOPASDFGHJKLZXCVBNM";
        private const string digit = "1234567890";
        private const string symbol = "`[]\\;',./`~!@#$%^&*()_+{}|:\"<>?";
        static public void Work(byte[] seed, byte[] sha256code, ExtraMessage extra)
        {
            byte[] newArr = new byte[seed.Length + sha256code.Length];

            // Stage 1
            int seedPos = 0, shaPos = 0;
            for(int i=0;i<newArr.Length; i++)
            {
                if (seedPos == seed.Length)
                {
                    newArr[i] = sha256code[shaPos];
                    shaPos++;
                }
                else if (shaPos == sha256code.Length)
                {
                    newArr[i] = seed[seedPos];
                    seedPos++;
                }
                else
                {
                    if (seed[seedPos] % 2 == 0)
                    {
                        newArr[i] = sha256code[shaPos];
                        shaPos++;
                    }
                    else
                    {
                        newArr[i] = seed[seedPos];
                        seedPos++;
                    }
                }
            }

            // Stage 2
            newArr = SHA256.HashData(newArr);

            // Stage 3
            string charset = "";
            if (extra.lowercase) charset += lowcase;
            if (extra.digit) charset += digit;
            if (extra.capital) charset += capital;
            if (extra.symbol) charset += symbol;
            foreach(byte b in newArr)
            {
                int cut = b % charset.Length;
                string temp = charset.Remove(cut);
                charset=charset.Substring(cut);
                charset += temp;
            }

            // Stage 4 - Output(SendKey)
            int needLength = extra.length;
            int arrPos = 0;
            while (needLength != 0)
            {
                SendKeys.Send("{" + charset[newArr[arrPos] % charset.Length] + "}");
                arrPos++;
                needLength--;
                if(arrPos == newArr.Length / 2)
                {
                    arrPos = 0;
                    newArr = SHA256.HashData(newArr);
                }
            }
        }
    }
}
