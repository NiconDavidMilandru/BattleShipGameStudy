using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace BattleShipLibrary
{
    public class UserMessages
    {
        public static void GreetUser()
        {
            Console.WriteLine("Welcome to the BattleShip Game!");
            Console.WriteLine("-------------------------------");
        }
        public static void Mode3()
        {
            Console.WriteLine("You chosed the Computer vs Computer mode!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Rules of the game");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The grid is formed by 10x10 squares.");
            Console.WriteLine("The Carrier has a length of 5 squares.");
            Console.WriteLine("The Battleship has a length of 4 squares.");
            Console.WriteLine("The Cruiser has a length of 3 squares.");
            Console.WriteLine("The Submarine has a length of 2 squares.");
            Console.WriteLine("The Mine has a length of 1 square.");
            Console.WriteLine("-------------------------------");
        }
        public static int Rounds()
        {
            int result;
            while (true)
            {
                Console.Write("How many rounds do you want to play: ");
                bool ok = int.TryParse(Console.ReadLine(), out result);
                if (ok && result > 0)
                {
                    Console.WriteLine("-------------------------------");
                    return result;
                }
                Console.WriteLine("That is not a valid number!");
                Console.WriteLine("-------------------------------");
            }
            return 0;
        }
        public static void InfoAboutDiff()
        {
            Console.WriteLine("AI Algorithms");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The easy bot only makes random guesses.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The medium bot initially calculates the probability of each square as a function of all the positions that each ship can have on the grid. After that it calculates the square with the max probability and shoots there. If it is a hit then starts a hunt and target algorithm in order to sink the whole ship. It calculates the next maximum but on the same initial probabilities and so on until all the ships are sunked.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The hard bot shoots randomly and starts a hunt and target algorithm when it hits a ship. It is faster in practice than the medium bot, proving that random guesses are better than initial probabilities.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The impossible bot uses the same principles as the medium bot but after each shot the probability of each square is recalculated.");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("Average moves to win the game");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Easy bot: 91 moves");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Medium bot: 59 moves");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Hard bot: 47 moves");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Impossible bot: 37 moves");
            Console.WriteLine("-------------------------------");
        }
        public static char Cell(int x)
        {
            switch (x)
            {
                case 0:
                    return '-';
                case 5:
                    return 'C';
                case 4:
                    return 'B';
                case 3:
                    return 'c';
                case 2:
                    return 'D';
                case 1:
                    return 'M';
                case -1:
                    return 'x';
            }
            return '-';
        }
        public static void GridView(GridModel grid)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                    Console.Write($"{Cell(grid.Grid[i][j])} ");
                Console.WriteLine();
            }
        }
        public static string ChooseDiff(int n)
        {
            string result;
            while (true)
            {
                Console.Write($"Which difficulty would you want for bot{n} (easy/medium/hard/impossible): ");
                result = Console.ReadLine();
                result = result.ToLower();
                if (result=="easy" || result=="medium" || result=="hard" || result=="impossible")
                {
                    Console.WriteLine("----------------------------------------------------------------");
                    return result;
                }
                Console.WriteLine("That is not a valid difficulty!");
                Console.WriteLine("----------------------------------------------------------------");
            }
            return "0";
        }
        public static void Statistics(int wins1, int wins2, int moves1, int moves2,int draws)
        {
            Console.WriteLine("Welcome to the statistics!");
            Console.WriteLine("-------------------------------");
            int rounds = wins1 + wins2 + draws;
            double p1 = (double) (wins1) / (double) (rounds) * 100.0;
            double m1 = (double) (moves1) / (double) (wins1);

            double p2 = (double)(wins2) / (double)(rounds) * 100.0;
            double m2 = (double)(moves2) / (double)(wins2);

            double p3 = (double)(draws) / (double)(rounds)*100.0;

            Console.WriteLine($"Player 1 won {wins1} games, which is {p1}% of the total rounds.");
            Console.WriteLine($"Player 1 won with an average of {m1} moves.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Player 2 won {wins2} games, which is {p2}% of the total rounds.");
            Console.WriteLine($"Player 2 won with an average of {m2} moves.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"There were {draws} draws, which is {p3}% of the total rounds.");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"The win gap is {Calculations.AbsInt(wins1 - wins2)}, which is {Calculations.AbsDouble(p1-p2)}% of the total rounds.");
            int mini, maxi;
            if (wins1 > wins2)
            {
                maxi = wins1;
                mini = wins2;
            }
            else
            {
                maxi = wins2;
                mini = wins1;
            }
            double p4 = (double) (mini)/ (double) (maxi)*100.0;
            Console.WriteLine($"The number of player wins is {p4}% alike.");
        }
    }
}
