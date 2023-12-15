using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameLogs.apiDataCollection
{
    public class ApiData
    {
        //TODO add the json file

        //propertys to assigne and affect the json data
        [JsonProperty("id")] public int id;
        [JsonProperty("name")] public string name;
        [JsonProperty("desciption")] public string description;
        [JsonProperty("image")] public string image;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [Newtonsoft.Json.JsonConstructor]
        public ApiData()
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;

            //values for tests purposes
            //Id = 1;
            //Name = "YuGiOh";
            //Description = "Table Card Game";
            //Image = "Link2Image";
        }
       
    }
}