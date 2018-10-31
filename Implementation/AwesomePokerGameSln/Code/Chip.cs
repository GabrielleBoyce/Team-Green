using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePokerGameSln.Code
{
    class Chip
    {
        private int value;
        private ConsoleColor color;

        public Chip(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }
    }
}
