using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Golem : Monster
	{
		public string Name { get; set; }
		public int Level { get; set; }
		public int Hp { get; set; }
		public int Atk { get; set; }
		public int OriHp { get; set; }
		public Golem()
		{
			Name = "골렘";
			Level = 7;
			Atk = 13;
			Hp = 30;
			OriHp = 30;
		}
	}
}
