using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Player
    {
        public string Nickname { get; set; }

      
        public Queue<Card> Cards { get; }
        public Player(string nickname)
        {
            Nickname = nickname;
            Cards = new Queue<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Enqueue(card);
        }
        public void Show()
        {
            Console.WriteLine("Nickname: "+Nickname);
            int count = 1;
            foreach (var card in Cards)
            {
                Console.WriteLine(card);
                if(count%4==0)
                    Console.WriteLine();
                count++;
            }
        }
        public Card PutCard()
        {
            return Cards.Dequeue();
        }

    }
}
