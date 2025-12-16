using System;
using System.Collections.Generic;
using System.Text;

namespace TestIt
{
    public interface IGraphDBService
    {
        public Task SendToServer(Sentence sentence);

        public Task<List<Word>> RecieveFromServer(string dataBase, string userName, string passWord);

        public Task<List<Word>> SearchInServer(string dataBase, string userName, string passWord, string askedWord);
    }
}
