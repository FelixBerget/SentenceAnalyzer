using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public interface IConverter
    {
        public Sentence Convert(string filename);
    }
}
