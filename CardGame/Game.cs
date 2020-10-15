using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    class Game
    {
        private Queue<Card> cardDeck;
        private List<Player> players;
        private const int countCards = 36;
        public Game(List<Player> players)
        {
            cardDeck = new Queue<Card>(countCards);
            this.players = new List<Player>(players);
            FillCardDeck();
        }
        public void FillCardDeck()
        {
            if (cardDeck.Count != 0)
                cardDeck.Clear();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cardDeck.Enqueue(new Card((SuitCard)j, (RankCard)i));
                }
            }
        }

        public void Show()
        {
            int count = 1;
            foreach (Card card in cardDeck)
            {

                Console.Write(card + " ");

                if (count % 4 == 0)
                    Console.WriteLine();
                count++;
            }
        }

        public void ShuffleDeck()
        {

            if (cardDeck.Count == 0)
                throw new InvalidOperationException("There are no cards in the deck.");
            List<Card> res = new List<Card>(cardDeck.ToList());
            cardDeck.Clear();
            Random random = new Random();
            for (int i = res.Count - 1; i >= 0; i--)
            {

                int j = random.Next(i + 1);
                Card tmp = res[j];
                res[j] = res[i];
                res[i] = tmp;
            }
            cardDeck = new Queue<Card>(res);
        }
        public void DistributionOfCards()
        {

            while( cardDeck.Count / players.Count >0)
            {
                foreach (var player in players)
                {
                    player.AddCard(cardDeck.Dequeue());
                }
            }
        }
        public void GamePlay()
        {
            ShuffleDeck();
            DistributionOfCards();
            int index = 0, round = 1;
            bool isWin = false;
            List<Card> receivedCards = new List<Card>(players.Count);
            do
            {
            
                Console.WriteLine("Round: " + round);
                Console.WriteLine("\nPlayers: ");
                foreach (var player in players)
                {
                    Console.WriteLine(new string('-', 30));
                    player.Show();
                    Console.WriteLine();
                }
               
                foreach (var player in players)
                {
                    if ( player.Cards.Count > 0)
                    {
                        Console.WriteLine(player.Nickname + " put " + player.Cards.Peek());
                        receivedCards.Add(player.Cards.Dequeue());
                    }
                }
                for (int i = 0; i < receivedCards.Count; i++)
                {
                    if (receivedCards[i]!=null &&  receivedCards[index].CompareTo(receivedCards[i]) < 0)
                        index = i;
                }
                Console.WriteLine("\nIn this round win " + players[index].Nickname);
                foreach (var card in receivedCards)
                {
                    players[index].AddCard(card);
                }
                for(int i=0;i<players.Count;i++)
                {
                    if (players[i].Cards.Count == 0)
                    {
                        var tmp = players[i];
                        for(int j = i; j < players.Count-1; j++)
                        {
                            players[j] = players[j+1];
                        }

                        players[players.Count - 1] = tmp;
  
                    }
                        
                }
                receivedCards.Clear();
                round++;
                if (players[index].Cards.Count == countCards - (countCards % players.Count))
                    isWin = true;
                index = 0;
               Console.ReadKey();
                Console.Clear();
            } while (!isWin);
            Console.WriteLine("\nWin game: " + players[index].Nickname);
        }
    }
}
