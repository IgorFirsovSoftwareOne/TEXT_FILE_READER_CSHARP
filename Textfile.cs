using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Textdateiauslesung
{
    public class Textfile
    {
        private string path = @"C:\Users\Igor.Firsov\Desktop\Textfile-Reader-CSHARP\100MB.txt";
        Progressbar progress = new Progressbar();
        private Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        public void ReadTextFile()
        {
            string line;

            if (CheckTextFile())
            {
                var lineLength = 0;
                int fileSize = Convert.ToInt32(getBizeSizeOfFile());

                using (StreamReader fileReader = File.OpenText(path))
                {
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        lineLength += line.Length;
                        progress.DisplayProgressInPercentage(fileSize, lineLength );   
                        AnalyseText(line);
                    }
                }
            }
        }

        private void AnalyseText(string line)
        {            
            var splittedLine = ProcessLine(line).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in splittedLine)
            {
                if (wordFrequency.ContainsKey(word))
                    wordFrequency[word] += 1;
                else
                    wordFrequency.Add(word, 1);
            }
        }

        public void DisplayWordFrequency()
        {
            var sortedList = wordFrequency.OrderByDescending(kv => kv.Value);
            sortedList.Take(100).ToList().ForEach(item => Console.WriteLine($"Word: {item.Key} -- Amount: {item.Value}"));
        }    

        private long getBizeSizeOfFile()
        {
            var fileSizeInByte = new FileInfo(path).Length;
            return fileSizeInByte;
        }

        public int lineCounting()
        {
            var lineCounter = 0;
            using (StreamReader stream = File.OpenText(path))
            {
                while (stream.ReadLine() != null)
                {
                    lineCounter++;
                }
            }
            return lineCounter;
        }   

        private bool CheckTextFile()
        {
            if (File.Exists(path))
                return true;
            else
                return false;
        }

        private string ProcessLine(string line)
        {
            string processedLine = line.ToLower();
            processedLine = RemoveSpecialCharacters(processedLine);
            return processedLine;
        }

        private string RemoveSpecialCharacters(string line)
        {
            return Regex.Replace(line, "[^a-züöä ]+", "", RegexOptions.Compiled);
        }
    }
}