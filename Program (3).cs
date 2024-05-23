using System;

delegate double CalcDelegate(double num1, double num2, char operation);

class CalcProgram
{
    public static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 != 0)
                {
                    return num1 / num2;
                }
                else
                {
                    Console.WriteLine("Divide by 0 is not allowed");
                    return 0;
                }
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
}

class Program
{
    static void Main()
    {
        CalcDelegate funcCalc = new CalcDelegate(CalcProgram.Calc);

        Console.WriteLine("Enter the first number:");
        double num1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        double num2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter an operation (+, -, *, /):");
        char operation = char.Parse(Console.ReadLine());

        double result = funcCalc(num1, num2, operation);
        Console.WriteLine($"{num1} {operation} {num2} = {result}");
    }
}