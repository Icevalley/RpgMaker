using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
        public int CharacterId { get; set; }

    }
}