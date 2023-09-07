using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class CannonMinion : Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
		public int OriHp { get; set; }

		public CannonMinion()
        {
            Name = "대포미니언";
            Level = 5;
            Atk = 8;
            Hp = 25;
            OriHp = 25;
        }
    }
}
