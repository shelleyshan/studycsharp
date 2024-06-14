using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WemakeBaseFrame;

namespace ConsoleApp2.Script
{
    public class WRandom
    {
        private const int MBIG = int.MaxValue;

        private const int MSEED = 161803398;

        [ProtoMember(1)]
        public int inext;

        [ProtoMember(2)]
        public int inextp;

        [ProtoMember(3)]
        public int[] SeedArray = new int[56];

        public WRandom()
            : this(Environment.TickCount)
        {
        }

        public WRandom(int Seed)
        {
            int num = 161803398 - Math.Abs(Seed);
            SeedArray[55] = num;
            int num2 = 1;
            for (int i = 1; i < 55; i++)
            {
                int num3 = 21 * i % 55;
                SeedArray[num3] = num2;
                num2 = num - num2;
                if (num2 < 0)
                {
                    num2 += int.MaxValue;
                }

                num = SeedArray[num3];
            }

            for (int j = 1; j < 5; j++)
            {
                for (int k = 1; k < 56; k++)
                {
                    SeedArray[k] -= SeedArray[1 + (k + 30) % 55];
                    if (SeedArray[k] < 0)
                    {
                        SeedArray[k] += int.MaxValue;
                    }
                }
            }

            inext = 0;
            inextp = 21;
            Seed = 1;
        }

        protected virtual double Sample()
        {
            int num = inext;
            int num2 = inextp;
            if (++num >= 56)
            {
                num = 1;
            }

            if (++num2 >= 56)
            {
                num2 = 1;
            }

            int num3 = SeedArray[num] - SeedArray[num2];
            if (num3 < 0)
            {
                num3 += int.MaxValue;
            }

            SeedArray[num] = num3;
            inext = num;
            inextp = num2;
            return (double)num3 * 4.6566128752457969E-10;
        }

        public virtual int Next()
        {
            return (int)(Sample() * 2147483647.0);
        }

        public virtual int Next(int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                int num = minValue;
                minValue = maxValue;
                maxValue = num;
            }

            int num2 = maxValue - minValue;
            if (num2 < 0)
            {
                long num3 = (long)maxValue - (long)minValue;
                return (int)((long)(Sample() * (double)num3) + minValue);
            }

            return (int)(Sample() * (double)num2) + minValue;
        }

        public virtual int Next(int maxValue)
        {
            if (maxValue < 0)
            {
                maxValue = Math.Abs(maxValue);
                return -(int)(Sample() * (double)maxValue);
            }

            return (int)(Sample() * (double)maxValue);
        }

        public virtual double NextDouble()
        {
            return Sample();
        }

        public virtual void NextBytes(byte[] buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }

            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte)(Sample() * 256.0);
            }
        }
    }
    public class WemakeGameRandom
    {
        public WRandom random;

        public int _count;

        public int count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        public WemakeGameRandom()
        {
            DateTime dateTime = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1), TimeZoneInfo.Local);
            int seed = (int)(DateTime.Now - dateTime).TotalSeconds;
            random = new WRandom(seed);
        }

        public WemakeGameRandom(int seed)
        {
            count = 0;
            random = new WRandom(seed);
            Console.WriteLine($"WemakeGameRandomSeed:{seed}");
        }

        public static WemakeGameRandom GiveRandomSeed(long seed)
        {
            return GiveRandomSeed(TimeSpan.FromTicks(seed).Milliseconds);
        }

        public static WemakeGameRandom GiveRandomSeed(int seed)
        {
            return new WemakeGameRandom(seed);
        }

        public int Range(int min, int max)
        {
            count++;
            int num = random.Next(2000, 102000);
            num -= 2000;
            int num2 = max - min;
            if (num2 <= 0)
            {
                return min;
            }

            return num % num2 + min;
        }

        public int RangeForOdd(int v1, int v2)
        {
            count++;
            int num = random.Next(v1 + 2, v2 - 2);
            return (num % 2 == 1) ? num : (num + 1);
        }

        public int Next(int max)
        {
            count++;
            return random.Next(max);
        }
    }

    public sealed class WemakeRandom
    {
        private static WemakeGameRandom wRandom;

        static WemakeRandom()
        {
            wRandom = new WemakeGameRandom();
        }

        public static int Range(int min, int max)
        {
            return wRandom.Range(min, max);
        }

        public static int RangeForOdd(int v1, int v2)
        {
            return wRandom.RangeForOdd(v1, v2);
        }

        public static int Next(int max)
        {
            return wRandom.Next(max);
        }
    }
}

