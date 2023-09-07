using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Player
	{
		public string Name { get; set; }
		public string Job { get; set; }
		public int Level { get; set; }
		public int Atk { get; set; }
		public int Def { get; set; }
		public int Hp { get; set; }
		public int Gold { get; set; }
		public int Mp { get; set; }
		public int Avoidance { get; set; }
		public int Stage { get; set; }
		public int OriHp { get; set; }
		public int OriMp { get; set; }
		public int CurExp { get; set; }
		public int Exp { get; set; }
		public Player(string name, string job, int level, int atk, int def, int hp, int gold, int mp, int avoidance, int stage, int oriHp, int oriMp)
		{
			Name = name;
			Job = job;
			Level = level;
			Atk = atk;
			Def = def;
			Hp = hp;
			Gold = gold;
			Mp = mp;
			Avoidance = avoidance;
			Stage = stage;
			OriHp = oriHp;
			OriMp = oriMp;
			CurExp = 0;
			Exp = 25 + (15 * level);
		}
	}
}
