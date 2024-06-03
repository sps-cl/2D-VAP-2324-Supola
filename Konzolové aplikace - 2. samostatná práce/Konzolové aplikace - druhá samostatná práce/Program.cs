using System;

namespace ComplexNumberApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Přečtení a parsování vstupů pro první komplexní číslo
            Console.WriteLine("Zadejte reálnou část prvního komplexního čísla:");
            double real1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte imaginární část prvního komplexního čísla:");
            double imaginary1 = double.Parse(Console.ReadLine());

            // Přečtení a parsování vstupů pro druhé komplexní číslo
            Console.WriteLine("Zadejte reálnou část druhého komplexního čísla:");
            double real2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Zadejte imaginární část druhého komplexního čísla:");
            double imaginary2 = double.Parse(Console.ReadLine());

            // Vytvoření instancí komplexních čísel
            ComplexNumber complex1 = new ComplexNumber(real1, imaginary1);
            ComplexNumber complex2 = new ComplexNumber(real2, imaginary2);

            // Výpočet a výpis součtu
            ComplexNumber sum = complex1.Add(complex2);
            Console.WriteLine($"Součet: {sum.Real} + {sum.Imaginary}i");

            // Výpočet a výpis rozdílu
            ComplexNumber difference = complex1.Subtract(complex2);
            Console.WriteLine($"Rozdíl: {difference.Real} + {difference.Imaginary}i");

            // Výpočet a výpis součinu
            ComplexNumber product = complex1.Multiply(complex2);
            Console.WriteLine($"Součin: {product.Real} + {product.Imaginary}i");

            // Výpočet a výpis podílu
            ComplexNumber quotient = complex1.Divide(complex2);
            Console.WriteLine($"Podíl: {quotient.Real} + {quotient.Imaginary}i");

            Console.ReadKey();
        }
    }

    class ComplexNumber
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        // Konstruktor pro inicializaci komplexního čísla
        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Metoda pro sčítání komplexních čísel
        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
        }

        // Metoda pro odčítání komplexních čísel
        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
        }

        // Metoda pro násobení komplexních čísel
        public ComplexNumber Multiply(ComplexNumber other)
        {
            double newReal = Real * other.Real - Imaginary * other.Imaginary;
            double newImaginary = Real * other.Imaginary + Imaginary * other.Real;
            return new ComplexNumber(newReal, newImaginary);
        }

        // Metoda pro dělení komplexních čísel
        public ComplexNumber Divide(ComplexNumber other)
        {
            double denominator = other.Real * other.Real + other.Imaginary * other.Imaginary;
            double newReal = (Real * other.Real + Imaginary * other.Imaginary) / denominator;
            double newImaginary = (Imaginary * other.Real - Real * other.Imaginary) / denominator;
            return new ComplexNumber(newReal, newImaginary);
        }
    }
}
