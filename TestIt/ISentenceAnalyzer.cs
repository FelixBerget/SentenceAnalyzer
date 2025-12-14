using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public interface ISentenceAnalyzer
    {
        public Sentence Convert(string filename);
    }
}
