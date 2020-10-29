using System;
using System.Collections.Generic;

namespace wordcount
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Step 1 : Lies die Datei X
                Step 2 : Aufsplitten (Achtung was Satzzeichen angeht) X
                Step 3 : Wörter zählen und Ergebnis speichern X
                Step 4 : Wort mit der höchsten Anzahl ausgeben
            */
            var text = System.IO.File.ReadAllText("sampleQuotes.txt");
            char[] splitChars = new char[] { '.',
             '?', '!', ' ', ';', ':', ',', '"', '/',
            '\\', '-', '#', '+', '*', '&', '$', '\n',
             '\t', '\r', '(', ')', '{', '}', '[', ']',
             '0', '1', '2', '3', '4', '5', '6', '7',
              '8', '9', '@'};
            var split = text.Split(splitChars);
            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (var word in split)
            {
                //check for empty strings
                if(!string.IsNullOrEmpty(word) 
                || !string.IsNullOrWhiteSpace(word))
                {
                  //check for single characters that are letters  
                  if(!(word.Length == 1 
                  && !char.IsLetter(Convert.ToChar(word))))
                  {
                      string temp = word.ToLower();
                      try
                      {
                          wordCount[temp] += 1;
                      }
                      catch(KeyNotFoundException e)
                      {
                          //Console.WriteLine(e);
                          wordCount.Add(temp, 1);
                      }
                  }
                  
    
                    
                }
            }
            int max = 0;
            string mostCommonWord = "";
            foreach(var pair in wordCount)
            {
                if(pair.Value > max)
                {
                    max = pair.Value;
                    mostCommonWord = pair.Key;
                }
            }
            Console.WriteLine($"Das häufigste Wort ist \"{mostCommonWord}\" mit {max}");

        }
    }
}
