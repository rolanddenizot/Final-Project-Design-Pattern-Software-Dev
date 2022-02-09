using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to the Monopoly created by Roland DENIZOT and Zachary CHENOT, ESILV A4 DIA2, 2021\n\n");
            Game monopoly = new Game();
            monopoly.Initialization();
            monopoly.StartGame();
            Console.ReadKey();
        }
    }
}
