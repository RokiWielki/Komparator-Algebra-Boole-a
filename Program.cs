using System;
using System.Collections.Generic;
using static System.Console;


namespace Komparator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManualTest();
            WriteLine();
            WriteLine("Aby kontynuować wciśnij dowolny przycisk...");
            ReadKey();
            AllPossibilities();
        }
        public static void ManualTest()
        {
            DisplayFirst(1);
            string firstInput;
            while (true)
            {
                firstInput = ReadLine().Trim();
                if (firstInput.Length == 4)
                {
                    if (int.TryParse(firstInput, out _))
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(firstInput, Constants.BinaryStringValidate()))
                        {
                            break;
                        }
                    }
                }
                WriteLine("Wprowadzono błędne dane!");
                Write("Podaj pierwszą cyfrę (binarną, czterobitową): ");
            }

            DisplayFirst(2, firstInput);
            string secondInput;
            while (true)
            {
                secondInput = ReadLine().Trim();
                if (secondInput.Length == 4)
                {
                    if (int.TryParse(secondInput, out _))
                    {
                        if (!System.Text.RegularExpressions.Regex.IsMatch(secondInput, Constants.BinaryStringValidate()))
                        {
                            break;
                        }
                    }
                }

                WriteLine(firstInput + " ? ");
                WriteLine("Wprowadzono błędne dane!");
                Write("Podaj drugą cyfrę (binarną, czterobitową): ");

            }

            int compare1 = Convert.ToInt32(firstInput, 2);
            int compare2 = Convert.ToInt32(secondInput, 2);
            if (compare1 > compare2)
            {
                WriteLine(firstInput + " > " + secondInput);
                WriteLine($"Wynik w systemie decymalnym: {compare1} > {compare2}");
            }
            else if (compare1 < compare2)
            {
                WriteLine(firstInput + " < " + secondInput);
                WriteLine($"Wynik w systemie decymalnym: {compare1} < {compare2}");
            }
            else
            {
                WriteLine(firstInput + " = " + secondInput);
                WriteLine($"Wynik w systemie decymalnym: {compare1} = {compare2}");
            }
        }
        private static void DisplayFirst(int x, string firstBinary = null)
        {

            if (x == 1)
            {
                Write("Podaj pierwszą cyfrę: ");
            }
            else if (x == 2)
            {
                WriteLine(firstBinary + " ? ");
                Write("Podaj drugą cyfrę: ");
            }
        }
        private static void AllPossibilities()
        {
            int parity = 0;
            int trials = 0;
            List<string> binary = Constants.BinaryInput();

            foreach (string variable in binary)
            {
                int baseOfCompare = Convert.ToInt32(variable, 2);
                for (int i = 0; i < binary.Count; i++)
                {
                    int foreignCompare = Convert.ToInt32(binary[i], 2);
                    Write(Convert.ToString(baseOfCompare, 2).PadLeft(4, '0'));

                    if (baseOfCompare > foreignCompare)
                        Write(" > " + Convert.ToString(foreignCompare, 2).PadLeft(4, '0'));
                    else if (baseOfCompare < foreignCompare)
                        Write(" < " + Convert.ToString(foreignCompare, 2).PadLeft(4, '0'));
                    else
                        Write(" = " + Convert.ToString(foreignCompare, 2).PadLeft(4, '0'));

                    trials++;
                    Console.WriteLine();
                }
                parity++;
            }

            if (trials == 1)
                WriteLine($"Wykonano: {trials} raz!");
            else
                WriteLine($"Wykonano: {trials} razy!");
        }
    }
    public static class Constants
    {
        public static List<string> BinaryInput()
        {
            return new List<string>()
            {
                "0000",
                "0001",
                "0010",
                "0011",
                "0100",
                "0101",
                "0110",
                "0111",
                "1000",
                "1001",
                "1010",
                "1011",
                "1100",
                "1101",
                "1110",
                "1111"
            };
        }
        public static string BinaryStringValidate()
        {
            return "[2-9]+";
        }
    }
}
