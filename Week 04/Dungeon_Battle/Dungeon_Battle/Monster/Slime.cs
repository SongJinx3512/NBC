using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
    public class Slime : Monster
    {
		public string Name { get; set; }
		public int Level { get; set; }
		public int Hp { get; set; }
		public int Atk { get; set; }
		public int OriHp { get; set; }
		public Slime()
		{
			Name = "슬라임";
			Level = 6;
			Atk = 12;
			Hp = 22;
			OriHp = 22;
		}
	}
}
