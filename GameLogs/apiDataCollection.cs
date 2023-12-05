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
        private int _id;
        private string _name;
        private string _description;
        private string _image;
        private string _gameState;

        public ApiData(int id ,string name, string description, string image, string GameState)
        {
            _id = id;
            _name = name;
            _description = description;
            _image = image;
            _gameState = GameState;
        }

        public int Id { get; set; }
        public string Name { get; set; }       
        public string Description { get; set; }
        public string Image { get; set; }
        //GameState returns false for teste purposes
        public string GameState { get; set; }
        
    }

}