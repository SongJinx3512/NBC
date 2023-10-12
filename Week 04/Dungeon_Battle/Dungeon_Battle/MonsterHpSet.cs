using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class MonsterHpSet
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void MonsterHp_Set()
		{
			foreach(Monster val in dp.allMonsterlist)
			{
				val.Hp = val.OriHp;
			}
		}
	}
}
