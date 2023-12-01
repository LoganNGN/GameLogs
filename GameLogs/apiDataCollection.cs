using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GameLogs.apiDataCollection
{
    public class ApiData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        //GameState returns false for teste purposes
        public bool GameState 
        {
            get
            {
                return this.GameState;
            }            
            set 
            { 
                GameState = false; 
            } 
        }
    }
}