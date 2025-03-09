using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3Sorting_SpencerJames
{
    class Program
    {
        static string batman;
        public static char[] wordDelimiters = new char[] { ',' };
        static void Main(string[] args)
        {
            batman = GetSpeechFromFile();
            List<String> titles = new List<String>(batman.Split(wordDelimiters, StringSplitOptions.RemoveEmptyEntries));
            int menuChoice = 0;
            while (menuChoice != 4)
            {
                Console.Clear();
                string[] mainMenu = new string[] { "1: Bubble Sort", "2: Merge Sort", "3: Binary Search", "4: Exit" };
                ReadChoice("Choice: ", mainMenu, out menuChoice);
                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n*******BUBBLESORTED*******");
                        List<String> bubbleSortTitles = new List<String>(titles);
                        BubbleSort(bubbleSortTitles);
                        for (int i = 0; i < titles.Count - 1; i++)
                        {
                            Console.Write($"{titles[i]}");
                            Console.CursorLeft = Console.WindowWidth - 70;
                            Console.WriteLine($"{bubbleSortTitles[i]}");

                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n*******MERGESORTED*******");
                        List<String> mergeSortTitles = new List<String>(titles);
                        mergeSortTitles = MergeSort(mergeSortTitles);
                        for (int i = 0; i < mergeSortTitles.Count - 1; i++)
                        {
                            Console.Write($"{titles[i]}");
                            Console.CursorLeft = Console.WindowWidth - 70;
                            Console.WriteLine($"{mergeSortTitles[i]}");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        List<String> binarySearchTitles = new List<string>(titles);
                        binarySearchTitles.Sort();
                        int counter = 0;
                        for (int i = 0; i < binarySearchTitles.Count - 1; i++)
                        {

                            Console.Write($"{binarySearchTitles[i]}");
                            Console.CursorLeft = Console.WindowWidth - 70;
                            Console.Write($"Index: {counter}");
                            Console.CursorLeft = Console.WindowWidth - 50;
                            Console.WriteLine($"Found Index: {BinarySearch(binarySearchTitles, binarySearchTitles[i], 0, binarySearchTitles.Count-1)}");
                            counter++;
                        }
                        Console.ReadKey();
                        break;

                }
            }


        }

        private static int BinarySearch(List<string> binarySearchTitles, string searchTerm, int low, int high)
        {
            int notFound = -1;
            if (high < low)
                return notFound;
            int mid = ((low + high) / 2);
            if (string.Compare(binarySearchTitles[mid], searchTerm) > 0)
                return BinarySearch(binarySearchTitles, searchTerm, low, mid - 1);
            else if (string.Compare(binarySearchTitles[mid], searchTerm) < 0)
                return BinarySearch(binarySearchTitles, searchTerm, mid + 1, high);
            else
                return mid;
        }

        private static string GetSpeechFromFile()
        {
            string fileText = File.ReadAllText("inputFile.csv");

            return fileText;
        }
        public static void BubbleSort(List<string> bubbleSortTitles)
        {
            bool swapped;
            string temp;
            int n = bubbleSortTitles.Count;
            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; i++)
                {
                    if (String.Compare(bubbleSortTitles[i], bubbleSortTitles[i + 1]) > 0)
                    {
                        temp = bubbleSortTitles[i];
                        bubbleSortTitles[i] = bubbleSortTitles[i + 1];
                        bubbleSortTitles[i + 1] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped == true);
        }
        public static List<string> MergeSort(List<String> mergeSortTitles)
        {
            List<String> mergedTitles = new List<String>();
            int i = 0;
            if (mergeSortTitles.Count <= 1)
                return mergeSortTitles;
            List<string> left = null;
            List<string> right = null;


            left = new List<string>();
            right = new List<string>();

            foreach (string item in mergeSortTitles)
            {

                if (i < (mergeSortTitles.Count) / 2)
                    left.Add(item);
                else
                    right.Add(item);
                i++;
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        public static List<string> Merge(List<string> left, List<string> right)
        {
            List<string> result = new List<string>();
            while (left.Count != 0 && right.Count != 0)
            {
                int i = 0;
                if (string.Compare(left[i], right[i]) > 0)
                {
                    result.Add(right[i]);
                    right.RemoveAt(i);
                }
                else
                {
                    result.Add(left[i]);
                    left.RemoveAt(i);
                }
            }
            while (left.Count != 0)
            {
                result.Add(left[0]);
                left.RemoveAt(0);
            }
            while (right.Count != 0)
            {
                result.Add(right[0]);
                right.RemoveAt(0);
            }
            return result;
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
