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
            }
            
            string[] words = text.Split(new string[] { " ", ",", ".", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            
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

            int count = 0;
            Console.WriteLine("{0, 23} {1,22}", "Слово", "Кол-во");
            for (int i = 0; i < newDictionary.Count; i++)
            {
                if (newDictionary[i] == " ")
                    continue;
                for (int j = 0; j < dictionary.Count; j++)
                {
                    if (newDictionary[i] == dictionary[j])
                        count++;
                }
                Console.WriteLine($"{i+1, 2} {newDictionary[i], 20} {count, 20}");
                count = 0;
            }
            Console.WriteLine($"Всего слов: {dictionary.Count}, из них уникальных: {newDictionary.Count}");
        }
    }
}
