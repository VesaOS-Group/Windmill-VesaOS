﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos_1.Windmill.Lib
{
    static class Input
    {
        public static void FindFunction(Windmill super)
        {
            super.index++;
            switch (super.program[super.index - 1] % 16)
            {
                case 0x00:
                    Read(super);
                    break;
                case 0x01:
                    ReadLine(super);
                    break;
            }
        }

        public static void Read(Windmill super)
        {
            int loc = Memory.GetRamLoc(super);
            byte value = (byte) Console.Read();

            super.ram[loc] = value;
        }

        public static void ReadLine(Windmill super)
        {
            int loc = Memory.GetRamLoc(super);
            string input = Console.ReadLine() + (char) 0; //end of string
            for (int i = 0; i < input.Length; i++)
                super.ram[loc + i] = (byte) input[i];
        }
    }
}
