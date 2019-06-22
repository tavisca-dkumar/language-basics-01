using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int Position(int x, string y)
        {

            int i, k = 0;
            string str = x.ToString();

            if (str.Length == y.Length)
            {
                for (i = 0; i < y.Length; i++)
                {
                    if (y[i] != '?')
                    {
                        if (str[i] != y[i])
                            return -1;
                    }
                    else
                        k = int.Parse(new string(str[i], 1));
                }
            }
            else
                return -1;
            //Console.WriteLine(i);
            if (i == y.Length)
                return k;
            else
                return -1;


        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            int x, y, z, k, a, e, q, i = 0;
            String n1, n2, n3;
            a = equation.IndexOf('*');
            e = equation.IndexOf('=');
            q = equation.IndexOf("?");
            n1 = equation.Substring(0, a);
            n2 = equation.Substring(a + 1, e - a - 1);
            n3 = equation.Substring(e + 1);
            // Console.WriteLine(n1 + " " + n2 + " " + n3);
            if (q > e)
            {
                x = int.Parse(n1);
                y = int.Parse(n2);
                k = x * y;
                i = Position(k, n3);//compare
            }
            else if (a > q)
            {
                y = int.Parse(n2);
                z = int.Parse(n3);
                if (z % y > 0)
                    return -1;
                else
                    k = z / y;
                i = Position(k, n1);//compare
            }
            else
            {
                x = int.Parse(n1);
                z = int.Parse(n3);
                if (z % x > 0)
                    return -1;
                else
                    k = z / x;
                i = Position(k, n2);//compare

            }
            return i;
            throw new NotImplementedException();
        }
    }
}
