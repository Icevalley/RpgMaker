using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class Inventory
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}