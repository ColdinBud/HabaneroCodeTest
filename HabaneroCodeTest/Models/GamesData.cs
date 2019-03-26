using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HabaneroCodeTest.Models
{
    /*
    {
        "Games": [
            {
                "BrandGameId":"3895b73a-7236-4ff0-b343-d5edfa45bee8",
                "Name":"5 Lucky Lions",
                "KeyName":"SG5LuckyLions",
                "GameTypeId":11,
                "TranslatedNames":[
                    {
                       "LanguageId":1,
                       "Locale":"en",
                       "Translation":"5 Lucky Lions"
                    },
                    {
                       "LanguageId":2,
                       "Locale":"fr-FR",
                       "Translation":"5 Lucky Lions"
                    }
                ]
            }
        ]
    }
    */
    public class GamesData
    {
        [JsonProperty("Games")]
        public List<Game> games { get; set; }

        public class Game
        {
            [JsonProperty("BrandGameId")]
            public string brandGameId { get; set; }
            [JsonProperty("Name")]
            public string name { get; set; }
            [JsonProperty("KeyName")]
            public string keyName { get; set; }
            [JsonProperty("GameTypeId")]
            public int gameTypeId { get; set; }
            [JsonProperty("TranslatedNames")]
            public List<TranslatedName> translatedNames { get; set; }
        }

        public class TranslatedName
        {
            [JsonProperty("LanguagedId")]
            public int languagedId { get; set; }
            [JsonProperty("Locale")]
            public string locale { get; set; }
            [JsonProperty("Translation")]
            public string translation { get; set; }
        }
    }
}