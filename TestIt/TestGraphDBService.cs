using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public class TestGraphDBService : IGraphDBService
    {

        public async Task SendToServer(Sentence sentence)
        {
        }

        public async Task<List<Word>> RecieveFromServer(string dataBase, string userName, string passWord)
        {
            List<Word> l = new List<Word>();
            return l;
        }

        public async Task<List<Word>> SearchInServer(string dataBase, string userName, string passWord,string askedWord)
        {
            List<Word> l = new List<Word>();
            return l;
        }
    }
}
