 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePokerGameSln.Code {
  public enum HandType {
    ROYAL_FLUSH,
    STR_FLUSH,
    FOUR,
    FULL_HOUSE,
    FLUSH,
    STRAIGHT,
    THREE,
    TWO_PAIRS,
    ONE_PAIR,
    HIGH
  }

  public class Hand {
    private Tuple<int, int>[] cards;
    private int handScore; //9 is worst, high by default

    public Hand(Tuple<int, int>[] cards) {
      this.cards = cards;
    }

    public HandType getHandType() {
      HandType handType = HandType.HIGH;
      handScore = 9;



      int[] faces = cards.Select(card => card.Item1).ToArray();
      int uniqueCount = faces.Distinct().Count();
      switch (uniqueCount) {
        // flush, straight, str_flush, ryl_flush
        case 5: {
            // flush
            int[] suits = cards.Select(card => card.Item2).ToArray();
            if (suits.Distinct().Count() == 1) {
              handType = HandType.FLUSH;
              handScore = 4;
            }

            // straight
            Array.Sort(faces);
            int min = faces[0];
            int max = faces[faces.Length - 1];
            // A 2 3 4 5
            if ((max == 12 && faces[faces.Length - 2] == 3) ||
                 max - min == faces.Length - 1) {
              if (handType == HandType.FLUSH) {
                if (max == 12 && faces[faces.Length - 2] == 11) {
                  handType = HandType.ROYAL_FLUSH;
                  handScore = 0;
                          }
                else
                  handType = HandType.STR_FLUSH;
                  handScore = 1;
              }
              else {
                handType = HandType.STRAIGHT;
                handScore = 5;
              }
            }
          }
          break;

        case 4:
          // one pair
          handType = HandType.ONE_PAIR;
          handScore = 8;
          break;

        case 3: {
            // two pair, three of a kind
            int x = faces[0];
            int freq = cards.Count(card => card.Item1 == x);
            if (freq == 1) {
              x = faces[1];
              freq = cards.Count(card => card.Item1 == x);
              if (freq == 2) {
                handType = HandType.TWO_PAIRS;
                handScore = 7;
              }
              else {
                handType = HandType.THREE;
                handScore = 6;
              }
            }
            else if (freq == 2) {
              handType = HandType.TWO_PAIRS;
              handScore = 7;
            }
            else if (freq == 3) {
              handType = HandType.THREE;
              handScore = 6;
            }

          }
          break;

        // full house or four of a kind
        case 2: {
            int x = faces[0];
            int freq = cards.Count(card => card.Item1 == faces[0]);
            if (freq == 2 || freq == 3) {
              handType = HandType.FULL_HOUSE;
              handScore = 3;
            }
            else {
              handType = HandType.FOUR;
              handScore = 2;
            }
          }
          break;
      }

      return handType;
    }

    public int getHandScore() {
      getHandType();
      return handScore;
    }
  }
}
