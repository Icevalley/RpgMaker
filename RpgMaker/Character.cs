using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Weapon> Weapon { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<Skill> Skills { get; set; }
        
    }
}