using System;
using System.Linq;

namespace WorkNamespace
{
    class MainClass
    {
        static void Main()
        {
            while (true)
            {
                // Výzva pro uživatele k zadání sekvence čísel oddělených čárkou
                Console.WriteLine("Zadej sekvenci čísel oddělené čárkou.");
                string input = Console.ReadLine();
                string[] splitInput = input.Split(',');

                try
                {
                    // Převod vstupu na pole čísel
                    int[] numberArray = splitInput.Select(int.Parse).ToArray();

                    // Najití minimálního a maximálního čísla v poli
                    int minNumber = numberArray.Min();
                    int maxNumber = numberArray.Max();

                    // Výpočet délky nejdelšího vzestupného intervalu
                    int longestAscendingSequence = FindLongestAscendingSequence(numberArray);

                    // Výpis výsledků
                    Console.WriteLine($"Nejmenší číslo je {minNumber}.");
                    Console.WriteLine($"Největší číslo je {maxNumber}.");
                    Console.WriteLine($"Délka nejdelšího vzestupného intervalu je {longestAscendingSequence}.");
                }
                catch (FormatException)
                {
                    // Výpis chybové zprávy při neplatném vstupu
                    Console.WriteLine("Zadaný znak není platné číslo. Opravte vstup a zkuste to znovu.");
                }
            }
        }

        // Metoda pro nalezení nejdelšího vzestupného intervalu v poli čísel
        static int FindLongestAscendingSequence(int[] numbers)
        {
            int maxSequenceLength = 0;
            int currentSequenceLength = 1;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    currentSequenceLength++;
                }
                else
                {
                    // Aktualizace maximální délky sekvence a reset aktuální délky
                    maxSequenceLength = Math.Max(maxSequenceLength, currentSequenceLength);
                    currentSequenceLength = 1;
                }
            }

            // Kontrola a aktualizace maximální délky sekvence po posledním prvku
            maxSequenceLength = Math.Max(maxSequenceLength, currentSequenceLength);
            return maxSequenceLength;
        }
    }
}
