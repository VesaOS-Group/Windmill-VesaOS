using System;

namespace Cosmos_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Windmill.Windmill runner = new Windmill.Windmill(256, new byte[]
            {
                //add "Input: " to memory starting at loc 0x0F
                0x12, 0x00, 0x00, 0x00, 0x0F, 0x49, 0x6E, 0x70, 0x75, 0x74, 0x3A, 0x20, 0x00,
                //print string starting at loc 0x0F
                0x21, 0x00, 0x00, 0x00, 0x0F, 
                //add input to memory starting at loc 0x2F
                0x31, 0x00, 0x00, 0x00, 0x2F,
                //print string starting at loc 0x0F
                0x21, 0x00, 0x00, 0x00, 0x2F, 
                //end program
                0x00,
            });

            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (; !runner.program[runner.index].Equals(0);)
                runner.RunNext();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.Write("\n-Program exited. Execution time: " + elapsedMs + "-\n");

            if (false) //enable or disable memory map
            {
                Console.Write("\n-Memory map-\n");
                for (int i = 0; i < 256;)
                {
                    Console.Write(i + " -> ");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write("0x" + runner.ram[i].ToString("X") + " ");
                        i++;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
