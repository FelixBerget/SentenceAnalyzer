using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TestIt
{
    class SentenceAnalyzer : ISentenceAnalyzer
    {

        public Sentence ConvertWithFile(string filename)
        {
            if (File.Exists(filename))
            {
                return new Sentence();
            }
            string jsonString = File.ReadAllText(filename);
            Sentence sentence = JsonSerializer.Deserialize<Sentence>(jsonString);
            return sentence;
        }

        public Sentence ConvertWithString(string jsonString)
        {
            if(jsonString == "")
            {
                return new Sentence();
            }
            Sentence sentence = JsonSerializer.Deserialize<Sentence>(jsonString);
            return sentence;
        }
    }
}
