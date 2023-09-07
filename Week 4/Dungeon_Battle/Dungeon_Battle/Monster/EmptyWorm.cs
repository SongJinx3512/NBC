using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class EmptyWorm : Monster
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
		public int OriHp { get; set; }
		public EmptyWorm()
        {
            Name = "공허충";
            Level = 3;
            Atk = 5;
            Hp = 10;
            OriHp = 10;
        }
    }
}
