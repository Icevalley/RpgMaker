using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class CreateCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int UserId { get; set; }
    }
}