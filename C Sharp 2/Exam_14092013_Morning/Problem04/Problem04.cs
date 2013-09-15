using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;//only for testing
using System.Text;
using System.Threading.Tasks;


///
/// 4. Decode and Decrypt
///

namespace Problem04
{
    class Problem04
    {
        static void Main()
        {
            //only for testing
            string file = @"..\..\..\t5.txt";
            if (File.Exists(file))
            {
                Console.SetIn(new StreamReader(file));
            }
            //only for testing

            string message = Console.ReadLine();
            int cypherLenghtInString = GetCyperLenght(message);
            int cypherLenght = int.Parse(message.Substring(message.Length - cypherLenghtInString, cypherLenghtInString));
            string decodedMessage = Decode(message.Substring(0, message.Length - cypherLenghtInString));
            string cypher = decodedMessage.Substring(decodedMessage.Length - cypherLenght, cypherLenght);
            string encriptedMessage = decodedMessage.Substring(0, decodedMessage.Length - cypher.Length);
            Console.WriteLine(Encript(encriptedMessage, cypher));
        }

        static string Decode(string message)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsDigit(message[i]))
                {
                    int repeat = int.Parse(message[i].ToString());
                    i++;
                    char letterToRepeat = message[i];
                    for (int j = 0; j < repeat; j++)
                    {
                        output.Append(letterToRepeat);
                    }
                }
                else
                {
                    output.Append(message[i]);
                }
            }
            return output.ToString();
        }

        static string Encript(string message, string cypher)
        {
            StringBuilder output = new StringBuilder(message.Length);

            if (message.Length >= cypher.Length)
            {
                int cypherIndex = 0;
                for (int i = 0; i < message.Length; i++)
                {
                    cypherIndex = i % cypher.Length;
                    output.Append(EncriptLetter(message[i], cypher[cypherIndex]));

                }
            }
            else
            {

                for (int i = 0; i < cypher.Length; i++)
                {
                    if (i < message.Length)
                    {
                        output.Append(EncriptLetter(message[i], cypher[i]));
                    }
                    else
                    {
                        output[i % message.Length] = EncriptLetter(output[i % message.Length], cypher[i]);
                    }
                }
            }

            return output.ToString();
        }

        private static char EncriptLetter(char p1, char p2)
        {
            return (char)(((p1 - 65) ^ (p2 - 65)) + 65);
        }

        static int GetCyperLenght(string message)
        {
            int result = 0;
            int currentIndex = message.Length - 1;

            while (char.IsDigit(message[currentIndex]))
            {
                currentIndex--;
            }

            return message.Length - (currentIndex + 1);
        }
    }
}
