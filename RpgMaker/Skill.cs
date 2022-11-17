using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class Skill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        public string DmgType { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
        
    }
}