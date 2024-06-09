﻿namespace _01._WinForm
{
    enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Reminder,
        Celochislenoe
    }

    internal static class Calculator
    {
        static Operation operation;
        static double memory;

        public static void ChangeOperation(Operation op)
        {
            operation = op;
        }

        public static void ChangeMemory(double num)
        {
            memory = num;
        }

        public static double GetMemory()
        {
            return memory;
        }

        public static double equal(TextBox tb1, TextBox tb2)
        {
            double value1, value2;
            bool valid1 = double.TryParse(tb1.Text, out value1);
            bool valid2 = double.TryParse(tb2.Text, out value2);

            if (!valid1 || !valid2 || value1 % 1 != 0 || value2 % 1 != 0)
            {
                if (!valid1) tb1.BackColor = Color.Red;
                if (!valid2) tb2.BackColor = Color.Red;
                if (value1 % 1 != 0) tb1.BackColor = Color.Red;
                if (value2 % 1 != 0) tb2.BackColor = Color.Red;
                return double.NaN;
            }

            double result = DoOperation((int)value1, (int)value2, operation);
            ChangeMemory(result);
            return result;
        }

        static double DoOperation(double x, double y, Operation op)
        {
            double result = 0;

            switch (op)
            {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subtract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
                case Operation.Reminder:
                    result = x % y;
                    break;
                case Operation.Celochislenoe:
                    result = Math.Truncate(x / y);
                    break;
                default:
                    Console.WriteLine("Нет такой операции");
                    break;
            }

            return result;
        }

    }
}
