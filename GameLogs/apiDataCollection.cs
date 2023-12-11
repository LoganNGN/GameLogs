using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GameLogs.apiDataCollection
{
    public class apiData
    {
        public apiData(int id ,string name, string description, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
        }

        public int Id { get; set; }
        public string Name { get; set; }       
        public string Description { get; set; }
        public string Image { get; set; }
        
    }

}