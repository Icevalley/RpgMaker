using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgMaker
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<Character> Characters { get; set; }

    }
}