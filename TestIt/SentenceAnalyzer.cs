using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TestIt
{
    class SentenceAnalyzer : ISentenceAnalyzer
    {

        public Sentence Convert(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            Sentence sentence = JsonSerializer.Deserialize<Sentence>(jsonString);
            Console.WriteLine(sentence.relations[0]);
            return sentence;
        }
    }
}
