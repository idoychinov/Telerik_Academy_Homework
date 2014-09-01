namespace Task3CountWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Task3CountWords
    {
        /// <summary>
        /// Task 3. Write a program that counts how many times each word from given text file words.txt appears in it. The character casing differences should be ignored. 
        /// The result words should be ordered by their number of occurrences in the text. Example:
        /// This is the TEXT. Text, text, text – THIS TEXT! Is this the text?
        /// is  2
        /// the  2
        /// this  3
        /// text  6
        /// </summary>
        public static void Main()
        {
            var text = string.Empty;
            using (StreamReader reader = new StreamReader(@"../../words.txt"))
            {
                text = reader.ReadToEnd();
            }

            var words = text.Split(new char[] { ' ', '.', ',', '-', '!', '?', '\'', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                var wordToLower = word.ToLower();
                if (wordCount.ContainsKey(wordToLower))
                {
                    wordCount[wordToLower] += 1;
                }
                else
                {
                    wordCount.Add(wordToLower, 1);
                }
            }

            var ordered = wordCount.OrderBy(x => x.Value);
            foreach (var item in ordered)
            {
                Console.WriteLine("{0} -> {1} times", item.Key, item.Value);
            }
        }
    }
}
