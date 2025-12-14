using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public class TestConverter : IConverter
    {

        public Sentence Convert(string filename)
        {
            return new Sentence();
        }
    }
}
