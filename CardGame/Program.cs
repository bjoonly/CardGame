using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(new List<Player> { new Player("First player"), new Player("Second player"),new Player("Third player"),new Player("Fourth player") });
            game.GamePlay();
        }
    }
}



