using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class Goblin : Monster
    {
		public string Name { get; set; }
		public int Level { get; set; }
		public int Hp { get; set; }
		public int Atk { get; set; }
		public int OriHp { get; set; }
		public Goblin()
		{
			Name = "고블린";
			Level = 6;
			Atk = 15;
			Hp = 23;
			OriHp = 23;
		}
	}
}
