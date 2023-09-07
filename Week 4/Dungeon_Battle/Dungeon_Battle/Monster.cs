using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public interface Monster
	{
		string Name { get; set; }
		int Level { get; set; }
		int Hp { get; set; }
		int Atk { get; set; }
		int OriHp { get; set; }
	}
}
