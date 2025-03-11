using System.Numerics;

namespace ReviseBasicSyntax;

public static class Basics
{
    public static void CreateListOfDifferentTypes()
    {
        int number = 1;
        double doubleNumber = 1.23D;
        char firstLetterOfMyName = 'V';
        string myName = "Vladislav";
        bool myBool = true;

        List<object> myList = new List<object>
        {
            number, doubleNumber, firstLetterOfMyName,
            myName, myBool,
        };

        foreach (object item in myList)
        {
            Console.WriteLine(item);
        }
    }

    public static void ImplicitCasting()
    {
        // char -> int -> long -> float -> double 
        char a = 'A';
        float b = a;
        Console.WriteLine(b);
    }

    public static void ExplicitCasting()
    {
        // vice-versa
        int number = 65;
        char letter = (char)number;
        Console.WriteLine(letter);
    }

    public static void UsingConvert()
    {
        int number = 65;
        char letter = Convert.ToChar(number);
        Console.WriteLine(letter);
    }

    public static void TryParse()
    {
        int number;
        bool success = int.TryParse(Console.ReadLine(), out number);
        if (success)
        {
            Console.WriteLine(number);
        }
    }

    public static void UsingMath()
    {
        Console.WriteLine(Math.Round(9.99));
    }

    public enum Level
    {
        Low,
        Medium,
        High
    }

    public static void CheckTheLevel(Level level)
    {
        switch (level)
        {
            case Level.Low:
                Console.WriteLine(level);
                break;
            case Level.Medium:
                Console.WriteLine(level);
                break;
            default:
                Console.WriteLine(level);
                break;
        }
    }

    public static void UsingSwitchWithWhileDo()
    {
        int i = 0;
        while (i < 5)
        {
            Console.Write($"{i + 1} - ");
            CheckTheLevel(Level.Medium);
            i++;
        }

        do
        {
            Console.Write($"{i + 1} - ");
            CheckTheLevel(Level.Medium);
            i++;
        } while (i < 5);
    }

    public static void UsingForLoop()
    {
        for (int i = 0; i < 5; i += 2)
        {
            Console.Write($"{i}");
        }
    }

    public static void UsingForEach()
    {
        string[] names = new string[]
        {
            "Vladislav",
            "Zakhar"
        };
        int i = 0;
        foreach (string name in names)
        {
            i++;
            Console.WriteLine($"Name no. {i} - {name}");
        }
    }

    public static T[] ReturnEven<T>(T[] array) where T : INumber<T>
    {
        return array.Where(i => i % T.CreateChecked(2) == T.Zero).ToArray();
    }

    public static void UsingWhere()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Array.ForEach(ReturnEven(numbers), Console.WriteLine);
    }
    
    public static void UsingArrays()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] numbers2 = new int[2] { 1, 2 };
        int[] numbers3 = new int[] { 1, 2 };
        int[] numbers4 = new int[1];
        numbers4[0] = 1;
    }

    public class Rectangle
    {
        private int a;
        private int b;
        
        public int A { get => a; }
        public int B { get => b; }

        public Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public Rectangle(int a)
        {
            this.a = a;
            this.b = a;
        }

        public int Square()
        {
            return a * b;
        }

        public void PrintSquare()
        {
            Console.WriteLine($"A = {A}, B = {B}. Square = A * B = {A} * {B} = {Square()}");
        }
    }
    
    public static void MethodOverloading()
    {
        Rectangle rectangle = new Rectangle(2, 3);
        Rectangle square = new Rectangle(3);
        rectangle.PrintSquare();
        square.PrintSquare();
    }
}