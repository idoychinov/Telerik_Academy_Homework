namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        /// <summary>
        /// Convert the input string to a byte array, in order to compute is hash and convert it to hexadecimal string.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Hash code of the input string</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();
            var stringHashAsByteArray = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var outputString = new StringBuilder();
            for (int i = 0; i < stringHashAsByteArray.Length; i++)
            {
                outputString.Append(stringHashAsByteArray[i].ToString("x2"));
            }

            return outputString.ToString();
        }

        /// <summary>
        /// Checks if the string is equal to one of the values that are considered as true.
        /// </summary>
        /// <param name="input">Input string to be converted</param>
        /// <returns>Boolean value representing the input string</returns>  
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }
        
        /// <summary>
        /// Converts the string value to short if able.
        /// </summary>
        /// <param name="input">Input string to be converted</param>
        /// <returns>Short value parsed from the string</returns>
        /// <exception cref="ArgumentException">Input value cannot be converted to short</exception>
        public static short ToShort(this string input)
        {
            short shortValue;
            if (short.TryParse(input, out shortValue))
            {
                return shortValue;
            } else
            {
                throw new ArgumentException();
            }
            
        }

        /// <summary>
        /// Converts the string value to integer.
        /// </summary>
        /// <param name="input">Input string to be converted</param>
        /// <returns>Integer value parsed from the string</returns>
        /// <exception cref="ArgumentException">Input value cannot be converted to integer</exception>
        public static int ToInteger(this string input)
        {
            int integerValue;
            if (int.TryParse(input, out integerValue))
            {
                return integerValue;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Converts the string value to long.
        /// </summary>
        /// <param name="input">Input string to be converted</param>
        /// <returns>Long value parsed from the string</returns>
        /// /// <exception cref="ArgumentException">Input value cannot be converted to long</exception>
        public static long ToLong(this string input)
        {
            long longValue;
            if (long.TryParse(input, out longValue))
            {
                return longValue;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Converts the string value to DateTime.
        /// </summary>
        /// <param name="input">Input string to be converted</param>
        /// <returns>DateTime value parsed from the string</returns>
        /// <exception cref="ArgumentException">Input value cannot be converted to DateTime</exception>       
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            if (DateTime.TryParse(input, out dateTimeValue))
            {
                return dateTimeValue;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Makes the first letter in a string a capital letter.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>The input string with capitalized first letter</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Extracts substring that is between two other strings.
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="startString">The string from which the extraction should start</param>
        /// <param name="endString">The string to which the extraction should end</param>
        /// <param name="startFrom">Position from which to start the search for the startString</param>
        /// <returns>Extracted string</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converts Cyrillic letters to Latin based on phonetic transliteration.
        /// </summary>
        /// <param name="input">Input string for translation</param>
        /// <returns>Translated string</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converts Latin letters to Cyrillic based on phonetic transliteration.
        /// </summary>
        /// <param name="input">Input string for translation</param>
        /// <returns>Translated string</returns>
        public static string ConvertLatinToCyrillicLetters(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Escapes user name to valid only symbols
        /// </summary>
        /// <param name="input">User name</param>
        /// <returns>Escaped user name string</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Escapes file name to valid only symbols
        /// </summary>
        /// <param name="input">File name</param>
        /// <returns>Escaped file name</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns only the first n characters from a string
        /// </summary>
        /// <param name="input">Input string</param>
        /// <param name="charsCount">number of characters to return</param>
        /// <returns>Output string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }


        /// <summary>
        /// Returns the file extention part from a file name
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <returns>File Extension</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Returns the content type of file based on it's extension, for easy use in html/xml type descriptions
        /// </summary>
        /// <param name="fileExtension">File extension</param>
        /// <returns>File content type</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }


        /// <summary>
        /// Converts string to byte array
        /// </summary>
        /// <param name="input">String</param>
        /// <returns>Byte array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
