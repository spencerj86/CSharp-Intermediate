using System;
using Lab2_cl;

namespace lab2_blackjackobjects
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuChoice = 0; //initialize an integer for choosing a menu
            while (menuChoice != 3) // runs this loop while the player hasn't chosen 3: Exit
            {
                Console.Clear(); // Clear Console every loop
                string[] mainMenu = new string[] { "1. Play BlackJack", "2. Shuffle and Show Deck", "3. Exit" }; // General Menu stuffs
                ReadChoice("Choice: ", mainMenu, out menuChoice); // Call the read choice method
                switch (menuChoice) // A switch statement for menu options
                {
                    case 1: //KeyPress 1
                        Console.WriteLine("Coming Soon!");
                        break;
                    case 2: //KeyPress 2
                        ShuffleAndShowDeck(); //Call ShuffleAndShowDeck Method
                        break; // Gotta go!
                }
                Console.WriteLine("\n\nPress any key to continue..."); //Communication is key
                Console.ReadKey(); // Will wait for keypress before loop or exit
            }
        }

        private static void ShuffleAndShowDeck() // initialize a method to shuffle and show the deck
        {
            Console.Clear(); // Clear menu
            Deck newDeck = new Deck(); // Creating a new deck!
            newDeck.Shuffle(); // Calls Shuffle method from Deck Class
            Hand newHand = new Hand(); // Creating a new hand
            for (int i = 0; i < 52; i++) // Creates a hand of 52 cards
            {
                newHand.AddCard(newDeck.Deal()); // calls AddCard Method from Hand Class and Deal Method from Deck Class
            }
            newHand.Draw(1, 1); // Calls Draw Method from Card Class, beginning at x 1, y 1
        }
        private static void ReadChoice(string prompt, string[] options, out int selection)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            selection = ReadInteger(prompt, 1, options.Length);
        }
        private static int ReadInteger(string prompt, int min, int max) 
        {
            while (true)
            {
                Console.Write(prompt); 
                string input = Console.ReadLine(); 
                if (int.TryParse(input, out int answer) && answer >= min && answer <= max)
                    return answer; 

                Console.WriteLine($"{input} is not valid...");
            }
        }
    }
}
