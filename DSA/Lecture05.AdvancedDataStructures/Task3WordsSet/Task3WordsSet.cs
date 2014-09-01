namespace Task3WordsSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Task 3. Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file). Print how many times each word occurs in the text.
    /// Hint: you may find a C# trie in Internet.
    /// </summary>
    public class Task3WordsSet
    {
        public const int WordsToAdd = 1000000;
        public const int WordsToSearch = 1000000;
        public static readonly Random RandomGenerator = new Random();

        public static void Main()
        {
            Console.WriteLine("Start generating words at {0:hh:mm:ss}", DateTime.Now);

            var trie = new Trie();

            for (int i = 0; i < WordsToAdd; i++)
            {
                string word = GetRandomWord();
                trie.Add(word);
            }

            Console.WriteLine("Start searching words at {0:hh:mm:ss}", DateTime.Now);

            for (int i = 0; i < WordsToSearch; i++)
            {
                string word = GetRandomWord();
                trie.GetWordOccurance(word);
            }

            Console.WriteLine("Found {0} words at {1:hh:mm:ss} ", WordsToSearch, DateTime.Now);

            Console.Write("Most common word: ");
            Console.WriteLine(trie.GetMostCommonWord());
        }

        public static string GetRandomWord()
        {
            char[] newWord = new char[RandomGenerator.Next(5, 12)];
            for (int i = 0; i < newWord.Length; i++)
            {
                newWord[i] = (char)RandomGenerator.Next(65, 91);
            }

            return new string(newWord);
        }
    }
}
