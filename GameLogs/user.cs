using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogs
{
    public class User
    {
        #region private attribute
        private string _username;
        private string _password;
        private string _email;
        private List<User> users = new List<User>();
        #endregion

        #region public methodes
        public User(string username, string password) 
        {
            _username = username;
            _password = password;
        }

        public string username 
        {
            get 
            {  
                return _username; 
            }
            set 
            {
                _username = value;            
            } 
        }

        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public string addUser(string user) 
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
