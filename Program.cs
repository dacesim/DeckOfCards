
//  a deck of cards is just one component of a complete poker game. In addition to a deck of cards, a typical poker game will involve multiple players, a dealer, and various rounds of betting and card dealing.
// So to implement poker game, we need to create additional classes to represent the other components of this game.
// - Player : class to represent each player in the game.
// - Round : class to represent each round of betting and card dealing.
// - Dealer : class to manage the game flow and coordinate the actions of the players.

using System;

public class Card
{
    public string Suit { get; set; }
    public string Rank { get; set; }

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
    }
}

public class Deck
{
    private Card[] cards = new Card[52];
    private int cardsInDeck = 0;

    public Deck()
    {
        string[] suits = new string[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        string[] ranks = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                cards[cardsInDeck++] = new Card(suit, rank);
            }
        }
    }

    public void Shuffle()
    {
        Random random = new Random();

        // Shuffle the deck by iterating through the deck and swapping each card with a randomly chosen card
        for (int i = 0; i < cardsInDeck; i++)
        {
            int j = random.Next(i, cardsInDeck);

            // Swap card i with card j
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DealOneCard()
    {
        if (cardsInDeck == 0)
        {
            return null;
        }

        Card card = cards[--cardsInDeck];
        cards[cardsInDeck] = null;
        return card;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();
        deck.Shuffle();

        // Deal all the cards from the deck
        for (int i = 0; i < 52; i++)
        {
            Card card = deck.DealOneCard();
            if (card != null)
            {
                Console.WriteLine(card.Rank + " of " + card.Suit);
            }
            else
            {
                Console.WriteLine("No more cards in the deck");
                break;
            }
        }
    }
}
