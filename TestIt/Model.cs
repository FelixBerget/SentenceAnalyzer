using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{

    public class Word
    {
        public string _id;
        public string _text;
        public int _positon;
        public string _type;
        
        public Word(string id, string text,int position,string type)
        {
            _id = id;
            _text = text;
            _positon = position;
            _type = type;
        }
    }
    public class Relations
    {
        public string _from;
        public string _to;
        public string _type;

        public Relations(string from, string to, string type)
        {
            _from = from;
            _to = to;
            _type = type;
        }
    }

    public class Sentence
    {
        public List<Relations> _relations;
        public List<Word> _words;
        public Sentence()
        {
            _relations = new List<Relations>();
            _words = new List<Word>();
        }
    }

}
