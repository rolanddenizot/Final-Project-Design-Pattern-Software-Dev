using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        public Board board_game = new Board();

        public void Initialization()
        {
            Console.Write("How Many Players ? ");
            int nbOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 0; i < nbOfPlayers; i++)
            {
                Console.Clear();
                Console.WriteLine("Player " + (i + 1));
                Console.Write("\nName: ");
                string name = Console.ReadLine();
                Player player = new Player(name);
                players.Add(player);
                Console.Write("\nPlayer " + player.name + " added\n");
                Console.ReadKey();
            }
        }

        public void StartGame()
        {
            int order = 0;
            int countOfSameValueDice = 0;
            int firstDice = -1;
            int secondDice = -2;
            string endGame = "N";
            while (endGame != "Y")
            {
                Console.Clear();
                if (order == players.Count)
                    order = 0;
                Player currentPlayer = players[order];
                Console.WriteLine("----- This is the tour of " + currentPlayer.GetSetName + " -----\n\n");
                countOfSameValueDice = 0;
                firstDice = -1;
                secondDice = -2;
                bool nextStep = false;
                while (nextStep != true)
                {
                    if (currentPlayer.jailed == false)
                    {
                        DisplayPosition(currentPlayer);
                        Random random = new Random();
                        firstDice = random.Next(1,7);
                        secondDice = random.Next(1, 7);
                        Console.Write("\nFirst Dice: " + firstDice);
                        Console.Write("\nSecond Dice: " + secondDice);
                        Console.WriteLine("\nTotal: " + (firstDice + secondDice));
                        Move(currentPlayer, firstDice + secondDice);
                        if(currentPlayer.GetSetPosition == 30)
                            nextStep = true;
                        DisplayPosition(currentPlayer);
                        if (firstDice != secondDice)
                            nextStep = true;
                        else
                            countOfSameValueDice++;
                        Console.ReadKey();
                        if (countOfSameValueDice >= 3)
                        {
                            Console.WriteLine("\n3 consecutive double dices, go to jail !");
                            currentPlayer.GetSetJailed = true;
                            currentPlayer.GetSetPosition = 10;
                            nextStep = true;
                        }
                    }
                    else
                    {
                        Random random = new Random();
                        firstDice = random.Next(1, 7);
                        secondDice = random.Next(1, 7);
                        Console.Write("\nFirst Dice: " + firstDice);
                        Console.Write("\nSecond Dice: " + secondDice);
                        if (firstDice == secondDice || currentPlayer.GetSetNbTourInJail >= 2)
                        {
                            currentPlayer.jailed = false;
                            currentPlayer.GetSetNbTourInJail = 0;
                            Console.WriteLine("\nYou're out of jail!");
                        }
                        else
                            currentPlayer.GetSetNbTourInJail++;
                        nextStep = true;
                    }
                }
                Console.Write("\n\nWould you like to stop the game ? (Y or press any key to No): ");
                endGame = Console.ReadLine();
                order++;
            }
            Console.Clear();
            Console.WriteLine("Game Ended");
        }

        public void Move(Player player, int nb)
        {
            if (player.position + nb < 40)
                player.position += nb;
            else
                player.position = player.position + nb - 40;
        }

        public void DisplayPosition(Player player)
        {
            Console.Write("\nYou are currently in position: ");
            if (player.position == 0)
                Console.WriteLine("Start square!");
            else if (player.position == 10 && player.jailed == true)
                Console.WriteLine("Jail square! You are in Jail");
            else if (player.position == 10)
                Console.WriteLine("Jail square! You are Visitor");
            else if (player.position == 30)
            {
                Console.WriteLine("Go to jail!");
                player.jailed = true;
                player.position = 10;
                Console.WriteLine("You are now in jail");
            }
            else
                Console.WriteLine(player.position);
        }
    }
}
