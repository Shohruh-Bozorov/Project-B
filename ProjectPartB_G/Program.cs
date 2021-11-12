using System;

namespace ProjectPartB_B1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            DeckOfCards myDeck = new DeckOfCards();
            myDeck.CreateFreshDeck();
            Console.WriteLine($"\nA freshly created deck with {myDeck.Count} cards:");
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA sorted deck with {myDeck.Count} cards:");
            myDeck.Sort();
            Console.WriteLine(myDeck);

            Console.WriteLine($"\nA shuffled deck with {myDeck.Count} cards:");
            myDeck.Shuffle();
            Console.WriteLine(myDeck);

            HandOfCards player1 = new HandOfCards();
            HandOfCards player2 = new HandOfCards();

            //Your code to play the game comes here
            int NumberOfCards = 0;
            int numberOfRounds = 0;

            #region userinput nr of rounds and cards related

            bool quit = false;

            Console.WriteLine("Let's play a game of highest card with 2 players.");

            while (!quit)
            {


                Console.WriteLine("How many cards to deal to each player? Enter a number from 1 to 5 (press q or Q to quit): ");
                quit = TryReadNrOfCards(out int NrOfCards);
                NumberOfCards = NrOfCards;

                if (!quit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWrong input try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

            quit = false;

            while (!quit)
            {


                Console.WriteLine("How many rounds should we play? Enter an number from 1 to 5: (press q or Q to quit):");
                quit = TryReadNrOfCards(out int NrOfRounds);
                numberOfRounds = NrOfRounds;

                if (!quit)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nWrong input try again!");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }

            #endregion userinput
            // done

            #region dealing cards and determine winner
            
            for (int i = 0; i < numberOfRounds; i++)
            {
                Deal(myDeck, NumberOfCards, player1, player2);
                Console.WriteLine($"Playing Round Nr {i+1}\n------------------");
                Console.WriteLine($"Gave {NumberOfCards} cards to each player. Deck has now {myDeck.Count} cards.\n");

                Console.WriteLine($"Player1 hand with {NumberOfCards} cards.");
                Console.WriteLine($"Lowest card in hand is {player1.Lowest} and highest is {player1.Highest}:");
                Console.WriteLine(player1+"\n");

                Console.WriteLine($"Player2 hand with {NumberOfCards} cards.");
                Console.WriteLine($"Lowest card in hand is {player2.Lowest} and highest is {player2.Highest}:");
                Console.WriteLine(player2+"\n");

                DetermineWinner(player1, player2);

                player1.Clear();
                player2.Clear();

            }   
            
            #endregion
            // done
        }

        /// <summary>
        /// Asking a user how many cards should be given to players.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfCards">Number of cards given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfCards(out int NrOfCards)
        {
            string input = Console.ReadLine();

            if (input == "q" || input == "Q" )
            {
                NrOfCards = 0;
                return true;
                
            }

            bool isNumber = int.TryParse(input, out int number);

            if (number != 0 && number <= 5)
            {
                NrOfCards = number;
                return true;
            }

            NrOfCards = 0;
            return false;
        }
        // done

        /// <summary>
        /// Asking a user to give how many round should be played.
        /// User enters an integer value between 1 and 5. 
        /// </summary>
        /// <param name="NrOfRounds">Number of rounds given by user</param>
        /// <returns>true - if value could be read and converted. Otherwise false</returns>
        private static bool TryReadNrOfRounds(out int NrOfRounds)
        {
            string input = Console.ReadLine();

            if (input == "q" || input == "Q")
            {
                NrOfRounds = 0;
                return true;

            }

            bool isNumber = int.TryParse(input, out int number);

            if (number != 0 && number <= 5)
            {
                NrOfRounds = number;
                return true;
            }

            NrOfRounds = 0;
            return false;

        }
        // done

        /// <summary>
        /// Removes from myDeck one card at the time and gives it to player1 and player2. 
        /// Repeated until players have recieved nrCardsToPlayer 
        /// </summary>
        /// <param name="myDeck">Deck to remove cards from</param>
        /// <param name="nrCardsToPlayer">Number of cards each player should recieve</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void Deal(DeckOfCards myDeck, int nrCardsToPlayer, HandOfCards player1, HandOfCards player2)
        {
            for (int i = 0; i < nrCardsToPlayer; i++)
            {
                player1.Add(myDeck.RemoveTopCard());
                player2.Add(myDeck.RemoveTopCard());
            }

        }
        // done
        
        /// <summary>
        /// Determines and writes to Console the winner of player1 and player2. 
        /// Player with higest card wins. If both cards have equal value it is a tie.
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        private static void DetermineWinner(HandOfCards player1, HandOfCards player2)
        {
            string winner = player1.Highest.CompareTo(player2.Highest) switch 
            { 
                1 => "Player1 wins",
                0 => "It's a Tie",
               -1 => "Player2 wins",
                _ => "Error"
            };

            Console.WriteLine(winner+"\n");
            
        }
        // done
    }
}
