using System;
using System.Numerics;

public class Program
{
    // For multipattern search see wikipedia
    public static void Main()
    {
        string text = Console.ReadLine();
        string pattern = Console.ReadLine();

        int counter = 0;

        int n = text.Length;
        int m = pattern.Length;
        
        Hash hPattern = new Hash(pattern);
        Hash hText = new Hash(text.Substring(0, m));

        for (int i = m; i < n; i++)
        {
            if (hPattern.Hash1 == hText.Hash1 && hPattern.Hash2 == hText.Hash2)
            {
                counter++;
            }

            hText.Add(text[i]);
            hText.Remove(text[i - m]);
        }

        // check the last change in hText
        if (hPattern.Hash1 == hText.Hash1 && hPattern.Hash2 == hText.Hash2)
        {
            counter++;
        }

        Console.WriteLine(counter);
    }

    public class Hash
    {
        public BigInteger BASE1 = 257;
        public BigInteger MOD1 = 1000000007;

        public BigInteger BASE2 = 307;
        public BigInteger MOD2 = 1000000033;

        public BigInteger BASE3 = 211;
        public BigInteger MOD3 = 1000000019;

        private BigInteger power1;
        private BigInteger power2;
        private BigInteger power3;

        public BigInteger Hash1 { get; set; }

        public BigInteger Hash2 { get; set; }

        public BigInteger Hash3 { get; set; }

        public Hash(string str)
        {
            this.power1 = 1;
            this.power2 = 1;
            this.power3 = 1;

            foreach (char c in str)
            {
                this.Add(c);
                this.power1 = (this.power1 * this.BASE1) % this.MOD1;
                this.power2 = (this.power2 * this.BASE2) % this.MOD2;
                this.power3 = (this.power3 * this.BASE3) % this.MOD3;
            }
        }

        public void Add(char c)
        {
            this.Hash1 = (this.Hash1 * this.BASE1 + c) % this.MOD1;
            this.Hash2 = (this.Hash2 * this.BASE2 + c) % this.MOD2;
            this.Hash3 = (this.Hash3 * this.BASE3 + c) % this.MOD3;
        }

        public void Remove(char c)
        {
            this.Hash1 = (this.MOD1 + this.Hash1 - c * this.power1 % this.MOD1) % this.MOD1;
            this.Hash2 = (this.MOD2 + this.Hash2 - c * this.power2 % this.MOD2) % this.MOD2;
            this.Hash3 = (this.MOD3 + this.Hash3 - c * this.power3 % this.MOD3) % this.MOD3;
        }
    }
}

