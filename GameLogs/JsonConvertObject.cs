using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameLogs
{
    public class JsonConvertObject
    {
        private string _jsonString;
        public JsonConvertObject(string JsonString) 
        {
            _jsonString = JsonString;
        }
        public string Json
        {
            get {  return _jsonString; }
        }
        public void JsonDeserializer()
        {
            //TODO add the object list
            //var gameToPlayData = JsonSerializer.Deserialize<GamesToPlayList<XXX>>(_jsonString);
            //var gameFinishedData = JsonSerializer.Deserialize<finishedGameList<XXX>>(_jsonString);
        }
    }
}
