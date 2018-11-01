using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePokerGameSln.Code
{
    class Chip
    {
        private int value;
        private Color color;

        // Only handles the following values: 1, 5, 10, 25, 100
        public Chip(int value)
        {
            this.value = value;
            computeColor();
        }

        public int getValue()
        {
            return value;
        }
        
        public Color getColor()
        {
            return color;
        }

        public void computeColor()
        {
            if(value == 1)
            {
                color = Color.White;
            }
            else if(value == 5)
            {
                color = Color.Red;
            }
            else if(value == 10)
            {
                color = Color.Blue;
            }
            else if(value == 25)
            {
                color = Color.DarkGreen;
            }
            else if(value == 100)
            {
                color = Color.Gold;
            }
        }
    }
}
