using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticeGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            string text;
            using (StreamReader sr = new StreamReader("text.txt"))
            {
                text = sr.ReadToEnd();
                text = text.Trim(new char[] { '\n' });
            }
            
            string[] words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            for (int i = 0; i < words.Length; i++)
            {
                dictionary.Add(i, words[i]);
            }
            
            int k = 0;
            Dictionary<int, string> newDictionary = new Dictionary<int, string>();

            for (int i = 0; i < dictionary.Count; i++)
            {
                if (!newDictionary.ContainsValue(dictionary[i]))
                {
                    newDictionary.Add(k++, dictionary[i]);
                }
            }

            for (int i = 0; i < newDictionary.Count; i++)
            {
                Console.WriteLine(newDictionary[i]);
            }
        }
    }
}
