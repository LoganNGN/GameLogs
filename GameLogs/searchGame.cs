using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogs
{
    public class searchGame
    {
        #region private attributes
        private string _keyWord;

        #endregion

        #region public methods
        public searchGame(string keyWord)
        {
            _keyWord = keyWord;
        }

        public string setKeyWord
        {
            set 
            { 
                _keyWord += value;
            }
        }
        #endregion
    }
}
