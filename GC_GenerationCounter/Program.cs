
using System;

namespace GC_GenerationCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            GcAnalyzer analyzer = new GcAnalyzer();

            while (true)
            {
                try
                {
                    Console.WriteLine("=== Контрольная точка №40: GC в .NET 10 ===");
                    Console.WriteLine("1. Запустить эксперимент со счётчиком поколений");
                    Console.WriteLine("2. Выход");
                    Console.Write("Выберите действие: ");
                    string? choice = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(choice) || choice.Trim().ToLower() == "stop" || choice == "2")
                    {
                        break;
                    }

                    if (choice == "1")
                    {
                        analyzer.RunExperiment();
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}