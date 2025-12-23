using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public interface ISentenceAnalyzer
    {
        public Sentence ConvertWithFile(string filename);

        public Sentence ConvertWithString(string jsonString);
    }
}
