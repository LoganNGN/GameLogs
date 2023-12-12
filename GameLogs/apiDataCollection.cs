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
        public ApiData()
        {
            //values for tests purposes
            Id = 1;
            Name = "YuGiOh";
            Description = "Table Card Game";
            Image = "Link2Image";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


    }

}