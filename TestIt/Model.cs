using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{

    public class Word
    {
        public string id { get; set; }
        public string text { get; set; }
        public int position { get; set; }
        public string type { get; set; }
        
        public Word(string id, string text,int position,string type)
        {
            this.id = id;
            this.text = text;
            this.position = position;
            this.type = type;
        }
    }
    public class Relations
    {
        public string from { get; set; }
        public string to { get; set; }
        public string type { get; set; }

        public Relations(string from, string to, string type)
        {
            this.from = from;
            this.to = to;
            this.type = type;
        }
    }

    public class Sentence
    {
        public List<Relations> relations { get; set; }
        public List<Word> words { get; set; }
        public Sentence()
        {
            relations = new List<Relations>();
            words = new List<Word>();
        }
    }

}
