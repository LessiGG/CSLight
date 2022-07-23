using System;
using System.Collections.Generic;

namespace CSLight
{
    class DeckOfCards
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.ShuffleDeck();

            Player player = new Player();

            while (player.IsPlaying)
            {
                Console.WriteLine("[1] Вытянуть одну карту [2] Вытянуть несколько карт [3] Завершить игру и увидеть вытянутые карты [4] Выход");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        player.GetCard(deck);
                        break;
                    case "2":
                        player.GetMultipleCards(deck);
                        break;
                    case "3":
                        player.ShowCards();
                        break;
                    case "4":
                        player.FinishTheGame();
                        break;
                    default:
                        Console.WriteLine("Неизвестная операция.");
                        break;
                }
            }
        }
    }

    enum CardType
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

    enum CardValue
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    class Card
    {
        private CardType _cardType;
        private CardValue _cardValue;

        public Card(CardType cardType, CardValue cardValue)
        {
            _cardType = cardType;
            _cardValue = cardValue;
        }

        public void ShowCard()
        {
            Console.WriteLine($"The {_cardValue} of {_cardType}");
        }
    }

    class Deck
    {
        private Random _random = new Random();
        private List<Card> _deck = new List<Card>(52);

        private int _cardTypesNumber = 4;
        private int _minCardValue = 1;
        private int _maxCardValue = 13;

        public Deck()
        {
            for (int cardType = 0; cardType < _cardTypesNumber; cardType++)
            {
                for (int cardValue = _minCardValue; cardValue <= _maxCardValue; cardValue++)
                {
                    _deck.Add(new Card((CardType)cardType, (CardValue)cardValue)); 
                }
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            int deckCount = _deck.Count;

            while (deckCount > 1)
            {
                deckCount--;
                int randomValue = random.Next(deckCount + 1);
                (_deck[randomValue], _deck[deckCount]) = (_deck[deckCount], _deck[randomValue]);
            }
        }

        public bool AreCardsLeft()
        {
            return _deck.Count > 0;
        }
        
        public bool TryGetCard(out Card card)
        {
            if (_deck.Count > 0)
            {
                card = _deck[GetCardValue()];
                _deck.Remove(card);
                return true;
            }

            card = null;
            return false;
        }

        private int GetCardValue()
        {
            int minCardValue = 0;
            int maxCardValue = _deck.Count;
            int cardValue = _random.Next(minCardValue, maxCardValue);
            
            return cardValue;
        }
    }

    class Player
    {
        private List<Card> _playerCards = new List<Card>(52);

        public bool IsPlaying { get; private set; } = true;

        public void FinishTheGame()
        {
            IsPlaying = false;
        }
        
        public void GetCard(Deck deck)
        {
            if (deck.TryGetCard(out Card card))
            {
                _playerCards.Add(card);                
            }
            else
            {
                Console.WriteLine("В колоде закончились карты");
            }
        }
        public void GetMultipleCards(Deck deck)
        {
            Console.WriteLine("Сколько карт вы хотите вытянуть?");
            int.TryParse(Console.ReadLine(), out int result);
            
            if (deck.AreCardsLeft() == false)
            {
                Console.WriteLine("В колоде закончились карты");
            }
            
            for (int i = 0; i < result; i++)
            {
                if (deck.TryGetCard(out Card card))
                {
                    _playerCards.Add(card);
                }
            }
        }

        public void ShowCards()
        {
            Console.WriteLine("Вытянутые карты:");

            foreach (var playerCard in _playerCards)
            {
                playerCard.ShowCard();
            }
            
            FinishTheGame();
        }    
    }
}
