using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PG2_Histogram
{
    class Program
    {
        static Dictionary<string, int> speechDictionary; //putting this in class makes this dictionary available to the entire class with static.
        static string speech; //putting this in class makes this string available to the entire class with static.
        static char[] wordDelimiters = new char[] { ',', ' ', '.', '\n', '\t', '\r', '!', ':', ';', '\"' }; //Delimiters will be used by Split method
        static char[] sentenceDelimiters = new char[] { '.', '!', '\n' }; //Delimiters to seperate by sentence


        public static void Main(string[] args) // this is default stuff
        {
            speech = GetSpeechFromFile(); //Grabs the speech from the GetSpeech method to make it available to the main method.
            List<String> seperate = new List<string>(speech.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries)); // Puts the split speech into a list of strings containing the individual words
            speechDictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase); //creates a dictionary that will make uppercase letters insignificant

            foreach (string value in seperate) // takes the list of split words and searches through every individual value
            {
                if (speechDictionary.ContainsKey(value)) //checks to see that while searching through the list, that it contains a word that has already been found
                    speechDictionary[value]++; // adds to the counter of that entry
                else // if the search has not yielded this specific result before
                    speechDictionary.Add(value, 1); //adds the entry into the dictionary, with a counter starting at 1.
            }
            int menuChoice = 0; // initializes the variable, so that we can use it throughout this method



            while (menuChoice != 6) // will loop as long as "6" is not pressed.
            {
                Console.Clear(); //Every new loop will clear the console.
                string[] mainMenu = new string[] { "1: Show Histogram", "2: Search for Word", "3: Save Histogram", "4: Load Histogram", "5: Remove Word", "6: Exit" };
                ReadChoice("Select an option ", mainMenu, out menuChoice); // takes the ReadChoice method and Passes by Reference specific options stated in parameters.

                switch (menuChoice) // a switch statement using the menuChoice variable, previously initialized
                {
                    case 1:
                        Histogram(); // will call the Histogram method
                        break; //to ensure that only one option can be selected
                    case 2:
                        SearchWord(); // will call the SearchWord method
                        break; //to ensure that only one option can be selected
                    case 3:
                        SaveFile();
                        break; //to ensure that only one option can be selected
                    case 4:
                        LoadFile();
                        break; //to ensure that only one option can be selected
                    case 5:
                        RemoveWord();
                        break; //to ensure that only one option can be selected
                }
                Console.ReadKey(); //Will wait for a key press to revert to the beginning of the loop.
            }
        }

        private static void RemoveWord() // creates a method to call in order to remove a word from the ditionary speech.Dictionary
        {
            string searchKey = string.Empty; // initialize string
            ReadString("What would you like to DESTROY?! ", ref searchKey); // calls ReadString method to ask a question and return the answer to variable searchKey
            try //really hard
            {
                if (speechDictionary[searchKey] > 0) //checking to see if the search key has more than 0 members in the dictionary 
                {
                    speechDictionary.Remove(searchKey); // removes said key from the dictionary

                    Console.WriteLine($"{searchKey} successfully incinerated..."); // explain whats happening (while being funny, if i do say so.)
                }
            }
            catch (Exception) // when user inputs something that doesn't exist
            {
                Console.WriteLine($"{searchKey} was not located..."); //lets the user know what they typed, and that it doesn't exist. DO NOT insult them. Bad James...
            }
        }

        private static void LoadFile() //creates a method to call to load a file from the program directory (bin, debug, etc.)
        {
            string fileName = String.Empty; // Initiate cadet fileName
            ReadString("Load which file? ", ref fileName); // send fileName to battle
            if (File.Exists(fileName)) //welfare check on fileName
            {
                string stringData = File.ReadAllText(fileName); // get the cadet's encrypted file.

                try // really hard
                {
                    speechDictionary = JsonConvert.DeserializeObject<Dictionary<string, int>>(stringData); //deciphering cadet's file
                    Console.WriteLine($"{speechDictionary.Count} items delivered."); // report to the superior of the juicy intel
                }
                catch (Exception ex) // send apology to cadet's family
                {
                    Console.WriteLine($"$*@(% ERROR CODE: {ex}"); //crying wife, blah blah blah
                }
            }
            else //cannot find cadet's file
            {
                Console.WriteLine($"Terribly sorry, I cannot seem to locate {fileName}"); //Cadet never existed: REDACTED
            }
        }

        private static void SaveFile() //create method to save a file
        {

            string fileName = String.Empty; //initiate agent report
            ReadString("What's the file's name? ", ref fileName); // grab information from the mission from the agent
            if ((Path.HasExtension(fileName) && Path.GetExtension(fileName) != ".json") || !Path.HasExtension(fileName)) // make sure the report is TOP SECRET
            {
                fileName = Path.ChangeExtension(fileName, ".json"); //Make it top secret
            }
            using (StreamWriter sw = new StreamWriter(fileName)) //create a crayon to write file
            {
                using (JsonTextWriter jtw = new JsonTextWriter(sw)) //create a pencil to write encryption
                {
                    jtw.Formatting = Formatting.Indented; //convert from crayon to pencil

                    JsonSerializer serializer = new JsonSerializer(); // Photocopying Jason in accounting's son's drawings
                    serializer.Serialize(jtw, speechDictionary); //using Jason in accounting's son's drawings to encrypt the report
                }
            }
            Console.WriteLine($"Save complete: {fileName}"); //REDACTED

        }

        private static void SearchWord()
        {
            string[] senSplit = speech.Split(sentenceDelimiters, StringSplitOptions.RemoveEmptyEntries); //splitting the speech method by sentence
            string input = String.Empty; //initializing the string input
            ReadString("Choose a bird.. I mean, a WORD: ", ref input); //calls ReadString method, passes by value prompt, and by ref string

            if (speechDictionary.ContainsKey(input)) //If the user input is contained within the histoSpeech Dictionary
            {
                PrintWordSoup(input); // call on the PrintWordSoup method to print the blah blah that was taking up too much space without a method
                Console.WriteLine(); // obligatory space
                foreach (string item in senSplit) //goes through the senSplit array to find every sentence, and naming it item
                {
                    foreach (string word in item.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries)) // goes through the item string and seperating by word
                    {
                        if (word.ToLower() == input.ToLower()) // ToLower, to check for case(just in case) and if the user input is equivalent to the word its checking for
                        {
                            Console.WriteLine($"{item.TrimStart(' ')}"); //print that item, also TrimStart ' ' makes the spaces that were happening go away at the beginning of the line
                            break; //point
                        }
                    }
                }
            }
            else // user input is not contained within the histoSpeech dictionary
                Console.WriteLine($"That bird '{input}' is not the word..."); //public speaking is hard...
        }

        private static void PrintWordSoup(string input) //a method that is void, but passes string input
        {
            Console.Write($"{input,15}\t\t"); //prints that input, ending letter being at 15 spaces
            Console.BackgroundColor = ConsoleColor.DarkYellow; //lol Prof. Girod hates this color. Hello! ;)
            for (int i = 0; i < speechDictionary[input]; i++) //for loop to get through the speechDictionary
            {
                Console.Write(" "); // writes a space for every time the input is in speech dictionary
            }
            Console.ResetColor(); //making a nifty bar that helps the eye participate in the bargraph goodness.

            Console.WriteLine($" {speechDictionary[input]}"); //this will print the counter of the specific word repetition in the speech
        }
        #region ReadInteger
        private static int ReadInteger(string prompt, int min, int max) //This creates a static method, able to be used throughout the Program class
        {
            while (true)//will run this loop until the user selects a proper response
            {
                Console.Write(prompt); //prompt is a variable that allows someone calling this method to just plain write in the words when they call this method
                string input = Console.ReadLine(); // grabs up on that delicious input cake.
                if (int.TryParse(input, out int answer) && answer >= min && answer <= max) // while calling this method, you are required to put a min and max, where this whole method will make sure that the input is not only in the dictionary, but in between certain values.
                    return answer; // if only getting answers was this easy... this also will spit answer out of the method, and break it

                Console.WriteLine($"{input} is not valid..."); //Do some yoga, tranquil brain is a happy brain.
            }
        }
        #endregion
        #region ReadString
        private static void ReadString(string prompt, ref string value)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) == true)
                {
                    Console.WriteLine($"{input} is not valid...");
                }
                if (string.IsNullOrEmpty(input) == false)
                {
                    value = input;
                    break;
                }
            }
        }
        #endregion

        private static void ReadChoice(string prompt, string[] options, out int selection)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(options[i]);
            }
            selection = ReadInteger(prompt, 1, options.Length);
        }

        private static string GetSpeech()
        {
            string text = "I say to you today, my friends, so even though we face the difficulties of today and tomorrow, I still have a dream. It is a dream deeply rooted in the American dream. " +
            "I have a dream that one day this nation will rise up and live out the true meaning of its creed: We hold these truths to be self-evident: that all men are created equal. " +
            "I have a dream that one day on the red hills of Georgia the sons of former slaves and the sons of former slave owners will be able to sit down together at the table of brotherhood. " +
            "I have a dream that one day even the state of Mississippi, a state sweltering with the heat of injustice, sweltering with the heat of oppression, will be transformed into an oasis of freedom and justice. " +
            "I have a dream that my four little children will one day live in a nation where they will not be judged by the color of their skin but by the content of their character. " +
            "I have a dream today. I have a dream that one day, down in Alabama, with its vicious racists, with its governor having his lips dripping with the words of interposition and nullification; one day right there in Alabama, little black boys and black girls will be able to join hands with little white boys and white girls as sisters and brothers. " +
            "I have a dream today. I have a dream that one day every valley shall be exalted, every hill and mountain shall be made low, the rough places will be made plain, and the crooked places will be made straight, and the glory of the Lord shall be revealed, and all flesh shall see it together. " +
            "This is our hope. This is the faith that I go back to the South with. With this faith we will be able to hew out of the mountain of despair a stone of hope. With this faith we will be able to transform the jangling discords of our nation into a beautiful symphony of brotherhood. " +
            "With this faith we will be able to work together, to pray together, to struggle together, to go to jail together, to stand up for freedom together, knowing that we will be free one day. " +
            "This will be the day when all of God's children will be able to sing with a new meaning, My country, 'tis of thee, sweet land of liberty, of thee I sing. Land where my fathers died, land of the pilgrim's pride, from every mountainside, let freedom ring. " +
            "And if America is to be a great nation this must become true. So let freedom ring from the prodigious hilltops of New Hampshire. Let freedom ring from the mighty mountains of New York. Let freedom ring from the heightening Alleghenies of Pennsylvania! " +
            "Let freedom ring from the snowcapped Rockies of Colorado! Let freedom ring from the curvaceous slopes of California! But not only that; let freedom ring from Stone Mountain of Georgia! " +
            "Let freedom ring from Lookout Mountain of Tennessee! Let freedom ring from every hill and molehill of Mississippi. From every mountainside, let freedom ring. " +
            "And when this happens, when we allow freedom to ring, when we let it ring from every village and every hamlet, from every state and every city, we will be able to speed up that day when all of God's children, black men and white men, Jews and Gentiles, Protestants and Catholics, will be able to join hands and sing in the words of the old Negro spiritual, Free at last! free at last! thank God Almighty, we are free at last!";

            return text;
        }

        private static string GetSpeechFromFile()
        {
            string fileText = File.ReadAllText("speech.csv");

            return fileText;
        }

        private static void Histogram()
        {
            foreach (KeyValuePair<string, int> keyValue in speechDictionary)
            {
                PrintWordSoup(keyValue.Key);
            }
        }
    }
}


