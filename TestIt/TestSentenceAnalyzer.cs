using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public class TestSentenceAnalyzer : ISentenceAnalyzer
    {

        public Sentence ConvertWithFile(string filename)
        {
            return new Sentence();
        }
        public Sentence ConvertWithString(string jsonString)
        {
            return new Sentence(); 
        }
    }
}
