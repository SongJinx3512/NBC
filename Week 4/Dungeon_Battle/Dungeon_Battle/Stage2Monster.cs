using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class Stage2Monster
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public List<Monster> Stage2_Monster()
		{
			Random monRan = new Random();
			List<Monster> monList = new List<Monster>();
			var normalSet = new HashSet<int>();
			var hardSet = new HashSet<int>();
			int monLvlChk = monRan.Next(0, 2);

			if (monLvlChk == 0)
			{
				for (int i = 0; i < 2; i++)
				{
					int a = monRan.Next(0, dp.monsterlist.Count - normalSet.Count);
					var nRange = Enumerable.Range(0, dp.monsterlist.Count).Where(i => !normalSet.Contains(i));
					int nVal = nRange.ElementAt(a);
					monList.Add(dp.monsterlist[nVal]);
					normalSet.Add(nVal);
				}
				int b = monRan.Next(0, dp.hardMonsterlist.Count);
				monList.Add(dp.hardMonsterlist[b]);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					int c = monRan.Next(0, dp.hardMonsterlist.Count - hardSet.Count);
					var hRange = Enumerable.Range(0, dp.hardMonsterlist.Count).Where(i => !hardSet.Contains(i));
					int hVal = hRange.ElementAt(c);
					monList.Add(dp.hardMonsterlist[hVal]);
					hardSet.Add(hVal);
				}
				int d = monRan.Next(0, dp.monsterlist.Count);
				monList.Add(dp.monsterlist[d]);
			}
			return monList;
		}
	}
}
