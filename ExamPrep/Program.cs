using System;

namespace ExamPrep
{
    internal class Program
    {
        const int MealTranscations = 10;
        const int MealPrice = 65;
        const int AgeUpto16years = 85;
        const int Adult = 125;

        static void Main(string[] args)
        {
            char choice;
            int TranscationCount = 0;
            int[] FinalTranscation = new int[MealTranscations];
            double[] weights = new double[MealTranscations];
            double maxWeight = 0;
            int winnerCatch = 0;

            do
            {
                int EntranceFee = CalcEntry();
                int Meals = GetMeals();

                int FinalAmount = EntranceFee + (Meals * MealPrice);
                FinalTranscation[TranscationCount] = FinalAmount;
                TranscationCount++;

                Console.WriteLine("The amount due is {0:C}", FinalAmount);
                Console.WriteLine();
                Console.Write("Are there more Competitors (Y/N): ");
                choice = char.Parse(Console.ReadLine());
                choice=char.ToUpper(choice);
                Console.WriteLine();

                if (choice == 'N' || TranscationCount == MealTranscations)
                    break;

            } while (true);

            for (int i = 0; i < TranscationCount; i++)
            {
                (maxWeight, winnerCatch) = RecordWeight(i+1, weights, maxWeight, winnerCatch);
                Console.WriteLine("Competitor {0} wins the competition with a catch of {1}", winnerCatch, maxWeight);
            }

            Console.ReadLine();
        }

        static int CalcEntry()
        {
            int CompetitorsAge, NumberOfdays, EntranceFee;
            Console.Write("Enter Competitors age: ");
            CompetitorsAge = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of days: ");
            NumberOfdays = int.Parse(Console.ReadLine());

            if (CompetitorsAge <= 16)
            {
                EntranceFee = AgeUpto16years * NumberOfdays;
            }
            else
            {
                EntranceFee = Adult * NumberOfdays;
            }

            return EntranceFee;
        }

        static int GetMeals()
        {
            int Meals;
            do
            {
                Console.Write("Enter the number of Meals: ");
                Meals = int.Parse(Console.ReadLine());
            } while (Meals < 0 || Meals > 9);

            return Meals;
        }

        static (double, int) RecordWeight(int CompetitorEntryNumber, double[] weight, double maxWeight, int winnerCatch)
        {
            double Weight;
            Console.WriteLine("Recording the catches");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter the catch weight for Competitor {0}: ", i + 1);
                Weight = double.Parse(Console.ReadLine());
                weight[CompetitorEntryNumber-1 ] = Weight;

                if (Weight > maxWeight)
                {
                    maxWeight = Weight;
                    winnerCatch = CompetitorEntryNumber;
                }
            }
            return (maxWeight, winnerCatch);
        }
    }
}
