using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	internal class LvUp
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void PlayerLvUp(int stage)
		{
			if(stage == 1) dp.player.CurExp += 50;
			if(stage == 2) dp.player.CurExp += 40;
			if(stage == 3) dp.player.CurExp += 60;

			if (dp.player.CurExp >= dp.player.Exp)
			{
				dp.player.Level += 1;
				dp.player.OriHp += 10;
				dp.player.OriMp += 10;
				dp.player.Atk += 1;
				dp.player.Def += 1;
				dp.player.Hp = dp.player.OriHp;
				dp.player.Mp = dp.player.OriMp;
				dp.player.CurExp = dp.player.CurExp - dp.player.Exp;
			}
		}
	}
}
