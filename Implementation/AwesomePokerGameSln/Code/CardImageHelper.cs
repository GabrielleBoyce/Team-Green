using AwesomePokerGameSln.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePokerGameSln.Code {
    class CardImageHelper
    {
        public static Bitmap cardToBitmap(Tuple<int, int> card)
        {
            int face = card.Item1;
            int suit = card.Item2;

            string suitName = null;
            switch (suit)
            {
                case 0: suitName = "diamonds"; break;
                case 1: suitName = "spades"; break;
                case 2: suitName = "hearts"; break;
                case 3: suitName = "clubs"; break;
                default: suitName = ""; break;
            }

            // 0 - 12
            // 2 - 10, jack, queen, king, ace
            string faceName = null;
            if (face <= 8)
            {
                faceName = "_" + (face + 2).ToString();
            }
            else
            {
                switch (face)
                {
                    case 9: faceName = "jack"; break;
                    case 10: faceName = "queen"; break;
                    case 11: faceName = "king"; break;
                    case 12: faceName = "ace"; break;
                    default: faceName = ""; break;
                }
            }

            return Resources.ResourceManager.GetObject(faceName + "_of_" + suitName) as Bitmap;
        }
    }
}
