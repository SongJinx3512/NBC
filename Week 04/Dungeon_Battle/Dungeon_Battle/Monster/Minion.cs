using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class Minion : Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
		public int OriHp { get; set; }
		public Minion()
        {
            Name = "미니언";
            Level = 2;
            Atk = 5;
            Hp = 15;
            OriHp = 15;
        }
    }
}
