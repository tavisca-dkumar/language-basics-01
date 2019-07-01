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

        public static int Position(int x, string y) //this function takes '?' contains string,actual int and returns digit
        {
            int i, k = 0;
            string str = x.ToString(); // convert comparable int to string for comparision
            if (str.Length == y.Length) // comparing both strings are same length if not returns -1
            {
                for (i = 0; i < y.Length; i++)
                {
                    if (y[i] != '?')
                    {
                        if (str[i] != y[i])
                            return -1;
                    }
                    else
                        k = int.Parse(new string(str[i], 1)); //converted the digit from string to int 
                }
            }
            else
                return -1;
            if (i == y.Length) // returned k only if matches all positions otherwise returned -1
                return k;
            else
                return -1;
        }
        public static int FindDigit(string equation)
        {
            // Add your code here.
            int intOperand1, intOperand2, intSolution, digit, multiplicationIndex, equalIndex, questionmarkIndex, i = 0;
            String operand1, operand2, solution;
            multiplicationIndex = equation.IndexOf('*');
            equalIndex = equation.IndexOf('=');
            questionmarkIndex = equation.IndexOf("?");
            operand1 = equation.Substring(0, multiplicationIndex);
            operand2 = equation.Substring(multiplicationIndex + 1, equalIndex - multiplicationIndex - 1);
            solution = equation.Substring(equalIndex + 1);
            if (questionmarkIndex > equalIndex) //checked whelther '?' lies in LHS or RHS
            {
                intOperand1 = int.Parse(operand1);
                intOperand2 = int.Parse(operand2);
                digit = intOperand1 * intOperand2;
                i = Position(digit, solution);
            }
            else if (multiplicationIndex > questionmarkIndex) // checked whelther '?' lies in operand1 or operand 2
            {
                intOperand2 = int.Parse(operand2);
                intSolution = int.Parse(solution);
                if (intSolution % intOperand2 > 0)
                    return -1;
                else
                    digit = intSolution / intOperand2;
                i = Position(digit, operand1);//compare
            }
            else
            {
                intOperand1 = int.Parse(operand1);
                intSolution = int.Parse(solution);
                if (intSolution % intOperand1 > 0)
                    return -1;
                else
                    digit = intSolution / intOperand1;
                i = Position(digit, operand2);//compare

            }
            return i;
            throw new NotImplementedException();
        }
    }
}
