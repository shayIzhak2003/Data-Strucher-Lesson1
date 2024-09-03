using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Strucher_Lesson1.Classes.stackStrucher.stack_Objects.Card_Game
{
    public class RunGame2
    {
        public static Card[] handOutCards()
        {
            int i, j, k = 0;
            Card[] crArr = new Card[52];
            Random r = new Random();
            for (i = 0; i < 13; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    while (crArr[k] != null)
                    {
                        k = r.Next(52);
                    }
                    crArr[k] = new Card(i + 1, j + 1);
                }
            }
            return crArr;
        }
        public static int FiveWins(Game game)
        {
            int numOfWins = 0, numOfGames = 0;
            Card[] cr;
            while(numOfWins < 5)
            {
                numOfGames++;
                cr = handOutCards();
                if (game.IsWin(cr))
                {
                    numOfWins++;
                }
            }
            return numOfGames;
        }
        public static void DemoMain()
        {
            Game game = new Game();

            // Run the FiveWins function and get the number of games played to achieve 5 wins
            int gamesToWinFiveTimes = RunGame2.FiveWins(game);

            Console.WriteLine($"It took {gamesToWinFiveTimes} games to achieve 5 wins.");
        }
    }
}
