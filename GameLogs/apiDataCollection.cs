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
        private int id;
        private string name;
        private string description;
        private string image;
        private string gameState;

        public ApiData(int id ,string name, string description, string image, string GameState)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Image = image;
            this.GameState = GameState;
        }

        public int Id { get; set; }
        public string Name { get; set; }       
        public string Description { get; set; }
        public string Image { get; set; }
        //GameState returns false for teste purposes
        public string GameState { get; set; }
        
    }

}