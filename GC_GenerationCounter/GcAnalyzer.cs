using System;

namespace GC_GenerationCounter
{
    public class GcAnalyzer
    {
        public void RunExperiment()
        {
            int gen0Before = GC.CollectionCount(0);
            int gen1Before = GC.CollectionCount(1);
            int gen2Before = GC.CollectionCount(2);
            long heapBefore = GC.GetGCMemoryInfo().HeapSizeBytes;

            Console.WriteLine("Начальное состояние:");
            Console.WriteLine($"Gen0 сборок: {gen0Before}");
            Console.WriteLine($"Gen1 сборок: {gen1Before}");
            Console.WriteLine($"Gen2 сборок: {gen2Before}");
            Console.WriteLine($"Размер кучи (HeapSizeBytes): {heapBefore:N0} байт\n");

            Console.WriteLine("Выделение 200 000 короткоживущих массивов (new byte[50])...");
            for (int i = 0; i < 200_000; i++)
            {
                byte[] temp = new byte[50];
            }

            int gen0AfterShort = GC.CollectionCount(0);
            int gen1AfterShort = GC.CollectionCount(1);
            int gen2AfterShort = GC.CollectionCount(2);

            Console.WriteLine("После короткоживущих объектов:");
            Console.WriteLine($"Gen0 сборок: {gen0AfterShort} (прирост: {gen0AfterShort - gen0Before})");
            Console.WriteLine($"Gen1 сборок: {gen1AfterShort} (прирост: {gen1AfterShort - gen1Before})");
            Console.WriteLine($"Gen2 сборок: {gen2AfterShort} (прирост: {gen2AfterShort - gen2Before})\n");

            Console.WriteLine("Аллокация 5 крупных объектов (> 85 000 байт, new byte[90_000])...");
            byte[][] largeObjects = new byte[5][];
            for (int i = 0; i < 5; i++)
            {
                largeObjects[i] = new byte[90_000];
            }

            int gen0AfterLarge = GC.CollectionCount(0);
            int gen1AfterLarge = GC.CollectionCount(1);
            int gen2AfterLarge = GC.CollectionCount(2);
            long heapAfter = GC.GetGCMemoryInfo().HeapSizeBytes;

            Console.WriteLine("После крупных объектов (LOH):");
            Console.WriteLine($"Gen0 сборок: {gen0AfterLarge} (прирост: {gen0AfterLarge - gen0AfterShort})");
            Console.WriteLine($"Gen1 сборок: {gen1AfterLarge} (прирост: {gen1AfterLarge - gen1AfterShort})");
            Console.WriteLine($"Gen2 сборок: {gen2AfterLarge} (прирост: {gen2AfterLarge - gen2AfterShort})");
            Console.WriteLine($"Размер кучи (HeapSizeBytes): {heapAfter:N0} байт (разница: {heapAfter - heapBefore:N0} байт)\n");

            GC.KeepAlive(largeObjects);
        }
    }
}