using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PasswordMaker
{
    // 只能防御低级的内存跟踪（例如CE）
    internal class AntiMemoryScan
    {
        private const int mixedSize = 1024;
        public const int maxLength = 512;// -1
        private const int mixedTime = 100;// ms
        private const int mixedTactics = 32;// Must Be Greater Than 3



        private Random random;
        private System.Timers.Timer refreshTimer;
        private int messageLength;
        private char[][] data;
        private char[] xorList;
        private int[] truePosition;
        private char[][] mixedTacticsList;

        public AntiMemoryScan()
        {
            random = new Random();
            refreshTimer=new System.Timers.Timer(mixedTime);
            refreshTimer.Elapsed += autoMix;

            messageLength = 0;
            data = new char[mixedSize][];
            for (int i = 0; i < mixedSize; i++)
                data[i] = new char[maxLength];
            xorList = new char[maxLength];
            truePosition = new int[1];
            truePosition[0] = random.Next(0, mixedSize);
            mixedTacticsList = new char[mixedTactics][];

            resetTactics();
            refreshTimer.Start();
        }
        public AntiMemoryScan(int seed)
        {
            random = new Random(seed);
            refreshTimer = new System.Timers.Timer(mixedTime);
            refreshTimer.Elapsed += autoMix;

            messageLength = 0;
            data = new char[mixedSize][];
            for (int i = 0; i < mixedSize; i++)
                data[i] = new char[maxLength];
            xorList = new char[maxLength];
            truePosition = new int[1];
            truePosition[0] = random.Next(0, mixedSize);
            mixedTacticsList = new char[mixedTactics][];

            resetTactics();
            refreshTimer.Start();
        }

        private void resetTactics()
        {
            // Default Tactics
            mixedTacticsList[0] = new char[10];// Digit
            mixedTacticsList[1] = new char[36];// Digit + Lowercase
            mixedTacticsList[2] = new char[62];// Digit + Lowercase + Capital
            for (int i = 0; i < 10; i++)
                mixedTacticsList[0][i] = mixedTacticsList[1][i] = mixedTacticsList[2][i] = (char)(i + '0');
            for (int i = 10; i < 36; i++)
                mixedTacticsList[1][i] = mixedTacticsList[2][i] = (char)(i - 10 + 'a');
            for (int i = 36; i < 62; i++)
                mixedTacticsList[2][i] = (char)(i - 36 + 'A');

            // Random Tactics
            for (int i = 3; i < mixedTactics / 4 * 3; i++)
            {
                mixedTacticsList[i] = new char[random.Next(6, 256)];// ASCII 33-126
                for (int j = 0; j < mixedTacticsList[i].Length; j++)
                    mixedTacticsList[i][j] = (char)(random.Next(33, 127));
            }
            for(int i= mixedTactics / 4 * 3; i< mixedTactics; i++)
            {
                mixedTacticsList[i]=new char[random.Next(6, 256)];
                for (int j = 0; j < mixedTacticsList[i].Length; j++)
                    mixedTacticsList[i][j] = (char)(random.Next(char.MinValue, char.MaxValue));
            }

            //Choose Tactic
            for (int i = 0; i < mixedSize; i++)
            {
                if (random.Next(0, 10) < 2)
                    data[i][0] = (char)0;
                else if (random.Next(0, 10) < 3)
                    data[i][0] = (char)1;
                else if (random.Next(0, 10) < 4)
                    data[i][0] = (char)2;
                else data[i][0] = (char)random.Next(3, mixedTactics);
            }
        }

        public int getLength()
        {
            return messageLength;
        }

        public void addNewChar(char c)
        {
            refreshTimer.Stop();

            messageLength++;
            xorList[messageLength] = (char)random.Next(char.MinValue, char.MaxValue);
            for(int i = 0; i < mixedSize; i++)
            {
                int tactic = data[i][0];
                if (truePosition[0] <= i && truePosition[0] >= i)
                {
                    data[i][messageLength] = (char)(c ^ xorList[messageLength]);
                    c = (char)random.Next(char.MinValue, char.MaxValue);
                }
                else
                {
                    data[i][messageLength] = mixedTacticsList[tactic][random.Next(0, mixedTacticsList[tactic].Length)];
                    data[i][messageLength] = (char)(data[i][messageLength] ^ xorList[messageLength]);
                };
            }

            randSwitchMessage();
            refreshTimer.Start();
        }
        public void addNewChar(char c, int position)// The First Position Is 1
        {
            if (position <= 0 || position > messageLength + 1) throw new IndexOutOfRangeException();
            refreshTimer.Stop();

            messageLength++;
            xorList[messageLength] = (char)random.Next(char.MinValue, char.MaxValue);

            for(int i = 0; i < mixedSize; i++)
                for (int j = messageLength - 1; j >= position; j--)
                    data[i][j + 1] = (char)(data[i][j] ^ xorList[j] ^ xorList[j + 1]);

            for (int i = 0; i < mixedSize; i++)
            {
                int tactic = data[i][0];
                if (truePosition[0] <= i && truePosition[0] >= i)
                {
                    data[i][position] = (char)(c ^ xorList[position]);
                    c = (char)random.Next(char.MinValue, char.MaxValue);
                }
                else
                {
                    data[i][position] = mixedTacticsList[tactic][random.Next(0, mixedTacticsList[tactic].Length)];
                    data[i][position] = (char)(data[i][position] ^ xorList[position]);
                };
            }

            randSwitchMessage();
            refreshTimer.Start();
        }

        public void removeChar(int position)// The First Position Is 1
        {
            if (position <= 0 || position > messageLength) throw new IndexOutOfRangeException();

            refreshTimer.Stop();
            for(int i = 0; i < mixedSize; i++)
            {
                for (int j = position + 1; j <= messageLength; j++)
                {
                    data[i][j - 1] = (char)(data[i][j] ^ xorList[j] ^ xorList[j - 1]);
                    data[i][j] = (char)random.Next(char.MinValue, char.MaxValue);
                }
            }
            messageLength--;

            randSwitchMessage();
            refreshTimer.Start();
        }

        public byte[] outputSHA256(byte[] seed)// Length of seed must be greater than maxLength * 2 
        {
            if(messageLength==0)return new byte[32];

            refreshTimer.Stop();

            char[] real = new char[maxLength];
            for (int i = 0; i < maxLength; i++)
                real[i] = (char)(data[truePosition[0]][i] ^ xorList[i]);
            byte[] ret = Encoding.Unicode.GetBytes(real, 1, messageLength);
            for (int i = 0; i < maxLength; i++)
                real[i] = (char)(random.Next(char.MinValue, char.MaxValue));
            for (int i = 0; i < ret.Length; i++)
                ret[i] = (byte)(ret[i] ^ seed[i]);
            ret = SHA256.HashData(ret);
            ret = SHA256.HashData(ret);

            randSwitchMessage();
            refreshTimer.Start();
            return ret;
        }

        public void clear()
        {
            refreshTimer.Stop();

            // Cover data
            for (int i = 0; i < mixedSize; i++)
                for (int j = 0; j < maxLength; j++)
                    data[i][j] = (char)0;

            // Reset
            messageLength = 0;
            data = new char[mixedSize][];
            for (int i = 0; i < mixedSize; i++)
                data[i] = new char[maxLength];
            xorList = new char[maxLength];

            resetTactics();
            refreshTimer.Start();
        }

        private void autoMix(object? sender, System.Timers.ElapsedEventArgs e)
        {
            refreshTimer.Stop();
            
            if (messageLength != 0) randSwitchMessage();
            else truePosition[0] = random.Next(0, mixedSize);

            refreshTimer.Start();
        }

        private void randSwitchMessage()
        {
            // Make Switch List
            int[] switchList=new int[mixedSize];
            for (int i = 0; i < mixedSize; i++)
                switchList[i] = i;
            for (int i = 0; i < mixedSize; i++)
            {
                int now = switchList[i];
                int next = random.Next(i, mixedSize);
                switchList[i] = switchList[next];
                switchList[next] = now;
            }

            // Switch
            for(int i = 0; i < mixedSize; i++)
            {
                char[] now=new char[maxLength];
                for (int j = 0; j <= messageLength; j++)
                    now[j] = data[i][j];
                data[i] = data[switchList[i]];
                data[switchList[i]] = now;
                if (truePosition[0] == i)
                {
                    int[] tempCatcher = truePosition;
                    tempCatcher[0] = random.Next();
                    truePosition = new int[1];
                    truePosition[0] = switchList[i];
                }else if (truePosition[0] == switchList[i])
                {
                    int[] tempCatcher = truePosition;
                    tempCatcher[0] = random.Next();
                    truePosition = new int[1];
                    truePosition[0] = i;
                }
            }
        }

        ~AntiMemoryScan()
        {
            refreshTimer.Stop();
            refreshTimer.Dispose();
        }
    }
}
