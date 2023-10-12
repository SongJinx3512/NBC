using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	internal class JobSelect
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void Job_Select()
		{
			Console.Clear();
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			Console.WriteLine("원하시는 직업을 선택해주세요.");
			Console.WriteLine();
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("1. 전사");
			Console.WriteLine();
			Console.WriteLine("2. 마법사");
			Console.WriteLine();
			Console.WriteLine("3. 도적");
			Console.WriteLine();
			Console.WriteLine("====================================================================================");
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("====================================================================================");
			Console.Write(">>");

			int input = dp.CheckValidInput(1, 3);

			switch (input)
			{
				case 1:
					dp.player.Job = "전사";
					dp.player.Atk = 10;
					dp.player.Def = 5;
					dp.player.Hp = 100;
					dp.player.Mp = 50;
					dp.player.OriHp = 100;
					dp.player.OriMp = 50;
					dp.jobChk = true;
					dp.GameIntro();
					break;

				case 2:
					dp.player.Job = "마법사";
					dp.player.Atk = 12;
					dp.player.Def = 3;
					dp.player.Hp = 100;
					dp.player.Mp = 50;
					dp.player.OriHp = 100;
					dp.player.OriMp = 50;
					dp.jobChk = true;
					dp.GameIntro();
					break;

				case 3:
					dp.player.Job = "도적";
					dp.player.Atk = 11;
					dp.player.Def = 4;
					dp.player.Hp = 100;
					dp.player.Mp = 50;
					dp.player.OriHp = 100;
					dp.player.OriMp = 50;
					dp.jobChk = true;
					dp.GameIntro();
					break;
			}
		}
	}
}
