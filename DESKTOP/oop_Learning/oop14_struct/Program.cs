namespace oop14_struct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Digitalsze size = new Digitalsze(100000000000000000);

            Console.WriteLine(size.Bit);
            Console.WriteLine("==============================");
            Console.WriteLine(size.BYTE);
            Console.WriteLine("==============================");
            Console.WriteLine(size.KB);
            Console.WriteLine("==============================");
            Console.WriteLine(size.MB);
            Console.WriteLine("==============================");
            Console.WriteLine(size.GB);
            Console.WriteLine("==============================");
            Console.WriteLine(size.TB);
            Console.WriteLine("==============================");
        }

        struct Digitalsze
        {
            private long bit;
            public Digitalsze(long initioalbit)
            {
                this.bit = initioalbit;
            }

            public string Bit => $"{(bit / bitintbit):N0} Bit";
            public string BYTE => $"{(bit / Byteinbit):N0} BYTE";
            public string KB => $"{(bit / BitinKB):N0} KB";
            public string MB => $"{(bit / BitinMG):N0} MB";
            public string GB => $"{(bit / BitinGB):N0} GB";
            public string TB => $"{(bit / BitinTB):N0} TB";

            private const long bitintbit = 1;
            private const long Byteinbit = 8;
            private const long BitinKB = Byteinbit * 1024;
            private const long BitinMG = BitinKB * 1024;
            private const long BitinGB = BitinMG * 1024;
            private const long BitinTB = BitinGB * 1024;
        }
    }
}
