using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	internal class Status
	{
		DisplayGameIntro dp1 = DisplayGameIntro.Instance();
		public void DisplayMyInfo()
		{
			Console.Clear();

			Console.WriteLine("[====================================================================================]");
            Console.WriteLine("                                        상태보기");
			Console.WriteLine("                                캐릭터의 정보를 표시합니다.");
			Console.WriteLine("[====================================================================================]");
			Console.WriteLine("                                이 름 : " + dp1.player.Name);
			Console.WriteLine("                                직 업 : " + dp1.player.Job);
			Console.WriteLine("                                Lv. " + dp1.player.Level);
			Console.WriteLine("                                공격력 : " + dp1.player.Atk);
			Console.WriteLine("                                방어력 : " + dp1.player.Def);
			Console.WriteLine($"                                체 력 : {dp1.player.Hp} / {dp1.player.OriHp}");
			Console.WriteLine($"                                마 나 : {dp1.player.Mp} / {dp1.player.OriMp}");
			Console.WriteLine($"                                경험치 : {dp1.player.CurExp} / {dp1.player.Exp}");
			Console.WriteLine("                                Gold :" + dp1.player.Gold);
			Console.WriteLine();
			Console.WriteLine("                                0. 나가기");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

			int input = dp1.CheckValidInput(0, 4);

			switch (input)
			{
				case 0: dp1.GameIntro(); break;
			}
		}
	}
}
