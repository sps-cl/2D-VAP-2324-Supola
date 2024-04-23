using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Realná část 1 kompx čísla");
            double RealNum1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Imaginarní část 1 kompx čísla");
            double ImaginaryNum1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Realná část 2 kompx čísla");
            double RealNum2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Imaginarní část 2 kompx čísla");
            double ImaginaryNum2 = double.Parse(Console.ReadLine());

            ComplexNumber ComplexNum1 = new ComplexNumber(RealNum1, ImaginaryNum1);
            ComplexNumber ComplexNum2 = new ComplexNumber(RealNum2, ImaginaryNum2);

            ComplexNum1.Add(ComplexNum2);
            Console.WriteLine($"Součet kompx čísel {ComplexNum1.Real} + {ComplexNum1.Imaginary} ");

            ComplexNum1.Subtract(ComplexNum2);
            Console.WriteLine($"Rozdíl kompx čísel {ComplexNum1.Real} - {ComplexNum1.Imaginary}");

            ComplexNum1.Multiply(ComplexNum2);
            Console.WriteLine($"Součin kompx čísel {ComplexNum1.Real} * {ComplexNum1.Imaginary}");

            ComplexNum1.Division(ComplexNum2);
            Console.WriteLine($"Podíl kompx čísel {ComplexNum1.Real} / {ComplexNum1.Imaginary}");

            Console.ReadKey();
        }
    }
    class ComplexNumber
    {
        public double Real;
        public double Imaginary;

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public void Add(ComplexNumber other)
        {
            Real += other.Real;
            Imaginary += other.Imaginary;
        }

        public void Subtract(ComplexNumber other)
        {
            Real -= other.Real;
            Imaginary -= other.Imaginary;
        }

        public void Multiply(ComplexNumber other)
        {
            Real = Real * other.Real - Imaginary - other.Imaginary;
            Imaginary = Imaginary * other.Imaginary - Real * other.Real;
        }

        public void Division(ComplexNumber other)
        {
            double TempReal = Real * other.Real + Imaginary * other.Imaginary;
            double TempReal2 = Math.Pow(other.Real, 2) + Math.Pow(other.Imaginary, 2);
            Real = TempReal / TempReal2;

            Double TempImag = Imaginary * other.Real - Real * other.Imaginary;
            Double TempImag2 = Math.Pow(other.Real, 2) + Math.Pow(other.Imaginary, 2);
            Imaginary = TempImag / TempImag2;
        }
    }
}