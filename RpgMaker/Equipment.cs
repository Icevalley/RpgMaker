using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Material { get; set; }
        public int Armor { get; set; }
        public int Durability { get; set; }
        [JsonIgnore]
        public List<Character> Character { get; set; }
        
    }
}