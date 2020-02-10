using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTest_Kenika
{
    class Program
    {

        static void Main(string[] args)
        {
            //Callig the function for print 
            EachCharCount(args[0]);
        }

        /// <summary>
        /// Method to read and print the character count and the top 10 character occurances 
        /// </summary>
        /// <param name="filePath"></param>
        public static void EachCharCount(string filePath)
        {
            //Read the file from the file location 
            string text = File.ReadAllText(filePath);
            //Removing the whitespacing in the text
            var textWithoutSpace = string.Concat(text.Where(x => !char.IsWhiteSpace(x)));
            //Grouping the text by characters, counting the occurances sorting and taking top 10
            var charCountGroup = textWithoutSpace.GroupBy(t => t).Select(t => new { Char = t.Key, Count = t.Count() })
                .OrderBy(x => x.Count).Reverse().Take(10);
            //Printing the total characters
            Console.WriteLine("Total Characters: " + textWithoutSpace.Length);
            //Printing the characters with occurances 
            foreach (var chars in charCountGroup)
            {
                Console.WriteLine(chars.Char + "(" + chars.Count + ")");
            }
        }
    }
}
