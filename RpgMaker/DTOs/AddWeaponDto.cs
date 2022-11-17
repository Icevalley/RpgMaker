using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RpgMaker
{
    public class AddWeaponDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Damage { get; set; }
        public int CharacterId { get; set; }
    }
}