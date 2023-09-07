using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Battle
{
	public class StageSelect
	{
		DisplayGameIntro dp = DisplayGameIntro.Instance();
		public void Stage_Select()
		{
			int range = 1;
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[                                     해금된 층                                      ]");
            Console.WriteLine("[                                                                                    ]");
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine();
			Console.WriteLine("                                        1층");
			Console.WriteLine();
			if (dp.Layer2)
			{
			Console.WriteLine("                                        2층");
			Console.WriteLine();
			}
			if (dp.Layer3)
			{			
			Console.WriteLine("                                        3층(마지막 층)");
			Console.WriteLine();
			}
			Console.WriteLine("                                        0. 나가기");
			Console.WriteLine();
            Console.WriteLine("[====================================================================================]");
            Console.WriteLine("원하시는 층을 선택해주세요");
			Console.Write(">>");

			if (dp.Layer2) range += 1;
			if (dp.Layer3) range += 1;
			int input = dp.CheckValidInput(0, range);

			switch (input)
			{
				case 0: dp.GameIntro(); break;
				case 1: dp.player.Stage = 1; dp.GameIntro(); break;
				case 2: dp.player.Stage = 2; dp.GameIntro(); break;
				case 3: dp.player.Stage = 3; dp.GameIntro();break;

			}
		}
	}
}
